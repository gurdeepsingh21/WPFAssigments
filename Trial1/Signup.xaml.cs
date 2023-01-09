using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
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

namespace Trial1
{
    /// <summary>
    /// Interaction logic for Signup.xaml
    /// </summary>
    public partial class Signup : Window
    {
        public Signup()
        {
            InitializeComponent();
        }
        private void SignupSubmit_Click(object sender, RoutedEventArgs e)
        {
            string selectedOption = Gender.SelectedItem.ToString();


            if (txtEmail.Text.Length == 0 || txtFname.Text.Length == 0 || txtLname.Text.Length == 0 || txtPassword.Password.Length == 0 || txtCfPassword.Password.Length == 0 || Gender.SelectedIndex == 0)
            {
                errormessage.Text = "Enter all required fields!";
                //textBoxEmail.Focus();
            }
            else if (!Regex.IsMatch(txtEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
                {
                    errormessage.Text = "Enter a valid email.";
                txtEmail.Select(0, txtEmail.Text.Length);
                txtEmail.Focus();

                }
            else if (!Regex.IsMatch(txtFname.Text, @"^[a-zA-Z]{2,}$"))
            {
                errormessage.Text = "Enter a valid First Name.";
                txtFname.Select(0, txtFname.Text.Length);
                txtFname.Focus();
            }
            else if (!Regex.IsMatch(txtLname.Text, @"^[a-zA-Z]{2,}$"))
            {
                errormessage.Text = "Enter a valid Last Name.";
                txtLname.Select(0, txtLname.Text.Length);
                txtLname.Focus();
            }
            else if (!Regex.IsMatch(txtPassword.Password, @"^.{8,}$"))
            {
                errormessage.Text = "Password must contain minimum 8 characters";
                txtPassword.Focus();
            }
            else
            {
                string firstname = txtFname.Text;
                string lastname = txtLname.Text;
                ComboBoxItem selectedItem = (ComboBoxItem)Gender.SelectedItem;
                string gender = selectedItem.Content.ToString();

                //string gender = Gender.SelectedItem.ToString();
                DateTime dob = DOB.SelectedDate.Value;
                string email = txtEmail.Text;
                string password = txtPassword.Password;
                string cfPassword = txtCfPassword.Password;

                if (password!=cfPassword)
                      {
                           errormessage.Text = "Confirm password do not match";
                           txtCfPassword.Focus();
                        }
                else
                {
                    errormessage.Text = "";
                    SqlConnection con = new SqlConnection("Server=10.50.18.16;Database=training_db;User Id=SVC_TRANING;Password=Gemini@123");
                    try
                    {
                        con.Open();
                    SqlCommand emQuery = new SqlCommand("Select count(*) from GemTrialWPF1 where Email = @email", con);
                        emQuery.Parameters.AddWithValue("@email", email);
                        Int32 count = Convert.ToInt32(emQuery.ExecuteScalar());
                        if (count > 0)
                        {
                            errormessage.Text = "Email already exists";
                            txtCfPassword.Focus();
                        }
                        else
                        {
                        SqlCommand cmd = new SqlCommand("Insert into GemTrialWPF1 (FirstName, LastName,Gender,DOB,Email,Password) values('" + firstname + "','" + lastname + "','" + gender + "','" + dob + "','" + email + "','" + password + "')", con);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                            errormessage.Text = "You have Registered successfully.";
                            LoginView obj = new LoginView();
                            this.Visibility = Visibility.Hidden;
                            obj.Show();
                        }
                        con.Close();

                    }
                    catch (Exception)
                    {
                        errormessage.Text="Can not open connection ! ";
                    }
                }
            }

        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            LoginView obj = new LoginView();
            this.Visibility = Visibility.Hidden;
            obj.Show();
        }


    }
}
