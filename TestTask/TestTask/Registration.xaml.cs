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
using TestTask.DAL;
using System.Data.SqlClient;
using System.Data;
using System.Net;

namespace TestTask
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        BaseDAO baseDAO = new BaseDAO();

        IDbConnection connection;
        public Registration()
        {
            InitializeComponent();

            connection = baseDAO.GetConnection();
        }

        private void Create_Account_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!CheckUser())
                {
                    IDbConnection connection = baseDAO.GetConnection();

                    var login = loginClient.Text;

                    var password = passwordClient.Password.ToString();

                    string queryString = $"INSERT INTO REGISTER(User_Login, User_Password) VALUES('{login}', '{password}')";

                    SqlCommand command = new SqlCommand(queryString, (SqlConnection)connection);

                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Account successfully created!");

                        MainWindow mainWindow = new MainWindow();

                        this.Hide();

                        mainWindow.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Account not created!");
                    }
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

        private Boolean CheckUser()
        {
            try
            {
                var login = loginClient.Text;

                var password = passwordClient.Password.ToString();

                SqlDataAdapter adapter = new SqlDataAdapter();

                DataTable table = new DataTable();

                string queryString = $"SELECT User_ID, User_Login, User_Password FROM Register WHERE User_Login = '{login}' and User_Password = '{password}'";

                SqlCommand command = new SqlCommand(queryString, (SqlConnection)connection);

                adapter.SelectCommand = command;

                adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    MessageBox.Show("The user already exists!");

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return false;
        }

        private void Show_Hiden_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (example.Content == FindResource("hide_icon"))
                {
                    example.Content = FindResource("show_icon");

                    example.ToolTip = "Hide password";

                    passwordClient.Visibility = Visibility.Collapsed;

                    txtBox.Visibility = Visibility.Visible;

                    txtBox.Text = new NetworkCredential(string.Empty, passwordClient.SecurePassword).Password;

                    txtBox.Focus();
                }
                else
                {
                    example.Content = FindResource("hide_icon");

                    example.ToolTip = "Show password";

                    passwordClient.Visibility = Visibility.Visible;

                    txtBox.Visibility = Visibility.Collapsed;

                    txtBox.Text = "";

                    passwordClient.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
