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
using static practica.PRACTDataSet;

namespace practica
{
    /// <summary>
    /// Логика взаимодействия для DataPage.xaml
    /// </summary>
    public partial class DataPage : Page
    {
        roleTableAdapter roles = new roleTableAdapter();
        dataTableAdapter data = new dataTableAdapter();
        public DataPage()
        {
            InitializeComponent();
            DataGrid.ItemsSource = data.GetData();
            roleidBox.ItemsSource = roles.GetData();
            roleidBox.DisplayMemberPath = "name-role";
            roleidBox.SelectedValuePath = "id";
        }
                
        private void adddata_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedItem != null && lastnameBox.Text != "" && NameBox.Text != "" && PathonymicBox.Text != "" && roleidBox.SelectedIndex != -1)
            {
                data.InsertQuery(lastnameBox.Text, NameBox.Text, PathonymicBox.Text, (int)roleidBox.SelectedValue);
                DataGrid.ItemsSource = data.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }

        private void deldata_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedItem != null && lastnameBox.Text != "" && NameBox.Text != "" && PathonymicBox.Text != "")
            {
                int id = (int)(DataGrid.SelectedItem as DataRowView).Row[0];
                data.DeleteQuery(id);
                DataGrid.ItemsSource = data.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }

        private void remdata_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedItem != null && lastnameBox.Text != "" && NameBox.Text != "" && PathonymicBox.Text != "" && roleidBox.SelectedIndex != -1)
            {
                Object id = (DataGrid.SelectedItem as DataRowView).Row[0];
                data.UpdateQuery(lastnameBox.Text, NameBox.Text, PathonymicBox.Text, (int)roleidBox.SelectedValue, Convert.ToInt32(id));
                DataGrid.ItemsSource = data.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid.SelectedItem != null)
            {
                lastnameBox.Text = Convert.ToString((DataGrid.SelectedItem as DataRowView).Row[1]);
                NameBox.Text = Convert.ToString((DataGrid.SelectedItem as DataRowView).Row[2]);
                PathonymicBox.Text = Convert.ToString((DataGrid.SelectedItem as DataRowView).Row[3]);
            }
        }
    }
}
