using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
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
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=10.50.18.16;Initial Catalog=training_db;Persist Security Info=True;User ID=SVC_TRANING;Password=Gemini@123");
            try
            {
                sqlCon.Open();
                String query = "insert into UsersData values(@FirstName, @LastName, @Gender, @Email, @DOB, @Password)";
                SqlCommand sqlcmd = new SqlCommand(query, sqlCon);
                sqlcmd.Parameters.AddWithValue("@FirstName", txtUsername.Text);
                sqlcmd.Parameters.AddWithValue("@LastName", txtLastname.Text);
                sqlcmd.Parameters.AddWithValue("@Gender", txtGender.Text);
                sqlcmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                sqlcmd.Parameters.AddWithValue("@DOB", dob.Text);
                sqlcmd.Parameters.AddWithValue("@Password", txtPassword.Password);
                sqlcmd.ExecuteNonQuery();

                LoginScreen loginScreen = new LoginScreen();    
                loginScreen.Show();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }finally
            {
sqlCon.Close();
            }
        }
    }
}
