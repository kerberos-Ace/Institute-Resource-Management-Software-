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

namespace SMS
{
    public partial class Faculty_Collection : Form
    {
        string IIDD;
        private class Item
        {

            public string Name;
            public  string Value;
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
        void fill()
        {


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
        public Faculty_Collection()
        {
            InitializeComponent();
            fill();
        }

        private void clickk_head(object sender, DataGridViewCellMouseEventArgs e)
        {
            comboBox1.Items.Clear();
            label2.Text = "";
            checkBox1.Checked = false;
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            button1.Enabled = false;
            checkBox2.Checked = false;
            dateTimePicker3.Enabled = false;
            dateTimePicker4.Enabled = false;
            button2.Enabled = false;
            label4.Text = "";


         string   temp = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            try
            {
                String str = " select bid,bname from batches where facultyid='" + temp+ "'";


                MySqlConnection cn = new MySqlConnection();
                cn.ConnectionString = "Data Source=localhost; Initial Catalog=eschool;User Id=root;Password=india@123";
                cn.Open();

                MySqlCommand cmd = new MySqlCommand(str, cn);
                MySqlDataReader dr = cmd.ExecuteReader();

                int c = 0;
               while (dr.Read())
                {
                   c++;
                    
                    comboBox1.Items.Add(new Item(dr[1].ToString(), dr[0].ToString()));

                }
                if(c!=0){
                   
                comboBox1.SelectedIndex=0;

                
                }

                cmd.Dispose();
               
            }

            catch (Exception we)
            {

                MessageBox.Show(we.Message);
                
            }
            IIDD = temp;
            all_fill(temp);
        }

        void ccdd()
        {
            
            Item itm = (Item)comboBox1.SelectedItem;
            try
            {
                String str = "";
                if (checkBox1.Checked == true)
                {

                    str = " select sum(amount) from collection where doc between '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd HH:mm") + "' and '" + dateTimePicker2.Value.Date.ToString("yyyy-MM-dd HH:mm") + "' and bmid =any(select id from batchcourseusermapping where bid='" + itm.Value.ToString().Trim() + "')";
                }
                else if (checkBox1.Checked == false)
                {
                    str = " select sum(amount) from collection where bmid =any(select id from batchcourseusermapping where bid='" + itm.Value.ToString().Trim() + "')";
                }

                MySqlConnection cn = new MySqlConnection();
                cn.ConnectionString = "Data Source=localhost; Initial Catalog=eschool;User Id=root;Password=india@123";
                cn.Open();

                MySqlCommand cmd = new MySqlCommand(str, cn);
                MySqlDataReader dr = cmd.ExecuteReader();

                label2.Text = "No Record";
                if (dr.Read())
                {

                    label2.Text = (dr[0].ToString());

                }

                cmd.Dispose();
                cn.Close();

            }

            catch (Exception we)
            {

                MessageBox.Show(we.Message);

            }
        
        
        }
    
        private void chane_combo(object sender, EventArgs e)
        {
            ccdd();
        }

        private void chckbox(object sender, EventArgs e)
        {


            if (comboBox1.Items.Count > 0)
            {
                if (checkBox1.Checked == true)
                {


                    dateTimePicker1.Enabled = true;
                    dateTimePicker2.Enabled = true;
                    button1.Enabled = true;
                }
                else if (checkBox1.Checked == false)
                {

                    button1.Enabled = false;
                    dateTimePicker1.Enabled = false;
                    dateTimePicker2.Enabled = false;



                }
                label2.Text = "";
                ccdd();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ccdd();
        }





        void all_fill(string aa) {
            String str = "";
            if (checkBox2.Checked == true)
            {

              
                str = "SELECT f.bname As Batch_Name,sum(c.amount) AS Amount FROM eschool.batchcourseusermapping bp,eschool.collection c , eschool.batches f where f.bid=bp.bid and bp.id=c.bmid and doc between '" + dateTimePicker4.Value.Date.ToString("yyyy-MM-dd HH:mm") + "' and '" + dateTimePicker3.Value.Date.ToString("yyyy-MM-dd HH:mm") + "' and bp.bid=any(SELECT bid FROM eschool.batches where facultyid='" + aa + "') group by bp.bid,f.facultyid";

            }
            else if (checkBox2.Checked == false)
            {
                str = "SELECT f.bname As Batch_Name,sum(c.amount) AS Amount FROM eschool.batchcourseusermapping bp,eschool.collection c , eschool.batches f where f.bid=bp.bid and bp.id=c.bmid and bp.bid=any(SELECT bid FROM eschool.batches where facultyid='" + aa + "') group by bp.bid,f.facultyid";

            }

          

         string conString = "Data Source=localhost; Initial Catalog=eschool;User Id=root;Password=india@123";
         using (MySqlConnection con = new MySqlConnection(conString))
         {
             using (MySqlCommand cmd = new MySqlCommand(str, con))
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

         int sum = 0;
         foreach (DataGridViewRow item in dataGridView2.Rows)
         {
             sum = sum + Int32.Parse(item.Cells[1].Value.ToString());


         }
         label4.Text ="Total Amount ("+ sum.ToString()+")";
        
        
        
        
        }

        private void chane2(object sender, EventArgs e)
        {

            if (comboBox1.Items.Count > 0)
            {
                if (checkBox2.Checked == true)
                {


                    dateTimePicker3.Enabled = true;
                    dateTimePicker4.Enabled = true;
                    button2.Enabled = true;
                }
                else if (checkBox2.Checked == false)
                {

                    button2.Enabled = false;
                    dateTimePicker4.Enabled = false;
                    dateTimePicker3.Enabled = false;



                }
                label4.Text = "";
                all_fill(IIDD);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            all_fill(IIDD);
        }

        private void linkclick(object sender, LinkLabelLinkClickedEventArgs e)
        {

           All_Collection list = new All_Collection();
            list.ShowDialog();
        }




    }
}
