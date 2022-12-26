using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestTask.DAL;

namespace TestTask
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        BaseDAO baseDAO = new BaseDAO();

        IDbConnection connection;

        private SomeValue selectedSomeValue;
        public ObservableCollection<SomeValue> SomeValues { get; set; }
        public ObservableCollection<SomeValue> CurrentSelectedValue { get; set; }

        private string value_;

        public string Value_
        {
            get { return value_; }
            set
            {
                value_ = selectedSomeValue.SValue;
                OnPropertyChanged("Value_");
            }
        }
        public SomeValue SelectedSomeValue
        {
            get { return selectedSomeValue; }
            set
            {
                selectedSomeValue = value;
                OnPropertyChanged("SelectedSomeValue");
            }
        }
        public ApplicationViewModel()
        {
            try
            {
                connection = baseDAO.GetConnection();

                DataTable table = GetAllValues();

                SomeValues = new ObservableCollection<SomeValue>();

                foreach (DataRow row in table.Rows)
                {
                    SomeValues.Add(new SomeValue()
                    {
                        Name = row[1].ToString(),
                        SValue = row[2].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private DataTable GetAllValues()
        {
            DataTable table = new DataTable("Table");

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();

                string queryString = "SELECT * FROM Initial_Data";

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
    }
}
