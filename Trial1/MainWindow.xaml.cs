using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Trial1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection("Server=10.50.18.16;Database=training_db;User Id=SVC_TRANING;Password=Gemini@123");
            con.Open();
            SqlCommand cmd1 = new SqlCommand("Select CONCAT(FirstName, ' ', LastName) AS Name from GemTrialWPF1", con);
            string name = Convert.ToString(cmd1.ExecuteScalar());
            userName.Text = name;

            SqlCommand cmd = new SqlCommand("Select CONCAT(FirstName, ' ', LastName) AS Name, Email, Gender, DOB from GemTrialWPF1", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            dataGrid.ItemsSource = dataTable.DefaultView;
            con.Close();
        }

        private void logout_click(object sender, RoutedEventArgs e)
        {
            LoginView dashboard = new LoginView();
            dashboard.Show();
            this.Close();
        }
    }
}
