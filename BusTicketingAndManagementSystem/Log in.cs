using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BusTicketingAndManagementSystem
{
    public partial class Form1 : Form
    {
        public static string setfirstname = "";
        public static string setlastname = "";
        public static int setuserID = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void txtUsername_MouseClick(object sender, MouseEventArgs e)
        {
            txtUsername.Text = " ";
        }

        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            txtPassword.Text = "";
        }

        private void LLabelAdmin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var home = new AdminHomePage();
            home.Show();
            Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var home = new Home_Page();
            

            int roleID;
            try
            {
                Connection.Connection.DB();
                Function.Function.gen = "SELECT * FROM users WHERE username = '"+txtUsername.Text +"'AND password = '"+ txtPassword.Text + "' ";
                Function.Function.command = new SqlCommand(Function.Function.gen,Connection.Connection.con);
                Function.Function.reader = Function.Function.command.ExecuteReader();

                if (Function.Function.reader.HasRows)
                {
                    Function.Function.reader.Read();
                    roleID = Convert.ToInt32(Function.Function.reader["roleID"]);

                    if(roleID == 1)
                    {
                        txtUsername.Text = Function.Function.reader["username"].ToString();
                        txtPassword.Text = Function.Function.reader["password"].ToString();

                        setfirstname = Function.Function.reader["firstName"].ToString();
                        setlastname = Function.Function.reader["lastName"].ToString();
                        setuserID = Convert.ToInt32(Function.Function.reader["userID"]);

                        home.Show();
                        Hide();
                     }
                    else if(roleID == 2)
                    {
                        txtUsername.Text = Function.Function.reader["username"].ToString();
                        txtPassword.Text = Function.Function.reader["password"].ToString();

                        setfirstname = Function.Function.reader["firstName"].ToString();
                        setlastname = Function.Function.reader["lastName"].ToString();

                        home.Show();
                        Hide();
                    }
                }
                else 
                {
                    MessageBox.Show("Incorrect username or password", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
