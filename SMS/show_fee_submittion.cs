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
    public partial class show_fee_submittion : Form
    {
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
        public show_fee_submittion()
        {
            InitializeComponent();
            fill_grid_fee(fee_collection.show_);
            int sum = 0;
          

            foreach (DataGridViewRow item in dataGridView2.Rows)
            {
                sum = sum + Int32.Parse(item.Cells[1].Value.ToString());


            }
      
            label5.Text = "(" + sum.ToString() + ")";
        }
    }
}
