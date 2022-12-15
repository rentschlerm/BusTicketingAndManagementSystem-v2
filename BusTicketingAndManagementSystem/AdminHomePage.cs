using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BusTicketingAndManagementSystem
{
    public partial class AdminHomePage : Form
    {
        
        
        public AdminHomePage()
        {
            InitializeComponent();
            hide();
        }
        public void hide()
        {
            PassengerRecordsPanel.Visible = false;
            SalesPanel.Visible = false;
            registrationPanel.Visible = false;
        }
        

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var logout = new Form1();
            this.Close();
            logout.Show();
        }

        private void btnRecords_Click(object sender, EventArgs e)
        {
            hide();
            PassengerRecordsPanel.Visible = true;
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            hide();
            SalesPanel.Visible = true;
            
        }

        private void AdminHomePage_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'busTicketAndManagementSystemDataSetNEWEST.users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.busTicketAndManagementSystemDataSetNEWEST.users);
            // TODO: This line of code loads data into the 'busTicketAndManagementSystemDataSetNEWEST.passenger' table. You can move, or remove it, as needed.
            this.passengerTableAdapter.Fill(this.busTicketAndManagementSystemDataSetNEWEST.passenger);
            // TODO: This line of code loads data into the 'busTicketAndManagementSystemDataSet.passenger' table. You can move, or remove it, as needed.
            this.passengerTableAdapter2.Fill(this.busTicketAndManagementSystemDataSet.passenger);
            fillData();
        }
        public void fillData()
        {
            Function.Function.gen = "SELECT        passenger.passengerID, ticket.fareprice, passenger.ticketID\r\nFROM            passenger INNER JOIN\r\n                         ticket ON passenger.ticketID = ticket.ticketID\r\nWHERE        (passenger.ticketID IN (1, 2, 3))";
            Function.Function.fill(Function.Function.gen, dgvSales);
        }
        public void fillData2()
        {
            Function.Function.gen = "Select * from users";
            Function.Function.fill(Function.Function.gen,dgvRegister);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            hide();
            fillData2();
            registrationPanel.Visible = true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.Connection.DB();
                Function.Function.gen = "Insert into users values ('"+txtFirstName.Text + "','"+txtLastName.Text + "','"+txtContact.Text + "','"+txtUsername.Text + "','"+txtPassword.Text +"','"+ DateTime.Now.ToString("yyyy-MM-dd") + "','"+cmbRole.Text +"')";
                Function.Function.command = new SqlCommand(Function.Function.gen, Connection.Connection.con);
                Function.Function.command.ExecuteNonQuery();
                MessageBox.Show("You can now log in with your account", "Login", MessageBoxButtons.OK);
                Connection.Connection.con.Close();

                fillData2();


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtFirstName_Enter(object sender, EventArgs e)
        {
            txtFirstName.Text = " ";
        }

        private void txtLastName_Enter(object sender, EventArgs e)
        {
            txtLastName.Text = " ";
        }

        private void txtContact_Enter(object sender, EventArgs e)
        {
            txtContact.Text = " ";
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            txtUsername.Text = " ";
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            txtPassword.Text = " ";
        }
    }
}
