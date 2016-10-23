using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

using System.Reflection;



namespace SMS
{
    public partial class Defaulter_Listcs : Form
    {
       public static string defaulter_fee_report;
      MySqlConnection cn;
     
      private class Item
      {
          public string Name;
          public string Value;
          public Item(string name, string value)
          {
              Name = name; Value = value;
          }
          public override string ToString()
          {
              // Generates the text shown in the combo box
              return Name;
          }
      }
      
        void clear()
        {
            this.dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();


        }
        public string GetConnectionString()
        {
            return "Data Source=localhost; Initial Catalog=eschool;User Id=root;Password=india@123";
        }
        void fill_batch()
        {
            Logic.return_unique_no retuu = new Logic.return_unique_no();
            int temp = 0;

            try
            {
                string q = "select bid,bname,cid from batches ";
                MySqlCommand cmd = new MySqlCommand(q, cn);

                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temp++;

                    comboBox1.Items.Add(new Item(dr[1].ToString() + " - " + retuu.return_course_name(Int32.Parse( dr[2].ToString())), dr[0].ToString() ));

                }
                if (temp != 0)
                {

                    comboBox1.SelectedIndex = 0;
                }
                dr.Close();
                cmd.Dispose();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }



       


        }


        void del()
        {
            bool Empty = true;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                Empty = true;
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value != null && dataGridView1.Rows[i].Cells[j].Value.ToString() != "")
                    {
                        Empty = false;
                       
                    }
                }
                if (Empty)
                {
                    dataGridView1.Rows.RemoveAt(i);
                }
            }

        }
        void fill_grid()
        {
              Item itm = (Item)comboBox1.SelectedItem;

              Logic.defauter_fetch fetch = new Logic.defauter_fetch();
            string conString = "Data Source=localhost; Initial Catalog=eschool;User Id=root;Password=india@123";
            MySqlConnection con = new MySqlConnection(conString);

            MySqlDataAdapter sda = new MySqlDataAdapter("select  a.uid,a.fname,a.cno,b.id AS batch_mapping_id from users a,batchcourseusermapping b , courseusermapping c where (a.uid=c.userid and c.id=b.cumid) and b.bid=" + itm.Value.ToString() + "", con);
               
                 DataTable dt = new DataTable();
            sda.Fill(dt);
            int tt = 0,n=0;
            foreach (DataRow item in dt.Rows)

            {     
          

                n = dataGridView1.Rows.Add();

                long l =fetch.calculate_(item[3].ToString());

                if (checkBox1.Checked == false)
                {

                    dataGridView1.Rows[n].Cells[0].Value = item["uid"].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item["fname"].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = item["cno"].ToString().Replace(",", ";");
                    if (l > 0) { dataGridView1.Rows[n].Cells[3].Style.ForeColor = Color.IndianRed; }
                    else
                    {
                        dataGridView1.Rows[n].Cells[3].Style.ForeColor = Color.Green;

                    }
                    dataGridView1.Rows[n].Cells[3].Value = l;

                    dataGridView1.Rows[n].Cells[4].Value = item[3].ToString();
                }
                else if (checkBox1.Checked == true&& l>0)
                {
                    tt++;

                    dataGridView1.Rows[n].Cells[0].Value = item["uid"].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item["fname"].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = item["cno"].ToString().Replace(",",";");
                     dataGridView1.Rows[n].Cells[3].Style.ForeColor = Color.IndianRed; 
                  
                    dataGridView1.Rows[n].Cells[3].Value = l;

                    dataGridView1.Rows[n].Cells[4].Value = item[3].ToString();
                }

                }
            if (checkBox1.Checked == true )
            {
                for (int i = n - tt; i >= 0;i-- ){
             
                    del();}
            }
               
        }

        public Defaulter_Listcs()
        {
         
            InitializeComponent();
            if (cn == null)
            {
                cn = new MySqlConnection();
                cn.ConnectionString = GetConnectionString();
                cn.Open();

             
            }

            fill_batch();
        }

        private void change_me(object sender, EventArgs e)
        {

            clear();
            fill_grid();
            checkBox1.Checked = false;
        }

        private void click_on_header(object sender, DataGridViewCellMouseEventArgs e)
        {
            defaulter_fee_report = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + " - " + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() + " - " + dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

            Defaulter_list_fee_report repo = new Defaulter_list_fee_report();
            repo.ShowDialog();

        }

        private void chamge(object sender, EventArgs e)
        {


            clear();
            fill_grid();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Microsoft.Office.Interop.Excel.Application objexcelapp = new Microsoft.Office.Interop.Excel.Application();
            objexcelapp.Application.Workbooks.Add(Type.Missing);
            objexcelapp.Columns.ColumnWidth = 25;
            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                objexcelapp.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }
            /*For storing Each row and column value to excel sheet*/
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                    {
                        objexcelapp.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            Item itm = (Item)comboBox1.SelectedItem;
           
            objexcelapp.ActiveWorkbook.SaveCopyAs("D:\\" + itm.Name+"-  "+DateTime.Now.ToShortDateString()+".xlsx");
            objexcelapp.ActiveWorkbook.Saved = true;
            MessageBox.Show("Your excel file exported successfully at C:\\" + itm.Name+"-  "+DateTime.Now.ToShortDateString()+ ".xlsx");
        }

    }
}