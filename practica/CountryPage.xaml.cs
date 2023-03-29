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
    /// Логика взаимодействия для CountryPage.xaml
    /// </summary>
    public partial class CountryPage : Page
    {
        CountryTableAdapter country = new CountryTableAdapter();
        public CountryPage()
        {
            InitializeComponent();
            CountryGrid.ItemsSource = country.GetData();
        }

        private void addlog_Click(object sender, RoutedEventArgs e)
        {
            if (CountryGrid.SelectedItem != null)
            {
                country.InsertQuery(countryBox.Text);
                CountryGrid.ItemsSource = country.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }

        private void dellog_Click(object sender, RoutedEventArgs e)
        {
            if (CountryGrid.SelectedItem != null)
            {
                int id = (int)(CountryGrid.SelectedItem as DataRowView).Row[0];
                country.DeleteQuery(id);
                CountryGrid.ItemsSource = country.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }

        private void remlog_Click(object sender, RoutedEventArgs e)
        {
            if (CountryGrid.SelectedItem != null)
            {
                Object id = (CountryGrid.SelectedItem as DataRowView).Row[0];
                country.UpdateQuery(countryBox.Text, Convert.ToInt32(id));
                CountryGrid.ItemsSource = country.GetData();
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
        private void glavaperexod_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void CountryGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CountryGrid.SelectedItem != null)
            {
                countryBox.Text = Convert.ToString((CountryGrid.SelectedItem as DataRowView).Row[1]);
            }
        }
    }
}
