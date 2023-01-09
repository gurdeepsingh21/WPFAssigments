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
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

       public bool validation()
        {
            return true;
        }
            private void btn_click(object sender, RoutedEventArgs args)
        {
            validation();
            SqlConnection sqlcon = new SqlConnection(@"Data Source=10.50.18.16;Initial Catalog=training_db;Persist Security Info=True;User ID=SVC_TRANING;Password=Gemini@123;");
            try
            {

                sqlcon.Open();
                    String query = "insert into [dbo].[User1] values(@firstname,@lastname,@gender,@email,@dob,@pass)";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlcon);
                    sqlCmd.Parameters.AddWithValue("@firstname", fname.Text);
                    sqlCmd.Parameters.AddWithValue("@lastname", lname.Text);
                    sqlCmd.Parameters.AddWithValue("@gender", gender.Text);
                    sqlCmd.Parameters.AddWithValue("@email", email.Text);
                    sqlCmd.Parameters.AddWithValue("@dob", dob.Text);
                    sqlCmd.Parameters.AddWithValue("@pass", pass.Password);

                    sqlCmd.ExecuteNonQuery();

                    LoginScreen loginScreen = new LoginScreen();
                    loginScreen.Show();
                    this.Close();
            }

            catch (Exception ex) { MessageBox.Show(ex.Message); }

            finally
            {
                sqlcon.Close();
            }

        }
    }
}
