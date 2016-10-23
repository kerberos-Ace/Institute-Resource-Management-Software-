using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SMS
{
    public partial class AddBatch : Form
    {
        static MySqlConnection cn;
        public AddBatch()
        {
            InitializeComponent();
            if (cn == null)
            {
                cn = new MySqlConnection();
                cn.ConnectionString = GetConnectionString();
                cn.Open();
                
            }

            fill_cid();
            fill_fid();
         
        }
        public string GetConnectionString()
        {
            return "Data Source=localhost; Initial Catalog=eschool;User Id=root;Password=india@123";
        }


        void fill_fid()
        {
            try
            {
                string q = "select uid,fname,email from users where utype='Faculty' ";
                MySqlCommand cmd = new MySqlCommand(q, cn);

                int temp = 0;
                MySqlDataReader dr = cmd.ExecuteReader();
               while (dr.Read())
               {
                   temp++;
                    comboBox2.Items.Add(dr[0].ToString() + " - " + dr[1].ToString() + " - " + dr[2].ToString());
                   

                }
               if (temp != 0) {


                   comboBox2.SelectedIndex = 0;
               }

                dr.Close();
                cmd.Dispose();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }


        }
        void fill_cid()
        {
            int temp = 0;
            try
            {
                string q = "select cid,cname from courses ";
                MySqlCommand cmd = new MySqlCommand(q, cn);

                MySqlDataReader dr = cmd.ExecuteReader();
               while (dr.Read())
               {
                   temp++;
                    comboBox1.Items.Add(dr[0].ToString() + " - " + dr[1].ToString());

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
        private void AddBatch_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Logic._validation_ v = new Logic._validation_();
            int temp_count_validation = v.validation_all_(panel1);
            if (temp_count_validation == 0)
            {


                Logic.MyData m = new Logic.MyData();
                var cid_tem = comboBox1.SelectedItem.ToString().Split('-');
                var fid_temp = comboBox2.SelectedItem.ToString().Split('-');

                Logic.Batch u = new Logic.Batch(null, textBox1.Text, dateTimePicker1.Value.Date.ToString("yyyy-MM-dd HH:mm"), dateTimePicker2.Value.Date.ToString("yyyy-MM-dd HH:mm"), dateTimePicker2.Value.Date.ToString("yyyy-MM-dd HH:mm"), Int32.Parse(cid_tem.First()), Int32.Parse(fid_temp.First()));

                string str = m.Save_batch(u);
                MessageBox.Show(str);
                textBox1.Text = "";
            }
        }
    }
}
