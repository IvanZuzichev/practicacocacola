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
using System.Windows.Navigation;
using System.Windows.Shapes;
using practica.PRACTDataSetTableAdapters;

namespace practica
{

    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
            
        }

        private void role_Click(object sender, RoutedEventArgs e)
        {
            DisplayAdmina.Content = new RolePage();
        }
        private void worker_Click(object sender, RoutedEventArgs e)
        {
            DisplayAdmina.Content = new DataPage();
        }
        private void changelog_Click(object sender, RoutedEventArgs e)
        {
            DisplayAdmina.Content = new LogPage();
        }

        private void nazad_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current.MainWindow as MainWindow).adminperexod.Content = null;
        }
    }
}
