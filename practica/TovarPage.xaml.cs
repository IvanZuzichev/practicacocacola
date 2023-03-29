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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static practica.PRACTDataSet;

namespace practica
{
    /// <summary>
    /// Логика взаимодействия для TovarPage.xaml
    /// </summary>
    public partial class TovarPage : Page
    {
        ProductTableAdapter prod = new ProductTableAdapter();

        TypeGasTableAdapter gas = new TypeGasTableAdapter();
        CountryTableAdapter country = new CountryTableAdapter();
        StoreTableAdapter store = new StoreTableAdapter();

        public TovarPage()
        {
            InitializeComponent();
            TovarGrid.ItemsSource = prod.GetData();

            combotypedrink.ItemsSource = gas.GetData();
            combotypedrink.DisplayMemberPath = "Gas";
            combotypedrink.SelectedValuePath = "id";

            comboCountry.ItemsSource = country.GetData();
            comboCountry.DisplayMemberPath = "Contry";
            comboCountry.SelectedValuePath = "id";

            comboStore.ItemsSource = store.GetData();
            comboStore.DisplayMemberPath = "data";
            comboStore.SelectedValuePath = "idstore";
        }

        private void addtovar_Click(object sender, RoutedEventArgs e)
        {
            if (TovarGrid.SelectedItem != null && comboCountry.SelectedIndex != -1 && combotypedrink.SelectedIndex != -1 && comboStore.SelectedIndex != -1)
            {
                prod.InsertQuery((int)combotypedrink.SelectedValue, (int)comboCountry.SelectedValue, (int)comboStore.SelectedValue);
                TovarGrid.ItemsSource = prod.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }
        private void deltovar_Click(object sender, RoutedEventArgs e)
        {
            if (TovarGrid.SelectedItem != null)
            {
                int id = (int)(TovarGrid.SelectedItem as DataRowView).Row[0];
                prod.DeleteQuery(id);
                TovarGrid.ItemsSource = prod.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }
        private void remtovar_Click(object sender, RoutedEventArgs e)
        {
            if (TovarGrid.SelectedItem != null && comboCountry.SelectedIndex != -1 && combotypedrink.SelectedIndex != -1 && comboStore.SelectedIndex != -1)
            {
                Object id = (TovarGrid.SelectedItem as DataRowView).Row[0];
                prod.UpdateQuery((int)combotypedrink.SelectedValue, (int)comboCountry.SelectedValue, (int)comboStore.SelectedValue, Convert.ToInt32(id));
                TovarGrid.ItemsSource = prod.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }

        private void typedrinkButton_Click(object sender, RoutedEventArgs e)
        {
            countryperexod.Content = new DrinkPage();
        }

        private void countryButton_Click(object sender, RoutedEventArgs e)
        {
            countryperexod.Content = new CountryPage();
        }

        private void sklad_Click(object sender, RoutedEventArgs e)
        {
            countryperexod.Content = new StorePage();
        }

        private void countryperexod_Navigated(object sender, NavigationEventArgs e)
        {
            
        }

        private void regButton_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current.MainWindow as MainWindow).adminperexod.Content = null;
        }
    }
}
