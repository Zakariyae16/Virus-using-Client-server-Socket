using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheArtOfDevHtmlRenderer.Adapters;
using static System.Windows.Forms.AxHost;

namespace ServerTest
{
    public partial class viewData : UserControl
    {
        private static viewData view;

        SqlConnection cnx;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        BindingManagerBase bindingManager;
        System.Data.DataTable dataTable;
        private DataView dataView;
        private int idPhoto;
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
                cnx = Program.GetSqlConnection();
                cnx.Open();
                adapter = new SqlDataAdapter("SELECT * FROM receivedData1", cnx);
                dataTable = new System.Data.DataTable();


                // Remplir le DataTable avec les données de la base de données
                adapter.Fill(dataTable);

                //Renommer les colonnes dans le DataTable(remplacement des noms)
                dataTable.Columns[0].ColumnName = "ID";
                dataTable.Columns[1].ColumnName = "Client ID";
                dataTable.Columns[2].ColumnName = "Hardware";
                dataTable.Columns[3].ColumnName = "Capture D'ecran";
                dataTable.Columns[4].ColumnName = "Camera";
                dataTable.Columns[5].ColumnName = "Time";

                // Lier le DataTable au DataGridView
                data_dgv.DataSource = dataTable;
                cnx.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des données : " + ex.Message);
            }


            data_dgv.Refresh();





            string selectQuery = "SELECT captureData FROM receivedData1 WHERE captureData = 3";

            // Création de la connexion à la base de données
            using (cnx = Program.GetSqlConnection())
            {
                cnx.Open();

                // Création de la commande SQL
                using (cmd = new SqlCommand(selectQuery, cnx))
                {
                    // Paramètre pour l'ID
                    //cmd.Parameters.AddWithValue("@Id_livre", idPhoto);

                    // Exécution de la commande et récupération du résultat
                    using (reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Vérification si la colonne ImageColumn n'est pas NULL
                            if (!reader.IsDBNull(0))
                            {
                                // Récupération des données binaires de l'image
                                byte[] imageBytes = (byte[])reader[0];

                                // Conversion des données binaires en image
                                Image image = ByteArrayToImage(imageBytes);

                                // Affichage de l'image dans un PictureBox
                                imgbox.Image = image;
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

        private void data_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Sélectionner toute la ligne
                data_dgv.Rows[e.RowIndex].Selected = true;
            }
            // Assurez-vous que la cellule cliquée est dans la colonne de CheckBox
            if (e.ColumnIndex == data_dgv.Columns[0].Index && e.RowIndex >= 0)
            {
                // Décochez toutes les autres cases à cocher dans la colonne
                foreach (DataGridViewRow row in data_dgv.Rows)
                {
                    DataGridViewCheckBoxCell checkBoxCell = row.Cells[0] as DataGridViewCheckBoxCell;

                    // Décochez les autres cases à cocher
                    if (row.Index != e.RowIndex)
                    {
                        checkBoxCell.Value = false;
                    }
                }
            }

            string selectQuery = "SELECT captureData FROM receivedData1 WHERE captureData = @idPhoto";

            // Création de la connexion à la base de données
            using (cnx = Program.GetSqlConnection())
            {
                cnx.Open();

                // Création de la commande SQL
                using (cmd = new SqlCommand(selectQuery, cnx))
                {
                    // Paramètre pour l'ID
                    cmd.Parameters.AddWithValue("@Id_livre", idPhoto);

                    // Exécution de la commande et récupération du résultat
                    using (reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Vérification si la colonne ImageColumn n'est pas NULL
                            if (!reader.IsDBNull(0))
                            {
                                // Récupération des données binaires de l'image
                                byte[] imageBytes = (byte[])reader[0];

                                // Conversion des données binaires en image
                                Image image = ByteArrayToImage(imageBytes);

                                // Affichage de l'image dans un PictureBox
                                imgbox.Image = image;
                            }
                        }
                    }
                }
            }
        }

        private Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }
    }
}
