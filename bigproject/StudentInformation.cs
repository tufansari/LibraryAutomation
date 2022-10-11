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
    public partial class StudentInformation : Form
    {
        public StudentInformation()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Server=DESKTOP-NP42GNC;Database=library;Trusted_Connection=True;");
        private void StudentInformation_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            this.newStudentTableAdapter.Fill(this.libraryDataSet2.NewStudent);
            
        }

        private void txtEnrollmentNo_TextChanged(object sender, EventArgs e)
        {
            if (txtEnrollmentNo.Text != "")
            {
                Image image = Image.FromFile("C:\\Users\\tufan.sari\\Desktop\\search1.gif");
                pictureBox1.Image = image;
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * from NewStudent where enroll LIKE '" + txtEnrollmentNo.Text + "%' ", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                conn.Close();
            }
            else
            {
                Image image = Image.FromFile("C:\\Users\\tufan.sari\\Desktop\\search.gif");
                pictureBox1.Image = image;
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * from NewStudent ", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                conn.Close();
            }
        }
        //TextBox'a ID yazmaya gerek olmadan işlem yapma.ID'yi değişkene atayıp DML sorgularına değişkenle devam edicem.
        int rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel2.Visible = true;

            int bid = dataGridView1.SelectedCells[0].RowIndex;
            txtStudentName.Text = dataGridView1.Rows[bid].Cells[1].Value.ToString();
            txtEnrollment.Text = dataGridView1.Rows[bid].Cells[2].Value.ToString();
            txtDepartment.Text = dataGridView1.Rows[bid].Cells[3].Value.ToString();
            txtSemester.Text = dataGridView1.Rows[bid].Cells[4].Value.ToString();
            txtContact.Text = dataGridView1.Rows[bid].Cells[5].Value.ToString();
            txtEmail.Text = dataGridView1.Rows[bid].Cells[6].Value.ToString();
            rowid = int.Parse(dataGridView1.Rows[bid].Cells[0].Value.ToString());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Unsaved Data Will be Lost","Are You Sure", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
            
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            this.newStudentTableAdapter.Fill(this.libraryDataSet2.NewStudent);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be updated.Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Update NewStudent set sName=@p1,enroll=@p2,dep=@p3,sem=@p4,contact=@p5,email=@p6 where studid=" + rowid + " ", conn);
                cmd.Parameters.AddWithValue("@p1", txtStudentName.Text);
                cmd.Parameters.AddWithValue("@p2", txtEnrollment.Text);
                cmd.Parameters.AddWithValue("@p3", txtDepartment.Text);
                cmd.Parameters.AddWithValue("@p4", txtSemester.Text);
                cmd.Parameters.AddWithValue("@p5", txtContact.Text);
                cmd.Parameters.AddWithValue("@p6", txtEmail.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtEnrollmentNo.Clear();
            panel2.Visible = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will Deleted.Confirm?", "Confirmation Dialog", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Delete from NewStudent where studid=" + rowid + " ", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
