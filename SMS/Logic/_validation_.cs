using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace SMS.Logic
{
    class _validation_
    {
        public int validate_email_mobile(int status,String value) {
            int ret_value=1;
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            string pattern1 = "[789][0-9]{9}";


            if (status == 1 && Regex.IsMatch(value.Trim(), pattern))
            {
                ret_value = 0;
              
            }
            else if (status == 2 && Regex.IsMatch(value.Trim(), pattern1))
            {
                ret_value = 0;

            }
            else if (status == 1 && ret_value == 1) {

                MessageBox.Show("Email Format incorrect");
            }
            else if (status == 2 && ret_value == 1)
            {
                MessageBox.Show("Mobile number Format incorrect");


            }

            return ret_value;
        
        }

        public int validation_all_(Panel P)
        {

            int count = 0;

            try
            {

                foreach (Object o in P.Controls)
                {


                    // JOptionPane.showMessageDialog(null,o);
                    if (o is TextBox)//||O instanceof JTextArea)
                    {
                        TextBox t = (TextBox)o;

                        if (t.Text.Length == 0)
                        {
                            MessageBox.Show("Empty Fields");
                            count++;
                        }
                    }


                    else if (o is ComboBox)
                    {
                        ComboBox t = (ComboBox)o;


                        if (t.SelectedIndex == -1)
                        {  //JOptionPane.showMessageDialog(null,"3");
                            MessageBox.Show("Choose Value");
                            count++;

                        }
                    }
                    if (count != 0)
                    {
                        break;
                    }
                }

                return count;
            }

            catch (Exception e)
            {

                MessageBox.Show(e.Message);


                return count;


            }

        }
    }
}
