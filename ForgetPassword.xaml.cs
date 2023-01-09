using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Wpfloginscreen
{
    /// <summary>
    /// Interaction logic for ForgetPassword.xaml
    /// </summary>
    public partial class ForgetPassword : Window
    {
        public ForgetPassword()
        {
            InitializeComponent();
        }

        private void btnSi_Click(object sender, RoutedEventArgs e)
        {



            SqlConnection sqlCon = new SqlConnection(@"Data Source=10.50.18.16;Initial Catalog=training_db;Persist Security Info=True;User ID=SVC_TRANING;Password=Gemini@123");
            try
            {
               
                    sqlCon.Open();
                String query = "UPDATE UsersData set Password=@Password where Email=@Email";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
               
                sqlCmd.Parameters.AddWithValue("@Email", txtemail.Text);
                sqlCmd.Parameters.AddWithValue("@Password", txtpassword.Password);
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Password changed successfully");
                LoginScreen lg=new LoginScreen();
                lg.Show();
                this.Close();
                
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }
    }
    }

