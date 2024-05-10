using System;
using System.IO;
using System.Management;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Net;

namespace Test_Socket
{
    public class ClientCollecte
    {
        private string IPserver;
        private int Portserver;

        private StreamWriter writer;
        private StreamReader reader;
        private Socket s;

        public ClientCollecte(string IPserver, int Portserver)
        {
            this.IPserver = IPserver;
            this.Portserver = Portserver;
            ConnectToServer();
        }

        public void ConnectToServer()
        {
            try
            {
                s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(IPserver), Portserver);
                s.Connect(endPoint);

                NetworkStream stream = new NetworkStream(s);
                writer = new StreamWriter(stream);
                reader = new StreamReader(stream);

                MessageBox.Show("Client Connected...");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la connexion au serveur : " + ex.Message);
                // Assurez-vous que writer est initialisé à null en cas d'échec de la connexion
                writer = null;
            }
        }


        public void SendData(string os, string mother, string proc, string ram, string disk, byte[] screenshot)
        {
            try
            {
                if (writer == null)
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
                writer.Flush();
                MessageBox.Show("Données envoyées au serveur.");

                // Envoyer les captures d'écran au serveur
                if (screenshot != null && screenshot.Length > 0)
                {
                    // Convertir les bytes de l'image en base64 pour l'envoi
                    string screenshotBase64 = Convert.ToBase64String(screenshot);

                    // Envoyer les captures d'écran au serveur
                    writer.WriteLine(screenshotBase64);
                    writer.Flush();
                    MessageBox.Show("Capture d'écran envoyée au serveur.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'envoi des données : " + ex.Message);
            }
        }

        private string GetOperatingSystemInfo()
        {
            return "OS# " + Environment.OSVersion;
        }

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

        public void CollectAndSendData()
        {
            string os = GetOperatingSystemInfo();
            string mother = GetMotherboardInfo();
            string proc = GetProcessorInfo();
            string ram = GetRAMInfo();
            string disk = GetDiskInfo();
            byte[] screenshotBytes = TakeScreenshot();
            SendData(os, mother, proc, ram, disk, screenshotBytes);
        }
    }
}
