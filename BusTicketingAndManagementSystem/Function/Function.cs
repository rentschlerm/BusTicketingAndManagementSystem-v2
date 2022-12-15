using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace BusTicketingAndManagementSystem.Function
{
    internal class Function
    {
        public static string gen = " "; //varible to hold SQL statements
        public static SqlConnection con; 
        public static SqlCommand command; //process the SQL statements and connection
        public static SqlDataReader reader; //retrieve data frin the database

        public static void fill(string q, DataGridView dgv)
        {
            try
            {
                Connection.Connection.DB();
                DataTable dt = new DataTable();
                SqlDataAdapter data = null;
                SqlCommand command = new SqlCommand(q, Connection.Connection.con);
                data = new SqlDataAdapter(command);
                data.Fill(dt);
                dgv.DataSource = dt;
                Connection.Connection.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
