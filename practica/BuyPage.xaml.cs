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

namespace practica
{
    internal class danii
    {
        public int idCheque { get; set; }
        public string data { get; set; }

        public int cost { get; set; }

        public int NameUser { get; set; }
    }
    public partial class BuyPage : Page 
    {
        information_chequeTableAdapter infocheck = new information_chequeTableAdapter();
        chequeTableAdapter cheque = new chequeTableAdapter();
        ProductTableAdapter product = new ProductTableAdapter();

        dataTableAdapter dat = new dataTableAdapter();
        public BuyPage()
        {
            InitializeComponent();
            InfoCheckGrid.ItemsSource = infocheck.GetData();

            nameuser.ItemsSource = dat.GetData();
            nameuser.DisplayMemberPath = "Lastname";
            nameuser.SelectedValuePath = "id";

            CheckGrid.ItemsSource = cheque.GetData();

            idProductBox.ItemsSource = product.GetData();
            idProductBox.DisplayMemberPath = "typeDrink";
            idProductBox.SelectedValuePath = "IdProduct";

            idCheckBox.ItemsSource = infocheck.GetData();
            idCheckBox.DisplayMemberPath = "cost";
            idCheckBox.SelectedValuePath = "idCheque";
        }
        private void addinfo_Click(object sender, RoutedEventArgs e)
        {
            if (InfoCheckGrid.SelectedItem != null && datatxt.Text != "" && costtxt.Text != "" && idChecktxt.Text != "" && nameuser.SelectedIndex != -1)
            {
                if (Convert.ToInt32(costtxt.Text) < 1)
                {
                    MessageBox.Show("Вы ввели отрицательную стоимость или ноль");
                }
                else
                {
                    infocheck.InsertQuery(Convert.ToInt32(idChecktxt.Text), Convert.ToString(datatxt.Text), Convert.ToSingle(costtxt.Text));
                    InfoCheckGrid.ItemsSource = infocheck.GetData();
                }
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }

        private void delinfo_Click(object sender, RoutedEventArgs e)
        {
            if (InfoCheckGrid.SelectedItem != null)
            {
                int id = (int)(InfoCheckGrid.SelectedItem as DataRowView).Row[0];
                infocheck.DeleteQuery(id);
                InfoCheckGrid.ItemsSource = infocheck.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }

        private void reminfo_Click(object sender, RoutedEventArgs e)
        {
            if (InfoCheckGrid.SelectedItem != null && datatxt.Text != "" && costtxt.Text != "" && idChecktxt.Text != "" && nameuser.SelectedIndex != -1)
            {
                Object id = (InfoCheckGrid.SelectedItem as DataRowView).Row[0];
                infocheck.UpdateQuery(Convert.ToInt32(idChecktxt.Text), Convert.ToString(datatxt.Text), Convert.ToSingle(costtxt.Text), Convert.ToInt32(id));
                InfoCheckGrid.ItemsSource = infocheck.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }
        private void addcheck_Click(object sender, RoutedEventArgs e)
        {
            if (CheckGrid.SelectedItem != null && idCheckBox.SelectedIndex != -1 && idProductBox.SelectedIndex != -1)
            {
                int check = (int)idCheckBox.SelectedValue;
                int producti = (int)idProductBox.SelectedValue;
                cheque.InsertQuery(check, producti);
                CheckGrid.ItemsSource = cheque.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }

        private void delcheck_Click(object sender, RoutedEventArgs e)
        {
            if (CheckGrid.SelectedItem != null)
            {
                int id = (int)(CheckGrid.SelectedItem as DataRowView).Row[0];
                cheque.DeleteQuery(id);
                CheckGrid.ItemsSource = cheque.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }

        private void remcheck_Click(object sender, RoutedEventArgs e)
        {
            if (CheckGrid.SelectedItem != null && idCheckBox.SelectedIndex != -1 && idProductBox.SelectedIndex != -1 )
            {
                int check = (int)idCheckBox.SelectedValue;
                int producti = (int)idProductBox.SelectedValue;

                Object id = (CheckGrid.SelectedItem as DataRowView).Row[0];
                cheque.UpdateQuery(check, producti, Convert.ToInt32(id));

                CheckGrid.ItemsSource = cheque.GetData();
            }
            else
            {
                MessageBox.Show("Поля для ввода пусты, заполните их.");
            }
        }



        private void JButton_Click(object sender, RoutedEventArgs e)
        {
            List<danii> forImport = LabaConverter.DeserializeObject<List<danii>>();
            foreach (var item in forImport)
            {
                infocheck.InsertQuery(item.idCheque, item.data, item.cost);
            }
            InfoCheckGrid.ItemsSource = null;
            InfoCheckGrid.ItemsSource = infocheck.GetData();
        }

        private void MakeCheckButton_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current.MainWindow as MainWindow).adminperexod.Content = null;
        }

        private void InfoCheckGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (InfoCheckGrid.SelectedItem != null)
            {
                datatxt.Text = Convert.ToString((InfoCheckGrid.SelectedItem as DataRowView).Row[1]);
                costtxt.Text = Convert.ToString((InfoCheckGrid.SelectedItem as DataRowView).Row[2]);
                idChecktxt.Text = Convert.ToString((InfoCheckGrid.SelectedItem as DataRowView).Row[3]);
            }
        }
    }
}
