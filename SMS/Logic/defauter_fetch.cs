using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace SMS.Logic
{


  
    class defauter_fetch
    {
        
        
        long calculate_fee(string bid )
        {
            long a = 0;
            try
            {
                String str = " select sum(amount) from collection where bmid='" + bid + "'";


                MySqlConnection cn = new MySqlConnection();
                cn.ConnectionString = "Data Source=localhost; Initial Catalog=eschool;User Id=root;Password=india@123";
                cn.Open();

                MySqlCommand cmd = new MySqlCommand(str, cn);
                MySqlDataReader dr = cmd.ExecuteReader();
             
            
                if (dr.Read())
                {

                    if (!dr[0].ToString().Equals(""))
                    {
                        a = long.Parse(dr[0].ToString());
                    }

                }
              
                cmd.Dispose();
                cn.Close(); return a;
            }

            catch (Exception we) {

                MessageBox.Show("coll"+we.Message);
                return a;
            }
         




        }


        long fee_fee(string bid)
        {
            long a = 0;
            try
            {
                String str = " (select cfee from courses where cid=(select cid from courseusermapping where id=(select cumid from batchcourseusermapping where id='" + bid + "'))) ";


                MySqlConnection cn = new MySqlConnection();
                cn.ConnectionString = "Data Source=localhost; Initial Catalog=eschool;User Id=root;Password=india@123";
                cn.Open();

                MySqlCommand cmd = new MySqlCommand(str, cn);
                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    a = long.Parse(dr[0].ToString());

                }
                cmd.Dispose();
                cn.Close();
                return a;
            }
            catch (Exception ee)
            {

                MessageBox.Show("fee" + ee.Message);

                return a;
            }



        }




    public    long calculate_(String bid) {

         long g=   calculate_fee(bid);
       long f=     fee_fee(bid);
        
       long calcu = f - g;


      

       return calcu;
        
        
        
        
        }

    }
}
