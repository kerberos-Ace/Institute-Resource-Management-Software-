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
    public partial class expenses : Form
    {
        public expenses()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }
        void clear()
        {
            this.dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

        }

        private void press(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (comboBox1.SelectedIndex != -1 && textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
            {
                enter_data();
                textBox1.Text = "";
                textBox2.Text = "";
                clear();
                comboBox1.SelectedIndex = 0;

            }
            else {


                MessageBox.Show("Insufficient Data");
            }

        }


        void enter_data() {





            try
            {
                MySqlConnection cn = new MySqlConnection();
                cn.ConnectionString = "Data Source=localhost; Initial Catalog=eschool;User Id=root;Password=india@123";
                cn.Open();
                string q = "insert into expenses(category,against,cid,amount,doe) values(?category,?against,?cid,?amount,?doe)";
                MySqlCommand cmd = new MySqlCommand(q, cn);

              
                MySqlParameter p1 = new MySqlParameter("category", comboBox1.SelectedItem.ToString());
                MySqlParameter p2 = new MySqlParameter("against", textBox2.Text);
                MySqlParameter p3 = new MySqlParameter("cid", Int32.Parse(Login.login_id_));
                MySqlParameter p4 = new MySqlParameter("amount", Int32.Parse(textBox1.Text.Trim()));
                MySqlParameter p5 = new MySqlParameter("doe", dateTimePicker1.Value.Date.ToString("yyyy-MM-dd HH:mm"));




                cmd.Parameters.Add(p1);

                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);

                cmd.Parameters.Add(p5);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                MessageBox.Show("Data Saved Successfully");
               
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        
        
        
        
        }
        void fill() {


            string conString = "Data Source=localhost; Initial Catalog=eschool;User Id=root;Password=india@123";
            using (MySqlConnection con = new MySqlConnection(conString))
            {
                using (MySqlCommand cmd = new MySqlCommand("select uid,fname,cno from users where utype='Faculty' ", con))
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
        private void selectionchange(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString().Equals("Salary"))
            {

                textBox2.Enabled = false;

                fill();
                label1.Text = "Faculty Id";

            }
            else if (comboBox1.SelectedItem.ToString().Equals("Others"))
            {
                textBox2.Enabled = true;
                label1.Text = "Details";
                textBox2.Text = "";
                clear();

            }
        }

        private void row_click(object sender, DataGridViewCellMouseEventArgs e)
        {
       
           textBox2.Text= dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
           
       
        }
    }
}