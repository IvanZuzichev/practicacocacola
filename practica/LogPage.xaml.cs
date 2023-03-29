using practica.PRACTDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace practica
{
    /// <summary>
    /// Логика взаимодействия для LogPage.xaml
    /// </summary>
    public partial class LogPage : Page
    {
            usersTableAdapter users = new usersTableAdapter();
            dataTableAdapter data = new dataTableAdapter();
        public LogPage()
        {
            InitializeComponent();
            LogGrid.ItemsSource = users.GetData();

            combouser.ItemsSource = data.GetData();
            combouser.DisplayMemberPath = "id";
            combouser.SelectedValuePath = "id";
        }
        private void addlog_Click(object sender, RoutedEventArgs e)
        {
            if (logBox.Text != "" && passwordBox.Text != "" && combouser.SelectedIndex != -1)
            {
                users.InsertQuery((int)combouser.SelectedValue, logBox.Text, passwordBox.Text);
                LogGrid.ItemsSource = users.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }
        private void dellog_Click(object sender, RoutedEventArgs e)
        {
            if (LogGrid.SelectedItem != null && logBox.Text != "" && passwordBox.Text != "")
            {
                int id = (int)(LogGrid.SelectedItem as DataRowView).Row[0];
                users.DeleteQuery(id);
                LogGrid.ItemsSource = users.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }
        private void remlog_Click(object sender, RoutedEventArgs e)
        {
            if (LogGrid.SelectedItem != null && logBox.Text != "" && passwordBox.Text != "" && combouser.SelectedIndex != -1)
            {
                Object id = (LogGrid.SelectedItem as DataRowView).Row[0];
                users.UpdateQuery(logBox.Text, passwordBox.Text, Convert.ToInt32(id));
                LogGrid.ItemsSource = users.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }

        private void LogGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LogGrid.SelectedItem != null)
            {
                logBox.Text = Convert.ToString((LogGrid.SelectedItem as DataRowView).Row[1]);
                passwordBox.Text = Convert.ToString((LogGrid.SelectedItem as DataRowView).Row[2]);
            }
        }
    }
}
