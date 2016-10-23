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
    public partial class fee_batch : Form
    {



        public fee_batch()
        {
            InitializeComponent();
            pictureBox1.ImageLocation = AppDomain.CurrentDomain.BaseDirectory + "images\\dum.jpg";


        }




        private void find_student(object sender, EventArgs e)
        {

            dataGridView1.Enabled = true;

            string conString = "Data Source=localhost; Initial Catalog=eschool;User Id=root;Password=india@123";
            using (MySqlConnection con = new MySqlConnection(conString))
            {
                using (MySqlCommand cmd = new MySqlCommand("select uid,fname,cno,college from users where fname like '%" + textBox1.Text.Trim().ToUpper() + "%' and utype='Student' ", con))
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

        private void ontableclick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            fill_batch_name(ID);
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "images\\" + ID + ".jpg") == true)
            {

                pictureBox1.ImageLocation = AppDomain.CurrentDomain.BaseDirectory + "images\\" + ID + ".jpg";



            }
            else { pictureBox1.ImageLocation = AppDomain.CurrentDomain.BaseDirectory + "images\\dum.jpg"; }
          
            //select id,bid from batchcourseusermapping where cumid=any(select id from courseusermapping where userid = 10)
        }

        void fill_batch_name(int id)
        {
            comboBox1.Items.Clear();
           
           
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = "Data Source=localhost; Initial Catalog=eschool;User Id=root;Password=india@123";
            string q = "select id,bid from batchcourseusermapping where cumid=any(select id from courseusermapping where userid =?userid)";
            MySqlCommand cmd = new MySqlCommand(q, cn);
            cn.Open();
            MySqlParameter p1 = new MySqlParameter("userid", id);

            Logic.return_unique_no values_batch = new Logic.return_unique_no();
            cmd.Parameters.Add(p1);
            int ii = 0;
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ii++;
               
                String temp = values_batch.return_batch_name(Int32.Parse(dr[1].ToString()));
                comboBox1.Items.Add(dr[0].ToString() + " - " + temp);

            }
            cmd.Dispose();
            cn.Close();
            if (ii != 0) {

                comboBox1.SelectedIndex = 0;
            
            
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1 && textBox2.Text.Length != 0 && textBox4.Text.Length != 0)
            {
                insert_data();

                textBox2.Text = "";
                this.dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();

                display();



            }
            else
            {

                MessageBox.Show("Insufficient Data");
            }
        }


        void insert_data()
        {




            try
            {
                MySqlConnection cn = new MySqlConnection();
                cn.ConnectionString = "Data Source=localhost; Initial Catalog=eschool;User Id=root;Password=india@123";
                cn.Open();
                string q = "insert into feebatchusermapping(bmid,installmentname,expecteddate,amount) values(?bmid,?installmentname,?expecteddate,?amount)";
                MySqlCommand cmd = new MySqlCommand(q, cn);
             
                var cid_tem = comboBox1.SelectedItem.ToString().Split('-');
                MySqlParameter p1 = new MySqlParameter("bmid", Int32.Parse(cid_tem.First().ToString()));
                MySqlParameter p2 = new MySqlParameter("installmentname", textBox2.Text);
                MySqlParameter p3 = new MySqlParameter("expecteddate", dateTimePicker1.Value.Date.ToString("yyyy-MM-dd HH:mm"));
                MySqlParameter p4 = new MySqlParameter("amount", Int32.Parse(textBox4.Text));




                cmd.Parameters.Add(p1);

                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);


                cmd.ExecuteNonQuery();
                cmd.Dispose();
                MessageBox.Show("Data Saved Successfully");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }    


        void display()
        {

            dataGridView1.Enabled = false;
            var cid_tem = comboBox1.SelectedItem.ToString().Split('-');
            string conString = "Data Source=localhost; Initial Catalog=eschool;User Id=root;Password=india@123";
            using (MySqlConnection con = new MySqlConnection(conString))
            {
               
                using (MySqlCommand cmd = new MySqlCommand("select * from feebatchusermapping where bmid='" + cid_tem.First().ToString() + "' ", con))
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
        void clear() {

            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            comboBox1.Items.Clear();

        }
        private void press(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}