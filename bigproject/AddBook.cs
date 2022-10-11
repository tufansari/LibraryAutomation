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
    public partial class AddBook : Form
    {
        public AddBook()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Server=DESKTOP-NP42GNC;Database=library;Trusted_Connection=True;");
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtBookName.Text != "" && txtAuthor.Text != "" && txtPublication.Text != "" && txtBookPrice.Text != "" && txtQuantity.Text != "")
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(" Insert into NewBook (bName,bAuthor,bPubl,bPDate,bPrice,bQuan) values (@p1,@p2,@p3,@p4,@p5,@p6)", conn);
                cmd.Parameters.AddWithValue("@p1", txtBookName.Text);
                cmd.Parameters.AddWithValue("@p2", txtAuthor.Text);
                cmd.Parameters.AddWithValue("@p3", txtPublication.Text);
                cmd.Parameters.AddWithValue("@p4", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@p5", txtBookPrice.Text);
                cmd.Parameters.AddWithValue("@p6", txtQuantity.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Saved.", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBookName.Clear();
                txtAuthor.Clear();
                txtPublication.Clear();
                txtBookPrice.Clear();
                txtQuantity.Clear();
            }
            else
            {
                MessageBox.Show("Empty Field Not Allowed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            conn.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("This will DELETE your Unsave DATA","Are You Sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
            
        }
    }
}
