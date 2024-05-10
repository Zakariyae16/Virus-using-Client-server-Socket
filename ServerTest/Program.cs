using System.Data.SqlClient;

namespace ServerTest
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

        public static SqlConnection GetSqlConnection()
        {
            SqlConnection cnx;
            cnx = new SqlConnection(@"SERVER=.\SQLEXPRESS ; DATABASE = Socketdb2;INTEGRATED SECURITY=TRUE");
            return cnx;
        }
    }
}