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

namespace SMS
{
    public partial class Defaulter_list_fee_report : Form
    {
        MySqlConnection cn;

        void calcc() {




          
        

            int sum = 0;
            int sum2 = 0;
         
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
        public string GetConnectionString()
        {
            return "Data Source=localhost; Initial Catalog=eschool;User Id=root;Password=india@123";
        }
        public Defaulter_list_fee_report()
        {
            InitializeComponent();
            if (cn == null)
            {
                cn = new MySqlConnection();
                cn.ConnectionString = GetConnectionString();
                cn.Open();


            }
        

            var c = Defaulter_Listcs.defaulter_fee_report.Split('-');
            label1.Text = c.First().ToString();

            fill_grid_expected_fee(c.Last().ToString());
            fill_grid_fee(c.Last().ToString());

            calcc();
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "images\\" + c[1].Trim() + ".jpg") == false)
            {

                pictureBox1.ImageLocation = AppDomain.CurrentDomain.BaseDirectory + "images\\dum.jpg";



            }
            else
            {

                pictureBox1.ImageLocation = AppDomain.CurrentDomain.BaseDirectory + "images\\" +c[1].Trim() + ".jpg";



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



    }
}
