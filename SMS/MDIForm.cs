using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMS
{
    public partial class MDIForm : Form
    {
        public MDIForm()
        {

            InitializeComponent();
            AddUser au = new AddUser();

            au.Show();
            au.MdiParent = this;
            
        }

        private void addRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
            
            AddUser au = new AddUser();
    
            au.Show();
            au.MdiParent = this;
        }

        private void courToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addCoursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
            AddCourse au = new AddCourse();

            au.Show();
            au.MdiParent = this;
            au.StartPosition = FormStartPosition.CenterParent;

        }

        private void addBatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
            AddBatch au = new AddBatch();

            au.Show();
            au.MdiParent = this;
        }

        private void addCollegeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
            AddCollege au = new AddCollege();

            au.Show();
            au.MdiParent = this;
        }

        private void cpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
          coursemapping au = new coursemapping();

            au.Show();
            au.MdiParent = this;

        }

        private void bpToolStripMenuItem_Click(object sender, EventArgs e)
        {

            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
          batchcoursemapping au = new batchcoursemapping();

            au.Show();
            au.MdiParent = this;
        }

        private void feeBatchToolStripMenuItem_Click(object sender, EventArgs e)
        {

            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
           fee_batch au = new fee_batch();

            au.Show();
            au.MdiParent = this;
        }

        private void feeCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {

            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
            fee_collection au = new fee_collection();

            au.Show();
            au.MdiParent = this;
        }

        private void expensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
           expenses au = new expenses();

            au.Show();
            au.MdiParent = this;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
            AddFaculty au = new AddFaculty();

            au.Show();
            au.MdiParent = this;
        }

        private void defaulterListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
            Defaulter_Listcs au = new Defaulter_Listcs();

            au.Show();
            au.MdiParent = this;
        }

        private void searchRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
           Search_Record au = new Search_Record();

            au.Show();
            au.MdiParent = this;

        }

        private void collectionDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
         Faculty_Collection au = new Faculty_Collection();

            au.Show();
            au.MdiParent = this;
        }

        private void manageBatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
           Batch_details au = new Batch_details();

            au.Show();
            au.MdiParent = this;
        }

        private void viewExpensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        Display_Expenses au = new Display_Expenses();

            au.Show();
            au.MdiParent = this;
        }

       

       
    }
}
