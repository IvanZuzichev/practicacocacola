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
using practica.PRACTDataSetTableAdapters;
using static practica.PRACTDataSet;


namespace practica
{
    /// <summary>
    /// Логика взаимодействия для DrinkPage.xaml
    /// </summary>
    public partial class DrinkPage : Page
    {
        TypeGasTableAdapter gas = new TypeGasTableAdapter();
        public DrinkPage()
        {
            InitializeComponent();
            GasGrid.ItemsSource = gas.GetData();
        }

        private void glavaperexod_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void addgas_Click(object sender, RoutedEventArgs e)
        {
            if (GasGrid.SelectedItem != null)
            {
                gas.InsertQuery(gasBox.Text);
                GasGrid.ItemsSource = gas.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }

        private void delgas_Click(object sender, RoutedEventArgs e)
        {
            if (GasGrid.SelectedItem != null)
            {
                int id = (int)(GasGrid.SelectedItem as DataRowView).Row[0];
                gas.DeleteQuery(id);
                GasGrid.ItemsSource = gas.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }

        private void remgas_Click(object sender, RoutedEventArgs e)
        {
            if (GasGrid.SelectedItem != null)
            {
                Object id = (GasGrid.SelectedItem as DataRowView).Row[0];
                gas.UpdateQuery(gasBox.Text, Convert.ToInt32(id));
                GasGrid.ItemsSource = gas.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            glavaperexod.Content = new TovarPage();
        }

        private void GasGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GasGrid.SelectedItem != null)
            {
                gasBox.Text = Convert.ToString((GasGrid.SelectedItem as DataRowView).Row[1]);
            }
        }
    }
}
