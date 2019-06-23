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
using QLTV_MVVM.UserControl_QLTV;
using QLTV_MVVM.Model;

namespace QLTV_MVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonCloseMenu_click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        LoginWindow loginWD = new LoginWindow();

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;

            var db = loginWD.DataContext;

            System.Reflection.PropertyInfo pi = db.GetType().GetProperty("UserName");
            String username = (String)(pi.GetValue(db, null));

            var acc = DataProvider.Ins.DB.TaiKhoans.Find(username);

            if(acc.ChucVu == false)
            {
                statisical.Visibility = Visibility.Collapsed;
                setting.Visibility = Visibility.Collapsed;
                account.Visibility = Visibility.Collapsed;
                top.Visibility = Visibility.Collapsed;
            }

            switch (index)
            {


                case 0:
                    GridWorking.Children.Clear();
                    GridWorking.Children.Add(new UserControlLendingBook());
                    break;
                case 1:
                    GridWorking.Children.Clear();
                    GridWorking.Children.Add(new UserControlReders());
                    break;
                case 2:
                    GridWorking.Children.Clear();
                    GridWorking.Children.Add(new UserControlBooks());
                    break;
                case 3:
                    GridWorking.Children.Clear();
                    GridWorking.Children.Add(new UserControlKindOfBook());
                    break;
                case 4:
                    GridWorking.Children.Clear();
                    GridWorking.Children.Add(new UserControlStatistical()); 
                    break;
                case 5:
                    GridWorking.Children.Clear();
                    GridWorking.Children.Add(new UserControlAccount());
                    break;
                case 6:
                    GridWorking.Children.Clear();
                    GridWorking.Children.Add(new UserControlSetting());
                    break;
                case 7:
                    GridWorking.Children.Clear();
                    GridWorking.Children.Add(new UserControlProcessOfBook());
                    break;
                case 8:
                    GridWorking.Children.Clear();
                    GridWorking.Children.Add(new UserControlResetPassword());
                    break;
                default:
                    break;
            }
        }
    }
}
