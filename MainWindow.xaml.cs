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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Data.SqlClient;
using Microsoft.SqlServer;
using System.Data;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        public void load_btn(object sender, RoutedEventArgs args)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=10.50.18.16;Initial Catalog=training_db;Persist Security Info=True;User ID=SVC_TRANING;Password=Gemini@123;");
            try
            {
                if (sqlcon.State == System.Data.ConnectionState.Closed)
                {
                    sqlcon.Open();
                    String query = "Select * from [dbo].[User1]";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlcon);
                    sqlCmd.CommandType = System.Data.CommandType.Text;
                    sqlCmd.ExecuteNonQuery();
                    SqlDataAdapter dataAdp = new SqlDataAdapter(sqlCmd);
                    DataTable dt = new DataTable("[dbo].[User1]");
                    dataAdp.Fill(dt);
                    datagrid1.ItemsSource = dt.DefaultView;
                    dataAdp.Update(dt);
                    sqlcon.Close();
                }

                else
                {
                    MessageBox.Show("No data found");
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            finally
            {
                sqlcon.Close();
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            LoginScreen loginScreen = new LoginScreen();
            loginScreen.Show();
        }
    }
}
