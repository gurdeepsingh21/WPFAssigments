using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Wpfloginscreen
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=10.50.18.16;Initial Catalog=training_db;Persist Security Info=True;User ID=SVC_TRANING;Password=Gemini@123");
            try
            {
                sqlCon.Open();
                string query = "select * from UsersData";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.ExecuteNonQuery();
                
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
                DataTable dt = new DataTable("UsersData");
                adapter.Fill(dt);
                dataGrid.ItemsSource = dt.DefaultView;
                adapter.Update(dt);
                sqlCon.Close();
            }
             
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LoginScreen Sc = new LoginScreen();
            Sc.Show();

            this.Close();
        }
    }
}
