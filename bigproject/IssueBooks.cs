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
    public partial class IssueBooks : Form
    {
        public IssueBooks()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Server=DESKTOP-NP42GNC;Database=library;Trusted_Connection=True;");
        private void IssueBooks_Load(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(" select bName from NewBook", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) 
            {
                for(int i=0; i < dr.FieldCount; i++)
                {
                    cmbBooksName.Items.Add(dr.GetString(i));
                }
            }
            conn.Close();
            dr.Close();
        }
        int count;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtEnrollment.Text != "")
            {
                string eid = txtEnrollment.Text;
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from NewStudent where enroll = '" + eid + "' ";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                //----------------------------count
                cmd.CommandText = "select count(enroll) from IBook where enroll = '" + eid + "' and returndate is null";
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataSet ds1 = new DataSet();
                da.Fill(ds1);
                count = int.Parse(ds1.Tables[0].Rows[0][0].ToString());





                if (ds.Tables[0].Rows.Count != 0)
                {
                    txtStudentName.Text = ds.Tables[0].Rows[0][1].ToString();
                    txtDepartment.Text = ds.Tables[0].Rows[0][3].ToString();
                    txtSemester.Text = ds.Tables[0].Rows[0][4].ToString();
                    txtContact.Text = ds.Tables[0].Rows[0][5].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0][6].ToString();
                }
                else
                {
                    txtStudentName.Clear();
                    txtDepartment.Clear();
                    txtSemester.Clear();
                    txtContact.Clear();
                    txtEmail.Clear();
                    MessageBox.Show(" Invalid Enrollment No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                conn.Close();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtStudentName.Text != "")
            {
                if(cmbBooksName.SelectedIndex!=-1 )
                {
                    string enroll = txtEnrollment.Text;
                    string sname = txtStudentName.Text;
                    string sdep = txtDepartment.Text;
                    string sem = txtSemester.Text;
                    Int64 contact = Int64.Parse(txtContact.Text);
                    string email = txtEmail.Text;
                    string bookname = cmbBooksName.Text;
                    string bookIssueDate = dateTimePicker1.Text;
                    string eid = txtEnrollment.Text;
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    
                    cmd.CommandText = "insert into IBook (enroll,name,dep,sem,contact,email,bookname,issuedate) values ('"+enroll+ "','" + sname + "','" + sdep + "','" + sem + "','" + contact + "','" + email + "','" + bookname + "','" + bookIssueDate + "') ";
                    cmd.ExecuteNonQuery();

                    
                    MessageBox.Show(" Book Issued.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtStudentName.Clear();
                    txtDepartment.Clear();
                    txtSemester.Clear();
                    txtContact.Clear();
                    txtEmail.Clear();
                    
                }
                else
                {
                    MessageBox.Show("Select Book.", "No Book SELECTED.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                conn.Close();
            }
            else
            {
                MessageBox.Show("Enter Valid Informations", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtEnrollment_TextChanged(object sender, EventArgs e)
        {
            if (txtEnrollment.Text == "")
            {
                txtStudentName.Clear();
                txtDepartment.Clear();
                txtSemester.Clear();
                txtContact.Clear();
                txtEmail.Clear();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtEnrollment.Clear();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
            

        }
    }
}
