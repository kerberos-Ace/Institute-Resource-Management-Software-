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
    public partial class coursemapping : Form
    {
        MySqlConnection cn;
        void fill_cid()
        {

            try
            {
                string q = "select cid,cname from courses ";
                MySqlCommand cmd = new MySqlCommand(q, cn);

                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr[0].ToString() + " - " + dr[1].ToString());

                }

                dr.Close();
                cmd.Dispose();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }


        }
        public coursemapping()
        {
            InitializeComponent();
            if (cn == null)
            {
                cn = new MySqlConnection();
                cn.ConnectionString = GetConnectionString();
                cn.Open();
               

            }
            fill_cid();
            comboBox1.SelectedIndex = 0;
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
        private void BindGrid()
        {

            clear();
            var cid_tem = comboBox1.SelectedItem.ToString().Split('-');

            string conString = "Data Source=localhost; Initial Catalog=eschool;User Id=root;Password=india@123";

            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT uid,fname,college,sem FROM users where utype='Student' and uid!=all(select userid from courseusermapping where cid=" + cid_tem.First() + ")", conString);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();

                dataGridView1.Rows[n].Cells[0].Value = item["uid"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["fname"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["college"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["sem"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = "false";



            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
          
            if (comboBox1.SelectedIndex != -1)
            {
                var cid_tem = comboBox1.SelectedItem.ToString().Split('-');
                string dsate = DateTime.Now.ToString("yyyy-MM-dd ");
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    if (bool.Parse(item.Cells[4].Value.ToString()))
                    {

                        String q = "insert into courseusermapping(userid,cid,dor) values(?userid,?cid,?dor) ";
                        MySqlCommand cmd = new MySqlCommand(q, cn);
                        MySqlParameter p1 = new MySqlParameter("userid", item.Cells[0].Value.ToString());
                        MySqlParameter p2 = new MySqlParameter("cid", cid_tem.First());
                        MySqlParameter p3 = new MySqlParameter("dor", dsate);


                        cmd.Parameters.Add(p1);

                        cmd.Parameters.Add(p2);
                        cmd.Parameters.Add(p3);

                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                      
                    }

                }
                MessageBox.Show("Data Saved");
                clear();
                this.BindGrid();
            }

            else {
                MessageBox.Show("Select Course Name");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {


                item.Cells[4].Value = item.Cells[4].Value == null ? false : true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {


                item.Cells[4].Value = item.Cells[4].Value == null ? true : false;
            }
        }

        private void onselectcha(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex != -1)
            {

                this.BindGrid();



            }
        }

        private void rowheader(object sender, DataGridViewCellMouseEventArgs e)
        {
            String id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();

            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "images\\" + id+ ".jpg") == false)
            {

                pictureBox1.ImageLocation = AppDomain.CurrentDomain.BaseDirectory + "images\\dum.jpg";



            }
            else
            {

                pictureBox1.ImageLocation = AppDomain.CurrentDomain.BaseDirectory + "images\\" +id + ".jpg";



            }
        }
    }
    
}
