using System;
using System.Windows.Forms;

namespace ServerTest
{
    public partial class Outils : UserControl
    {
        private static Outils instance;
        public static Outils Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Outils();
                }
                return instance;
            }
        }

        public PictureBox VideoPictureBox
        {
            get { return video_pictrbox; }
        }

        public Outils()
        {
            InitializeComponent();
        }

        private void Outils_Load(object sender, EventArgs e)
        {
            // Initialisation du contrôle utilisateur
        }

        private void video_pictrbox_Click(object sender, EventArgs e)
        {
            // Gestionnaire d'événements pour la PictureBox
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
