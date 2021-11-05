using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace APP
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }


        public DataTable GetOwnerList()
        {
            DataTable owner = new DataTable();
            string cs = ConfigurationManager.ConnectionStrings["Apartment"].ConnectionString;

            using(SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand c = new SqlCommand("select Users.Name,Users.Id,Credentials.UserName,Users.Email,Users.Phone_No,Credentials.Password from Users,Credentials where UserType=3 and Users.Id=Credentials.UserId", con))
                    
                { 
                         con.Open();
                         SqlDataReader reader = c.ExecuteReader();
                         owner.Load(reader);
                }
                
            }
            return owner;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AdminInformation ai1 = new AdminInformation();
            ai1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewData vd = new ViewData();
            vd.Show();
            vd.dataGridView1.DataSource = GetCustomerList();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewData vd = new ViewData();
            this.Hide();
            vd.Show();
            vd.dataGridView1.DataSource = GetOwnerList();
        }
        public DataTable GetCustomerList()
        {
            DataTable customer = new DataTable();
            string cs = ConfigurationManager.ConnectionStrings["Apartment"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand c = new SqlCommand("select Users.Name,Users.Id,Credentials.UserName,Users.Email,Users.Phone_No,Credentials.Password from Users,Credentials where UserType=2 and Users.Id=Credentials.UserId", con))
                {
                    con.Open();
                    SqlDataReader reader = c.ExecuteReader();
                    customer.Load(reader);
                }

            }
            return customer;

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        public DataTable GetApartmentList()
        {
            DataTable ap = new DataTable();
            string cs = ConfigurationManager.ConnectionStrings["Apartment"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand c = new SqlCommand("select * from Apartments  ", con))
                {
                    con.Open();
                    SqlDataReader reader = c.ExecuteReader();
                    ap.Load(reader);
                }

            }
            return ap;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ApartmentData ad = new ApartmentData();
            this.Hide();
            ad.Show();
            ad.dataGridView1.DataSource = GetApartmentList();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

       
    }
}
