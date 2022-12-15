using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace BusTicketingAndManagementSystem
{
    public partial class Home_Page : Form
    {
      //  private int nextId = 1 ;

        
        public Home_Page()
        {
            InitializeComponent();
            LoadMe();
            


        }

        private void btnPrint_Click(object sender, System.EventArgs e)
        {
            try
            {
                Connection.Connection.DB();
                Function.Function.gen = "Insert into passenger(firstName,lastName,phoneNumber,date,ticketID)values('"+txtFirstName.Text+"','"+txtLastName.Text+"','"+txtPhoneNumber.Text+"','"+DateTime.Now.ToString("yyyy-MM-dd")+ "','"+txtTicketID.Text+"')";
                Function.Function.command = new SqlCommand(Function.Function.gen, Connection.Connection.con);
                Function.Function.command.ExecuteNonQuery();
                Connection.Connection.con.Close();
                MessageBox.Show("Done", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                Connection.Connection.DB();
                Function.Function.gen = "Insert into ticket(firstName,lastName,phoneNumber,date)values('" + txtFirstName.Text + "','" + txtLastName.Text + "','" + txtPhoneNumber.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "')";
                Function.Function.command = new SqlCommand(Function.Function.gen, Connection.Connection.con);
                Function.Function.command.ExecuteNonQuery();
                Connection.Connection.con.Close();
                MessageBox.Show("Done", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void LoadMe()
        {

            // txtTextNumber.Text = String.Format("A-{0:0000}", nextId++);
           
        }



        private void Home_Page_Load(object sender, EventArgs e)
        {
           
           
        }

        private void change()
        {
            double fare, amount, change;
            double.TryParse(txtFarePrice.Text, out fare);
            double.TryParse(txtAmount.Text, out amount);

            change = amount - fare;
            if (change > 0)
                txtChange.Text = change.ToString("c".Remove(0, 1));
        }


        private void Home_Page_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'busTicketAndManagementSystemDataSetNEWEST.ticket' table. You can move, or remove it, as needed.
            this.ticketTableAdapter.Fill(this.busTicketAndManagementSystemDataSetNEWEST.ticket);

        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            change();
        }
    }
}
