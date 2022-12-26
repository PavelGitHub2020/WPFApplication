using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security;
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
using TestTask.DAL;

namespace TestTask
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BaseDAO baseDAO = new BaseDAO();

        IDbConnection connection;

        public MainWindow()
        {
            InitializeComponent();

            connection = baseDAO.GetConnection();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var loginUser = login.Text;

                var passwordUser = password.Password.ToString();

                SqlDataAdapter adapter = new SqlDataAdapter();

                DataTable table = new DataTable();

                string queryString = $"SELECT User_ID, User_Login, User_Password FROM Register WHERE User_Login = '{loginUser}' and User_Password = '{passwordUser}'";

                SqlCommand command = new SqlCommand(queryString, (SqlConnection)connection);

                adapter.SelectCommand = command;

                adapter.Fill(table);

                if (table.Rows.Count == 1)
                {
                    MessageBox.Show("You have successfully logged in!", MessageBoxButton.OK.ToString());

                    MainForm application = new MainForm();

                    this.Hide();

                    application.ShowDialog();

                    this.Show();
                }
                else
                {
                    MessageBox.Show("There is no such account!", MessageBoxButton.OK.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                baseDAO.ReleaseConnection(connection);
            }
        }

        private void Registration_Event(object sender, MouseButtonEventArgs e)
        {
            Registration registration = new Registration();

            registration.Show();

            this.Hide();
        }

        private void Show_Hiden_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (example.Content == FindResource("hide_icon"))
                {
                    example.Content = FindResource("show_icon");

                    example.ToolTip = "Hide password";

                    password.Visibility = Visibility.Collapsed;

                    txtBox.Visibility = Visibility.Visible;

                    txtBox.Text = new NetworkCredential(string.Empty, password.SecurePassword).Password;

                    txtBox.Focus();
                }
                else
                {
                    example.Content = FindResource("hide_icon");

                    example.ToolTip = "Show password";

                    password.Visibility = Visibility.Visible;

                    txtBox.Visibility = Visibility.Collapsed;

                    txtBox.Text = "";

                    password.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
