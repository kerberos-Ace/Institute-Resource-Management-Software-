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
    public partial class Display_Expenses : Form
    {String ID;
        public Display_Expenses()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

      void  fill2(int status){


          string str = "";
          if(status==1){


              str="select against,amount,doe As date from expenses where category='Others' ";
          } else if(status==2){

              str="select against,amount,doe As date from expenses where category='Others' and doe  between '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd HH:mm") + "' and '" + dateTimePicker2.Value.Date.ToString("yyyy-MM-dd HH:mm") + "'  ";
          }
          else if (status == 3) {

              str = "select against As Faculity_ID,amount,doe As date from expenses where category='Salary' and against='"+ID+"' ";
          }
          else if (status == 4)
          {

              str = "select against As Faculity_ID,amount,doe As date from expenses where category='Salary' and against='" + ID + "' and doe  between '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd HH:mm") + "' and '" + dateTimePicker2.Value.Date.ToString("yyyy-MM-dd HH:mm") + "'  ";
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
          count();


      }
        private void changeee(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                dataGridView2.DataSource = null;
                fll();
                dataGridView1.Enabled = true;
            }
            else
            {
                dataGridView1.DataSource = null;
                dataGridView1.Enabled = false;
                fill2(1);


            }
        }
          void fll() {



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

        private void clicked(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            fill2(3);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex == 1)
            {
                fill2(2);
            }

            else if (comboBox1.SelectedIndex == 0)
            {

                fill2(4);
            
            
            }
        }



        void count() {



            int sum = 0;
            foreach (DataGridViewRow item in dataGridView2.Rows)
            {
                sum = sum + Int32.Parse(item.Cells[1].Value.ToString());


            }
            label2.Text = "Total Amount (" + sum.ToString() + ")";




        }

    }
}

