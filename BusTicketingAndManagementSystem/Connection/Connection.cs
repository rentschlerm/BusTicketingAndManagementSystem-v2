using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace BusTicketingAndManagementSystem.Connection
{
    internal class Connection
    {
        public static SqlConnection con;
        public static String dbconnect = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\dboy\\BusTicketingAndManagementSystem\\BusTicketingAndManagementSystem\\BusTicketAndManagementSystem.mdf;Integrated Security=True"; //Connection String

        public static void DB()
        {
            try
            {
                con = new SqlConnection(dbconnect);
                con.Open();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }
    }
}
