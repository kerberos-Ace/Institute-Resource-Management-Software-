using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
namespace SMS
{
    public partial class SearchList : Form
    {
        MySqlConnection cn;
        public static string iimm_upload;
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
        public string GetConnectionString()
        {
            return "Data Source=localhost; Initial Catalog=eschool;User Id=root;Password=india@123";
        }
        public SearchList()
        {
            InitializeComponent();


            var data_previous=Search_Record.search_record_report.Split('-');

            this.Text="Search Report ("+data_previous.Last()+ ")";
            combo_fill(data_previous.First());
   
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "images\\"+data_previous.First().Trim()+".jpg") == false)
            {

                pictureBox1.ImageLocation = AppDomain.CurrentDomain.BaseDirectory + "images\\dum.jpg";

           

            }
            else
            {

                pictureBox1.ImageLocation = AppDomain.CurrentDomain.BaseDirectory + "images\\" + data_previous.First().Trim() + ".jpg";



            }
        }


        void combo_fill(String id) { 
        
        
        
        
         MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = "Data Source=localhost; Initial Catalog=eschool;User Id=root;Password=india@123";
            string q = "select id,bid from batchcourseusermapping where cumid=any(select id from courseusermapping where userid =?userid)";
            MySqlCommand cmd = new MySqlCommand(q, cn);
            cn.Open();
            MySqlParameter p1 = new MySqlParameter("userid",id);

            Logic.return_unique_no values_batch = new Logic.return_unique_no();
            cmd.Parameters.Add(p1);
            int ii = 0;
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ii++;

                String temp = values_batch.return_batch_name(Int32.Parse(dr[1].ToString()));
           
                comboBox1.Items.Add(new Item(temp ,dr[0].ToString()));

                

            }
            cmd.Dispose();
            cn.Close();
            if (ii != 0)
            {

                comboBox1.SelectedIndex =0;

            }
        }



        void fill_grid_expected_fee(string bmid)
        {


            string conString = "Data Source=localhost; Initial Catalog=eschool;User Id=root;Password=india@123";
            using (MySqlConnection con = new MySqlConnection(conString))
            {
                using (MySqlCommand cmd = new MySqlCommand("select  installmentname,expecteddate,amount from feebatchusermapping where bmid=" + bmid + "", con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {

                            sda.Fill(dt);

                            dataGridView1.DataSource = dt;

                        }
                    }
                }
            }
        }


        void fill_grid_fee(string bmid)
        {


            string conString = "Data Source=localhost; Initial Catalog=eschool;User Id=root;Password=india@123";
            using (MySqlConnection con = new MySqlConnection(conString))
            {
                using (MySqlCommand cmd = new MySqlCommand("select  cid As Cashier_ID,amount,doc from collection where bmid=" + bmid + "", con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);

                            dataGridView2.DataSource = dt;

                        }
                    }
                }
            }
        }


        private void combobox_change(object sender, EventArgs e)
        {
            Item itm = (Item)comboBox1.SelectedItem;

            int sum = 0;
            int sum2 = 0;
            fill_grid_expected_fee(itm.Value.ToString());
            fill_grid_fee(itm.Value.ToString());
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
             sum=sum+Int32.Parse(item.Cells[2].Value.ToString());
               

            }
            foreach (DataGridViewRow item in dataGridView2.Rows)
            {
                sum2 = sum2 + Int32.Parse(item.Cells[1].Value.ToString());


            }
            label4.Text ="("+ sum.ToString()+")";
            label5.Text = "("+sum2.ToString()+")";

        }

        private void click_on_image(object sender, EventArgs e)
        {
            var data_previous=Search_Record.search_record_report.Split('-');

            iimm_upload= data_previous.First()+"-"+pictureBox1.ImageLocation;
           Update_Image list = new Update_Image();
            list.ShowDialog();

            pictureBox1.ImageLocation = iimm_upload;
        }
        }
    }