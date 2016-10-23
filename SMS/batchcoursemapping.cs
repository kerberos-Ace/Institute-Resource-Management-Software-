using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace SMS
{
    public partial class batchcoursemapping : Form
    {
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
        void fill_cid()
        {
            int temp = 0;

            try
            {
                string q = "select bid,bname,cid from batches ";
                MySqlCommand cmd = new MySqlCommand(q, cn);

                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temp++;
                   
                    comboBox1.Items.Add(new Item(dr[1].ToString(), dr[0].ToString() + " - " + dr[2].ToString()));

                }
                if (temp != 0) {

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
        public batchcoursemapping()
        {
            InitializeComponent();
            if (cn == null)
            {
                cn = new MySqlConnection();
                cn.ConnectionString = GetConnectionString();
                cn.Open();
              
              //  this.BindGrid();
            }

            fill_cid();
            pictureBox1.ImageLocation = AppDomain.CurrentDomain.BaseDirectory + "images\\dum.jpg";
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
        private void BindGrid(string bbid)
        {

            Logic.return_unique_no check_status = new Logic.return_unique_no();
            string conString = "Data Source=localhost; Initial Catalog=eschool;User Id=root;Password=india@123";
           
               MySqlDataAdapter sda = new MySqlDataAdapter("select  a.uid,a.fname,a.college,a.sem,c.id from users a,batches b , courseusermapping c where (a.uid=c.userid and c.cid=b.cid) and b.bid="+bbid, conString);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow item in dt.Rows)

            {     
            if (check_status.check_status(Int32.Parse(bbid),Int32.Parse( item["id"].ToString())) == 0)
            {
                

                int n = dataGridView1.Rows.Add();
                
                

                    dataGridView1.Rows[n].Cells[0].Value = item["uid"].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item["id"].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = item["fname"].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = item["college"].ToString();
                    dataGridView1.Rows[n].Cells[4].Value = item["sem"].ToString();
                    dataGridView1.Rows[n].Cells[5].Value = "false";

                }

            }
        }
       
        private void onselectbatch(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1) {
                Item itm = (Item)comboBox1.SelectedItem;
                var c = itm.Value.ToString().Split('-');
                clear();
                this.BindGrid(c.First());
            Logic.return_unique_no course_mname =new Logic.return_unique_no();
            label3.Text=course_mname.return_course_name(Int32.Parse( c.Last().ToString()));
            } else{

                label3.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                Item itm = (Item)comboBox1.SelectedItem;

                var cid_tem = itm.Value.ToString().Split('-');
                string dsate = DateTime.Now.ToString("yyyy-MM-dd ");
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    if (bool.Parse(item.Cells[5].Value.ToString()))
                    {

                        String q = "insert into batchcourseusermapping(bid,doa,cumid) values(?bid,?doa,?cumid) ";
                        MySqlCommand cmd = new MySqlCommand(q, cn);
                        MySqlParameter p1 = new MySqlParameter("bid", cid_tem.First());
                        MySqlParameter p2 = new MySqlParameter("doa", dsate);
                        MySqlParameter p3 = new MySqlParameter("cumid", item.Cells[1].Value.ToString());


                        cmd.Parameters.Add(p1);

                        cmd.Parameters.Add(p2);
                        cmd.Parameters.Add(p3);

                        cmd.ExecuteNonQuery();
                        cmd.Dispose();

                    }

                }
                MessageBox.Show("Data Saved");
                clear();
                this.BindGrid(cid_tem.First());
            }
            else {

                MessageBox.Show("Select Batch");
            
            
            }
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {


                item.Cells[5].Value = item.Cells[5].Value == null ? false : true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {


                item.Cells[5].Value = item.Cells[5].Value == null ? true : false;
            }
        }

        private void rowheader(object sender, DataGridViewCellMouseEventArgs e)
        {
            String id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();

            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "images\\" + id + ".jpg") == false)
            {

                pictureBox1.ImageLocation = AppDomain.CurrentDomain.BaseDirectory + "images\\dum.jpg";



            }
            else
            {

                pictureBox1.ImageLocation = AppDomain.CurrentDomain.BaseDirectory + "images\\" + id + ".jpg";



            }
        }
    }

}