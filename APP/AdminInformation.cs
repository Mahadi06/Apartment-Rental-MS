using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using System.Configuration;
using System.Data.SqlClient;

namespace APP
{
    public partial class AdminInformation : Form
    {
        public AdminInformation()
        {
            InitializeComponent();
        }
        public DataTable GetOwnerList()
        {
            DataTable owner = new DataTable();
            string cs = ConfigurationManager.ConnectionStrings["Apartment"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand c = new SqlCommand("select Users.Name,Credentials.UserName,Credentials.UserId,Users.Email,Users.Phone_No,Credentials.Password from Users,Credentials where UserType=1 and Users.Id=Credentials.UserId", con))
                {
                    con.Open();
                    SqlDataReader reader = c.ExecuteReader();
                    owner.Load(reader);
                }

            }
            return owner;

        }
        

        
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Admin a1 = new Admin();
            a1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            AdminService registration = new AdminService();
            int usertype = 1;
            string password = "admin";
            

            int result = registration.AdminRegistration(textBoxName.Text, textBoxEmail.Text, textBoxContact.Text, textBoxUname.Text, password, usertype);
            if (result > 0)
            {
                MessageBox.Show("Admin Added");
               textBoxUname.Text= textBoxName.Text = textBoxEmail.Text = textBoxContact.Text = string.Empty;
                dataGridView1.DataSource = GetOwnerList();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void AdminInformation_Load(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = GetOwnerList();
        }

        private void AdminInformation_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Apartment"].ConnectionString.ToString());
                connection.Open();
                string sql = "DELETE FROM Users WHERE Id=" + Convert.ToInt32(textBox8.Text);
                SqlCommand command = new SqlCommand(sql, connection);
                int i = command.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Admin deleted");
                    this.dataGridView1.DataSource = GetOwnerList();
                   

                }
                connection.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells["UserId"].FormattedValue.ToString();
        }
        }
    }

