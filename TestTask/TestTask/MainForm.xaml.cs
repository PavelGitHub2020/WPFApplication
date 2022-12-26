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
using System.Windows.Shapes;
using TestTask.DAL;

namespace TestTask
{
    /// <summary>
    /// Interaction logic for MainForm.xaml
    /// </summary>
    public partial class MainForm : Window
    {
        private double number;

        private double itog;

        private double first;

        private double second;

        private int counter = -1;

        private string name;

        private StringBuilder stringBuilderName;

        private StringBuilder stringBuilderValue;

        BaseDAO baseDAO = new BaseDAO();

        IDbConnection connection;
        public MainForm()
        {
            InitializeComponent();

            stringBuilderName = new StringBuilder();

            stringBuilderValue = new StringBuilder();

            DataContext = new ApplicationViewModel();

            txtValue.TextChanged += TxtValue_TextChanged;
        }

        private DataTable GetAllResults()
        {
            DataTable table = new DataTable("Table");

            try
            {
                connection = baseDAO.GetConnection();

                SqlDataAdapter adapter = new SqlDataAdapter();

                string queryString = "SELECT Cells, Value FROM Results";

                SqlCommand command = new SqlCommand(queryString, (SqlConnection)connection);

                adapter.SelectCommand = command;

                adapter.Fill(table);

                baseDAO.ReleaseConnection(connection);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return table;
        }

        public void ClearValues()
        {
            stringBuilderName.Clear();
            stringBuilderValue.Clear();
            textName.Text = string.Empty;
            textValue.Text = string.Empty;

            counter = 0;
        }

        private void SaveResult(string name, string value_)
        {
            try
            {
                string cells = name;

                string value = value_;

                string queryString = $"INSERT INTO Results (Cells, Value) VALUES('{cells}', '{value}')";

                connection = baseDAO.GetConnection();

                SqlCommand command = new SqlCommand(queryString, (SqlConnection)connection);

                if (command.ExecuteNonQuery() == 1)
                {
                    ClearValues();

                    MessageBox.Show("Result successfully saved!");
                }
                else
                {
                    MessageBox.Show("Result not saved!");
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

        private void TxtValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (counter <= 1)
            {
                ++counter;

                resultName.Text = string.Empty;
                resultValue.Text = string.Empty;

                number = Convert.ToDouble(txtValue.Text);

                if (counter == 1)
                {
                    first = number;
                }
                else
                {
                    second = number;
                }
               
                itog = first - second;

                name = txtName.Text;

                stringBuilderName.Append(name);

                textName.Text = stringBuilderName.ToString();

                stringBuilderValue.Append(txtValue.Text);

                textValue.Text = stringBuilderValue.ToString();
            }
        }

        private void MatrixOfResult_Click(object sender, RoutedEventArgs e)
        {
            var rez = Math.Pow(itog, 2);

            rez = Math.Round(rez, 2);

            resultValue.Text = Convert.ToString(rez);

            resultName.Text = stringBuilderName.Replace("\t", string.Empty).ToString().Insert(3, "_");

            SaveResult(resultName.Text, resultValue.Text);

            dataGrid1.ItemsSource = GetAllResults().DefaultView;
        }
    }
}
