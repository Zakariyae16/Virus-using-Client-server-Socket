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
        private Socket serverSocket;
        private bool isRunning;
        private TextBox infoTextBox;
        private SqlConnection cnx;

        public Server(int port, TextBox textBox)
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("0.0.0.0"), port);
            serverSocket.Bind(iep);
            isRunning = false;
            infoTextBox = textBox;
        }

        public void Start()
        {
            isRunning = true;
            serverSocket.Listen(5);
            AddTextToInfoTextBox("Serveur démarré. En attente de connexions...");

            Task.Run(() => AcceptClients()); // Démarrer la méthode AcceptClients dans un nouveau thread
        }

        private void AcceptClients()
        {
            while (isRunning)
            {
                Socket clientSocket = serverSocket.Accept();
                Task.Run(() => Communication(clientSocket)); // Utilisation de Task.Run pour éviter le blocage de l'interface
            }
        }

        private void Communication(Socket clientSocket)
        {
            NetworkStream ns = new NetworkStream(clientSocket);
            StreamReader reader = new StreamReader(ns);

            try
            {
                // Lire les données envoyées par le client
                string os = reader.ReadLine();
                string motherboard = reader.ReadLine();
                string processor = reader.ReadLine();
                string ram = reader.ReadLine();
                string disk = reader.ReadLine();

                // Lire la capture d'écran envoyée par le client
                string screenshotBase64 = reader.ReadLine();
                byte[] screenshot = Convert.FromBase64String(screenshotBase64);

                // Stocker les données dans la base de données
                InsertDataIntoDatabase(os, motherboard, processor, ram, disk, screenshot);

                MessageBox.Show("Données reçues et stockées dans la base de données.");

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

        private void InsertDataIntoDatabase(string os, string motherboard, string processor, string ram, string disk, byte[] screenshot)
        {
            // Connexion à la base de données et insertion des données
            string query = "INSERT INTO receivedData1 (OS, motherboard, processeur, ram, hardDisk, captureData, receivedAt) " +
                           "VALUES (@OS, @Motherboard, @Processor, @RAM, @Disk, @Screenshot, @ReceivedAt)";

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
            serverSocket.Close();
            AddTextToInfoTextBox("Fermeture de la connexion");
        }
    }
}
