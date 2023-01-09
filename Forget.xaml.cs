using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WpfApp2
{
    public partial class Forget : Window
    {
        public Forget()
        {
            InitializeComponent();
        }

        private void btn_click(object sender, RoutedEventArgs args)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=10.50.18.16;Initial Catalog=training_db;Persist Security Info=True;User ID=SVC_TRANING;Password=Gemini@123;");

            try
            {
               
                sqlcon.Open();
                String query = "update [dbo].[User1] set password=@pass where email=@email";
                SqlCommand sqlCmd = new SqlCommand(query, sqlcon);
                sqlCmd.Parameters.AddWithValue("@email", email.Text);
                sqlCmd.Parameters.AddWithValue("@pass", pass.Password);

                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Password changed successfully");
                LoginScreen loginScreen = new LoginScreen();
                loginScreen.Show();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            finally
            {
                sqlcon.Close();
            }

        }

    }
}
