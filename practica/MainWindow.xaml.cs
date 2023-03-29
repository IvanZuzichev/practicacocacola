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
    public partial class MainWindow : Window
    {
        usersTableAdapter users = new usersTableAdapter();
        dataTableAdapter data = new dataTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void avtorization_Click(object sender, RoutedEventArgs e)
        {
            var alllogin = users.GetData().Rows;
            var allrole = data.GetData().Rows;
            for (int i = 0; i < alllogin.Count; i++)
            {
                if (alllogin[i][1].ToString() == logBox.Text && alllogin[i][2].ToString() == passwordBox.Password)
                {
                    int userid = (int)alllogin[i][0];
                    int roleid = 0;
                    for (int x = 0; x < allrole.Count; x++)
                    {
                        if ((int)allrole[x][0] == userid)
                        {
                            roleid = (int)allrole[x][4];
                        }
                    }
                    switch (roleid)
                    {
                        case 1:
                            adminperexod.Content = new AdminPage();
                            return;
                        case 2:
                            adminperexod.Content = new TovarPage();
                            return;
                        case 5:
                            adminperexod.Content = new BuyPage();
                            return;
                    }
                }
            }
            nacalo.Text = "Вы ввели неверные значения";
        }
    }
}
