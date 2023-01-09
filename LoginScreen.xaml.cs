using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void btn_click1(object sender, RoutedEventArgs args)
        {
            Registration r = new Registration();
            r.Show();
        }

        private void btn_click2(object sender, RoutedEventArgs args)
        {
            Forget r = new Forget();
            r.Show();
        }

        private void btn_click(object sender, RoutedEventArgs args)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=10.50.18.16;Initial Catalog=training_db;Persist Security Info=True;User ID=SVC_TRANING;Password=Gemini@123;");
            try
            {
                if (sqlcon.State == System.Data.ConnectionState.Closed)
                    sqlcon.Open();
                String query = "Select count(1) from [dbo].[User1] where Email=@email and Password=@pass";
                SqlCommand sqlCmd = new SqlCommand(query, sqlcon);
                sqlCmd.CommandType = System.Data.CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@email", email.Text);
                sqlCmd.Parameters.AddWithValue("@pass", pass.Password);
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1)
                {
                    MainWindow dashboard = new MainWindow();

                    dashboard.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Username or password is incorrect");
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            finally
            {
                sqlcon.Close();
            }

        }
    }
}
