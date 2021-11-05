using Entity;
using Repositories;
using Services;
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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }
        void UpdateGridView()
        {
            ApartmentService aps = new ApartmentService();
            dataGridView1.DataSource = aps.GetAllApartments();
        }

        public DataTable GetSearchedList()
        {
            DataTable owner = new DataTable();
            string cs = ConfigurationManager.ConnectionStrings["Apartment"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand c = new SqlCommand("select * from Apartments where Area='"+area.Text+"'and Bedroom="+comboBox1.Text+"and Rent<"+rent.Text, con))
                {
                    con.Open();
                    SqlDataReader reader = c.ExecuteReader();
                    owner.Load(reader);
                }

            }
            return owner;

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (area.Text == string.Empty || rent.Text == string.Empty || comboBox1.Text == string.Empty)
            {
                MessageBox.Show("Input search strings correctly");
            }

            else
            {
                 this.dataGridView1.DataSource = GetSearchedList();

            }

        }

        private void Customer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

       private void Customer_Load(object sender, EventArgs e)
        
        {
            ApartmentService aps = new ApartmentService();
            dataGridView1.DataSource = aps.GetAllApartments();

            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Apartment"].ConnectionString.ToString());
            string sql = "Select * from Credentials where UserName=" + Global.UserName;
            SqlCommand command = new SqlCommand(sql, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                     int id = (int)reader["UserId"];
                    textBoxUid.Text = id.ToString();
                }
                reader.Close();

            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            // textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["UserName"].FormattedValue.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["Id"].FormattedValue.ToString();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Apartment"].ConnectionString.ToString());
                connection.Open();
                string sql = "UPDATE Apartments SET Status=" + 1 + ", Customer_id=" + Convert.ToInt32(textBoxUid.Text) + " where Id=" + Convert.ToInt32(textBox1.Text);
                SqlCommand command = new SqlCommand(sql, connection);
                int i = command.ExecuteNonQuery();
                if (i > 0)
                {

                    MessageBox.Show("Apartment Requested");
                    UpdateGridView();
                }
                connection.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            UpdateGridView();
            area.Text =  rent.Text = comboBox1.Text = string.Empty;

        }
    }
}
