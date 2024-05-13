using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ServerTest
{
    public class VideoServer
    {
        private TcpListener server;

        public async Task StartServerAsync(int port)
        {
            try
            {
                // Démarrer le serveur TCP sur le port spécifié
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");
                server = new TcpListener(localAddr, port);
                server.Start();

                Console.WriteLine("Serveur démarré. En attente de connexions...");

                // Attendre les connexions des clients
                while (true)
                {
                    TcpClient client = await server.AcceptTcpClientAsync();

                    // Envoyer le flux vidéo au client
                    await SendVideoData(client);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur : " + e.Message);
            }
            finally
            {
                server.Stop();
            }
        }

        private async Task SendVideoData(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            try
            {
                // Boucle pour envoyer des trames vidéo (remplacez cela par votre propre logique de capture vidéo)
                Random random = new Random();
                while (true)
                {
                    byte[] videoFrame = new byte[1024]; // Exemple de trame vidéo de 1024 octets
                    random.NextBytes(videoFrame);
                    await stream.WriteAsync(videoFrame, 0, videoFrame.Length);
                    await Task.Delay(33); // 30 FPS
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de l'envoi de la vidéo : " + ex.Message);
            }
            finally
            {
                stream.Close();
                client.Close();
            }
        }
    }
}
