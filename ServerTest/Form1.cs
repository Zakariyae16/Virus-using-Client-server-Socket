namespace ServerTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez-vous quitter ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btn_minimiser_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ServerStat_btn_Click(object sender, EventArgs e)
        {
            pnl_slide.Top = ServerStat_btn.Top;
            //btn_etudiant.Size = new Size(243; 67);

            if (!pnl_tous.Controls.Contains(ServerStat.Instance)) //Cette ligne vérifie si pnl_tous ne contient pas déjà une instance de la classe ServerStat.
            {
                pnl_tous.Controls.Add(ServerStat.Instance);  //l'instance de ServerStat est ajoutée aux contrôles enfants du pnl_etud
                ServerStat.Instance.Dock = DockStyle.Fill;  //configure la propriété Dock de l'instance de Etudiant pour remplir tout l'espace disponible dans le pnl_etud.
                ServerStat.Instance.BringToFront();   //assure que le contrôle Etudiant est amené à l'avant-plan c-a-d il sera affiché au-dessus des autres contrôles du panneau
            }
            else
            {
                ServerStat.Instance.BringToFront();
            }
        }

        private void Data_btn_Click(object sender, EventArgs e)
        {
            pnl_slide.Top = Data_btn.Top;

            if (!pnl_tous.Controls.Contains(viewData.Instance)) //Cette ligne vérifie si pnl_tous ne contient pas déjà une instance de la classe ServerStat.
            {
                pnl_tous.Controls.Add(viewData.Instance);  //l'instance de ServerStat est ajoutée aux contrôles enfants du pnl_etud
                viewData.Instance.Dock = DockStyle.Fill;  //configure la propriété Dock de l'instance de Etudiant pour remplir tout l'espace disponible dans le pnl_etud.
                viewData.Instance.BringToFront();   //assure que le contrôle Etudiant est amené à l'avant-plan c-a-d il sera affiché au-dessus des autres contrôles du panneau
            }
            else
            {
                viewData.Instance.BringToFront();
            }
        }

        private void video_btn_Click(object sender, EventArgs e)
        {
            pnl_slide.Top = video_btn.Top;

            if (!pnl_tous.Controls.Contains(Outils.Instance)) //Cette ligne vérifie si pnl_tous ne contient pas déjà une instance de la classe ServerStat.
            {
                pnl_tous.Controls.Add(Outils.Instance);  //l'instance de ServerStat est ajoutée aux contrôles enfants du pnl_etud
                Outils.Instance.Dock = DockStyle.Fill;  //configure la propriété Dock de l'instance de Etudiant pour remplir tout l'espace disponible dans le pnl_etud.
                Outils.Instance.BringToFront();   //assure que le contrôle Etudiant est amené à l'avant-plan c-a-d il sera affiché au-dessus des autres contrôles du panneau
            }
            else
            {
                Outils.Instance.BringToFront();
            }
        }
    }
}