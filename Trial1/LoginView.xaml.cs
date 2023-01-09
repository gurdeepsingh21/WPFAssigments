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
using System.Data.SqlClient;
using System.Data.Common;

namespace Trial1
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "Server= 10.50.18.16; Database=training_db;User Id=SVC_TRANING;Password=Gemini@123;Trusted_Connection=True;TrustServerCertificate=true;MultipleActiveResultSets=true;Integrated Security = False";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                if(connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();
                string query = "select count(1) from GemTrialWPF1 where email=@Email and password=@Password";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.CommandType=System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Password);
                int count=Convert.ToInt32(cmd.ExecuteScalar());
                if(count == 1)
                {
                    MessageBox.Show("Logged in successfully");
                    MainWindow dashboard = new MainWindow();
                    dashboard.Show();
                    this.Close();

                }
                else
                {
                    errormessage.Text = "Invalid Credentials";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void Signup_Click(object sender, RoutedEventArgs e)
        {
            Signup objForSignup = new Signup();
            this.Visibility = Visibility.Hidden;
            objForSignup.Show();
        }
    }
}
