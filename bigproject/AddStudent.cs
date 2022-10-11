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
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Server=DESKTOP-NP42GNC;Database=library;Trusted_Connection=True;");
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm?", "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtStudentName.Clear();
            txtEnrollment.Clear();
            txtDepartment.Clear();
            txtSemester.Clear();
            txtContact.Clear();
            txtEmail.Text = " ";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtStudentName.Text != "" && txtEnrollment.Text != "" && txtDepartment.Text != "" && txtSemester.Text != "" && txtContact.Text != "" && txtEmail.Text != "")
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(" Insert into NewStudent (sName,enroll,dep,sem,contact,email) values (@p1,@p2,@p3,@p4,@p5,@p6)", conn);
                cmd.Parameters.AddWithValue("@p1", txtStudentName.Text);
                cmd.Parameters.AddWithValue("@p2", txtEnrollment.Text);
                cmd.Parameters.AddWithValue("@p3", txtDepartment.Text);
                cmd.Parameters.AddWithValue("@p4", txtSemester.Text);
                cmd.Parameters.AddWithValue("@p5", txtContact.Text);
                cmd.Parameters.AddWithValue("@p6", txtEmail.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Saved.", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtStudentName.Clear();
                txtEnrollment.Clear();
                txtDepartment.Clear();
                txtSemester.Clear();
                txtContact.Clear();
                txtEmail.Clear();
                conn.Close();
            }
            else
            {
                MessageBox.Show("Empty Field Not Allowed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
    }
}
