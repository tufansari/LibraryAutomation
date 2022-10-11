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
    public partial class ViewBook : Form
    {
        public ViewBook()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Server=DESKTOP-NP42GNC;Database=library;Trusted_Connection=True;");
        private void ViewBook_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
           
            
        }
        int rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel2.Visible = true;
            
            int bid = dataGridView1.SelectedCells[0].RowIndex;
            txtBookName.Text = dataGridView1.Rows[bid].Cells[1].Value.ToString();
            txtAuthor.Text = dataGridView1.Rows[bid].Cells[2].Value.ToString();
            txtPubl.Text = dataGridView1.Rows[bid].Cells[3].Value.ToString();
            txtPDate.Text = dataGridView1.Rows[bid].Cells[4].Value.ToString();
            txtPrice.Text = dataGridView1.Rows[bid].Cells[5].Value.ToString();
            txtQuantity.Text = dataGridView1.Rows[bid].Cells[6].Value.ToString();
            rowid = int.Parse(dataGridView1.Rows[bid].Cells[0].Value.ToString());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void txtBookResearch_TextChanged(object sender, EventArgs e)
        {
            if (txtBookResearch.Text != "")
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * from NewBook where bName LIKE '"+txtBookResearch.Text+"%' ",conn);      
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                conn.Close();
            }
            else
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * from NewBook ", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                conn.Close();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtBookResearch.Clear();
            panel2.Visible = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Data will be updated.Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Update NewBook set bName=@p1,bAuthor=@p2,bPubl=@p3,bPDate=@p4,bPrice=@p5,bQuan=@p6 where bid=" + rowid + " ", conn);
                cmd.Parameters.AddWithValue("@p1", txtBookName.Text);
                cmd.Parameters.AddWithValue("@p2", txtAuthor.Text);
                cmd.Parameters.AddWithValue("@p3", txtPubl.Text);
                cmd.Parameters.AddWithValue("@p4", txtPDate.Text);
                cmd.Parameters.AddWithValue("@p5", txtPrice.Text);
                cmd.Parameters.AddWithValue("@p6", txtQuantity.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            this.newBookTableAdapter.Fill(this.libraryDataSet1.NewBook);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will Deleted.Confirm?", "Confirmation Dialog", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Delete from NewBook where bid="+rowid+" ", conn);               
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
