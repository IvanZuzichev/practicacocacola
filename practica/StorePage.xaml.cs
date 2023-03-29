using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using practica.PRACTDataSetTableAdapters;
namespace practica
{
    public partial class StorePage : Page
    {
        StoreTableAdapter store = new StoreTableAdapter();
        PackerTableAdapter packer = new PackerTableAdapter();
        public StorePage()
        {
            InitializeComponent();
            PackGrid.ItemsSource = store.GetData();
            namepacBox.ItemsSource = packer.GetData();
            namepacBox.DisplayMemberPath = "NamePacker";
            namepacBox.SelectedValuePath = "idPacker";
        }
        private void addpac_Click(object sender, RoutedEventArgs e)
        {
            if (PackGrid.SelectedItem != null && namepacBox.SelectedIndex != -1)
            {
                store.InsertQuery(pacBox.Text, (int)namepacBox.SelectedValue);
                PackGrid.ItemsSource = store.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }
        private void delpac_Click(object sender, RoutedEventArgs e)
        {
            if (PackGrid.SelectedItem != null)
            {
                int id = (int)(PackGrid.SelectedItem as DataRowView).Row[0];
                store.DeleteQuery(id);
                PackGrid.ItemsSource = store.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }
        private void rem_Click(object sender, RoutedEventArgs e)
        {
            if (PackGrid.SelectedItem != null && namepacBox.SelectedIndex != -1)
            {
                Object id = (PackGrid.SelectedItem as DataRowView).Row[0];
                store.UpdateQuery(pacBox.Text, (int)namepacBox.SelectedValue, Convert.ToInt32(id));
                PackGrid.ItemsSource = store.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }
        private void back_Click(object sender, RoutedEventArgs e)
        {
            perexod.Content = new TovarPage();
        }

        private void pack_Click(object sender, RoutedEventArgs e)
        {
            perexod.Content = new PackerPage();
        }

        private void PackGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PackGrid.SelectedItem != null)
            {
                pacBox.Text = Convert.ToString((PackGrid.SelectedItem as DataRowView).Row[1]);
            }
        }
    }
}
