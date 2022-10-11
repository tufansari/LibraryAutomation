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

namespace bigproject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Server=DESKTOP-NP42GNC;Database=library;Trusted_Connection=True;");
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUsername_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtUsername.Text == "Username")
            {
                txtUsername.Clear();
            }
        }

        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Clear();
                txtPassword.PasswordChar = '*';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(" Insert into table_login (username,pass) values (@p1,@p2)", conn);
            cmd.Parameters.AddWithValue("@p1", txtUsername.Text);
            cmd.Parameters.AddWithValue("@p2", txtPassword.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show(" Success ");
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand login = new SqlCommand("Select * from table_login where username=@p1 and pass=@p2", conn);
            login.Parameters.AddWithValue("@p1", txtUsername.Text);
            login.Parameters.AddWithValue("@p2", txtPassword.Text);
            SqlDataReader oku = login.ExecuteReader();
            if (oku.Read())
            {
                dashboard fr = new dashboard();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong username or password! ");
            }
            conn.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
