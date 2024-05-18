namespace Test_Socket
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ClientCollecte client = new ClientCollecte("127.0.0.1", 1616,5656);

            while (true)
            {
                client.
                    CollectAndSendData();
                Thread.Sleep(5000); // Attendre 5 secondes entre chaque envoi de données
            }
        }
    }
}