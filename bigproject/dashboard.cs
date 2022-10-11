using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bigproject
{
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }

        private void addBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddBook fr = new AddBook();
            fr.Show();
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are You Sure Want to EXIT?","Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
            
        }

        private void viewBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewBook fr = new ViewBook();
            fr.Show();
        }

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudent fr = new AddStudent();
            fr.Show();
        }

        private void studentViewİnfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentInformation fr = new StudentInformation();
            fr.Show();
        }

        private void issueBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IssueBooks fr = new IssueBooks();
            fr.Show();
        }

        private void returnBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReturnBook fr = new ReturnBook();
            fr.Show();
        }

        private void completeBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompleteBookDetails fr = new CompleteBookDetails();
            fr.Show();
        }

        private void dashboard_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
