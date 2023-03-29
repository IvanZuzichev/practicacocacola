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
    /// Логика взаимодействия для RolePage.xaml
    /// </summary>
    public partial class RolePage : Page
    {
            roleTableAdapter roles = new roleTableAdapter();
        public RolePage()
        {
            InitializeComponent();
            RoleGrid.ItemsSource = roles.GetData();
        }

        private void addrole_Click(object sender, RoutedEventArgs e)
        {
            if (dataBox.Text != "")
            {
                roles.InsertQuery(dataBox.Text);
                RoleGrid.ItemsSource = roles.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
            
                roletxt.Text = "функция в стадии разработки программистом.";
        }

        private void delrole_Click(object sender, RoutedEventArgs e)
        {
            if (RoleGrid.SelectedItem != null)
            {
                int id = (int)(RoleGrid.SelectedItem as DataRowView).Row[0];
                roles.DeleteQuery(id);
                RoleGrid.ItemsSource = roles.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
             roletxt.Text = "функция в стадии разработки программистом.";
        }

        private void remrole_Click(object sender, RoutedEventArgs e)
        {
            if (RoleGrid.SelectedItem != null && dataBox.Text != "")
            {
                Object id = (RoleGrid.SelectedItem as DataRowView).Row[0];
                roles.UpdateQuery(dataBox.Text, Convert.ToInt32(id));
                RoleGrid.ItemsSource = roles.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
            roletxt.Text = "функция в стадии разработки программистом.";
        }

        private void RoleGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RoleGrid.SelectedItem != null)
            {
                dataBox.Text = Convert.ToString((RoleGrid.SelectedItem as DataRowView).Row[1]);
            }
        }
    }
}
