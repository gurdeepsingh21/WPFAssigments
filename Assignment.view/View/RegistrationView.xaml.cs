using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Assignment.view.View
{
    /// <summary>
    /// Interaction logic for RegistrationView.xaml
    /// </summary>
    public partial class RegistrationView : Window
    {
        public RegistrationView()
        {
            InitializeComponent();
        }

        
    private void button2_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    private void button3_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxEmail.Text.Length == 0)
            {
                errormessage.Text = "Enter an email.";
                textBoxEmail.Focus();
            }
            else if (!Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                errormessage.Text = "Enter a valid email.";
                textBoxEmail.Select(0, textBoxEmail.Text.Length);
                textBoxEmail.Focus();
            }
            else
            {
                string Firstname = textBoxFirstName.Text;
                string Lastname = textBoxLastName.Text;
                string DOB = textBoxDOB.Text;
                string Gender = Textblockgender.Text;
                string email = textBoxEmail.Text;
                string Password = passwordBox1.Password;
                string CPassword = passwordBoxConfirm.Password;
                if (passwordBox1.Password.Length == 0)
                {
                    errormessage.Text = "Enter password.";
                    passwordBox1.Focus();
                }
                else if (passwordBoxConfirm.Password.Length == 0)
                {
                    errormessage.Text = "Enter Confirm password.";
                    passwordBoxConfirm.Focus();
                }
                //else if (passwordBox1.Password != passwordBoxConfirm.Password)
                //{
                //    errormessage.Text = "Confirm password must be same as password.";
                //    passwordBoxConfirm.Focus();
                //}
                else
                {
                    errormessage.Text = "";
                    
                    SqlConnection con = new SqlConnection("Data Source=(Localdb)\trishitadb;Initial Catalog=Users;Integrated Security=True;Pooling=False");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into Tables (Firstname,Lastname,Gender,email,DOB,Password,CPassword) values('" + Firstname + "','" + Lastname + "','" + Gender + "','" + email + "','" + DOB + "','" + Password + "','" + CPassword+ "')", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    errormessage.Text = "You have Registered successfully.";
                    
                }





            }
                

    }

        private void textBoxAddress_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
