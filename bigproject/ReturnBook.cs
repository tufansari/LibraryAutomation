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
    public partial class ReturnBook : Form
    {
        public ReturnBook()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Server=DESKTOP-NP42GNC;Database=library;Trusted_Connection=True;");
        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from IBook where enroll='" + txtEnrollment.Text + "' and returndate IS NULL",conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Invalid ID or No Book Issued", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();

        }

        private void ReturnBook_Load(object sender, EventArgs e)
        {
            

            panel3.Visible = false;
            txtEnrollment.Clear();
            

        }
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           


        }
        //KİTABI GEÇ TESLİM
        int a;
        int b;
        private void btnReturn_Click(object sender, EventArgs e)
        {
            DateTime bugün = DateTime.Today;
            DateTime alınan = dateTimePicker2.Value;
            TimeSpan fark = new TimeSpan();
            fark = bugün - alınan;
            a = dateTimePicker1.Value.Day;
            b = dateTimePicker2.Value.Day;

            conn.Open();
            SqlCommand cmd = new SqlCommand("update IBook set returndate='" + dateTimePicker1.Text + "' where enroll='" + txtEnrollment.Text + "' and id='" + rowid1 + "' ", conn);
            cmd.ExecuteNonQuery();
            if (fark.Days > 15)
            {
                //-15'e dikkat.
                MessageBox.Show(""+ ((a-b)-(15))*5 + "$ have to pay"  );
                
            }
            else
            {
                MessageBox.Show(" Return Succesful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            
            
            conn.Close();
                                               
        }   

        private void txtEnrollment_TextChanged(object sender, EventArgs e)
        {
            if (txtEnrollment.Text == "")
            {
                panel3.Visible = false;
                dataGridView1.DataSource = null;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtEnrollment.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }
        int rowid1;
        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            panel3.Visible = true;
            int id = dataGridView1.SelectedCells[0].RowIndex;
            txtBookName.Text = dataGridView1.Rows[id].Cells[7].Value.ToString();
            dateTimePicker2.Text = dataGridView1.Rows[id].Cells[8].Value.ToString();
            rowid1 = int.Parse(dataGridView1.Rows[id].Cells[0].Value.ToString());
        }
    }
}
