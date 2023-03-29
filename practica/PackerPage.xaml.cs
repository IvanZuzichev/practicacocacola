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
    /// Логика взаимодействия для PackerPage.xaml
    /// </summary>
    public partial class PackerPage : Page
    {
        PackerTableAdapter packer = new PackerTableAdapter();
        public PackerPage()
        {
            InitializeComponent();
            PackerGrid.ItemsSource = packer.GetData();
        }

        private void addpac_Click(object sender, RoutedEventArgs e)
        {
            if (PackerGrid.SelectedItem != null)
            {
                packer.InsertQuery(pacBox.Text);
                PackerGrid.ItemsSource = packer.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }

        private void delpac_Click(object sender, RoutedEventArgs e)
        {
            if (PackerGrid.SelectedItem != null)
            {
                int id = (int)(PackerGrid.SelectedItem as DataRowView).Row[0];
                packer.DeleteQuery(id);
                PackerGrid.ItemsSource = packer.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }

        private void rem_Click(object sender, RoutedEventArgs e)
        {
            if (PackerGrid.SelectedItem != null)
            {
                Object id = (PackerGrid.SelectedItem as DataRowView).Row[0];
                packer.UpdateQuery(pacBox.Text, Convert.ToInt32(id));
                PackerGrid.ItemsSource = packer.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            perexod.Content = new StorePage();
        }

        private void jsonbutton_Click(object sender, RoutedEventArgs e)
        {
            List<daniiPac> forImport = practikaConverter.DeserializeObject<List<daniiPac>>();
            foreach (var item in forImport)
            {
                packer.InsertQuery(Convert.ToString(item.NamePacker));
            }
            PackerGrid.ItemsSource = null;
            PackerGrid.ItemsSource = packer.GetData();
        }

        private void PackerGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PackerGrid.SelectedItem != null)
            {
                pacBox.Text = Convert.ToString((PackerGrid.SelectedItem as DataRowView).Row[1]);
            }
        }
    }
}
