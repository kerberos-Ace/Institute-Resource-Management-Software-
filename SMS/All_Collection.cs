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
    public partial class All_Collection : Form
    {
        public All_Collection()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)


        {


            try
            {
                String str = "";
             
                    str = " select sum(amount) from collection where doc between '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd HH:mm") + "' and '" + dateTimePicker2.Value.Date.ToString("yyyy-MM-dd HH:mm") + "'";
              

                MySqlConnection cn = new MySqlConnection();
                cn.ConnectionString = "Data Source=localhost; Initial Catalog=eschool;User Id=root;Password=india@123";
                cn.Open();

                MySqlCommand cmd = new MySqlCommand(str, cn);
                MySqlDataReader dr = cmd.ExecuteReader();


                if (dr.Read())
                {

                    textBox1.Text = (dr[0].ToString());

                }

                cmd.Dispose();

            }

            catch (Exception we)
            {

                MessageBox.Show(we.Message);

            }
        


        }
    }
}
