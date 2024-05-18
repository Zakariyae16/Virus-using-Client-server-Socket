using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerTest
{
    public partial class ServerStat : UserControl
    {
        private static ServerStat stat;
        Server server;

        string valeur1 = "Server is Down";
        string valeur2 = "Server is Up";

        public static ServerStat Instance
        {
            get
            {
                if (stat == null)
                {
                    stat = new ServerStat();
                }
                return stat;
            }
        }

        public ServerStat()
        {
            InitializeComponent();
            Stop_btn.Enabled = false;
        }

        private void ServerStat_Load(object sender, EventArgs e)
        {

        }

        private void Start_btn_Click(object sender, EventArgs e)
        {
            if (Start_btn.Enabled)
            {
                Start_btn.Enabled = false;
                Stop_btn.Enabled = true;
                st_label.Text = valeur2;
            }

            Outils outilsControl = Outils.Instance; // Utiliser l'instance existante de Outils
            server = new Server(1616, 5656, info_txtbox, outilsControl);
            server.Start();
        }

        private void Stop_btn_Click(object sender, EventArgs e)
        {
            //string cheminImage = @"C:\Users\Lenovo\Desktop\Project_C#\ServerTest\cercle_rouge.png";
            //Image image = Image.FromFile(cheminImage);
            if (Stop_btn.Enabled == true)
            {
                Stop_btn.Enabled = false;
                Start_btn.Enabled = true;
                //status_imgbx.Image = image;
                st_label.Text = valeur1;
            }
            server.Stop();
        }
    }
}
