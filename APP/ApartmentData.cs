using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP
{
    public partial class ApartmentData : Form
    {
        public ApartmentData()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            this.Hide();
        }

        private void ApartmentData_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["Id"].FormattedValue.ToString();
        }

        private void ApartmentData_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Apartment"].ConnectionString.ToString());
                connection.Open();
                string sql = "DELETE FROM Apartments WHERE Id=" + Convert.ToInt32(textBox2.Text);
                SqlCommand command = new SqlCommand(sql, connection);
                int i = command.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Employee deleted");

                }
                dataGridView1.DataSource = GetApartmentList();
                connection.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        
        }
            private void button1_Click(object sender, EventArgs e)
        {
           
        }

            public DataTable GetApartmentList()
            {
                DataTable ap = new DataTable();
                string cs = ConfigurationManager.ConnectionStrings["Apartment"].ConnectionString;

                using (SqlConnection con = new SqlConnection(cs))
                {
                    using (SqlCommand c = new SqlCommand("select * from Apartments where Status=0 ", con))
                    {
                        con.Open();
                        SqlDataReader reader = c.ExecuteReader();
                        ap.Load(reader);
                    }

                }
                return ap;

            }
      }
    }

