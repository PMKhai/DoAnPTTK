using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QLTV_MVVM.ViewModel
{
    public class MainViewModel: BaseViewModel
    {
        public bool IsLoaded = false;
        public ICommand LoadedWindowCommand { get; set; }

        public MainViewModel()
        {
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                //IsLoaded = true;

                if (p == null)
                    return;

             //   p.Hide();
                LoginWindow loginWindow = new LoginWindow();
                

                if (loginWindow.DataContext == null)
                    return;
                var loginMV = loginWindow.DataContext as LoginViewModel;
                loginWindow.Close();
                //if (loginMV.IsLogin == true)
                //{

                    
                //}
               
            });
        }

    }
}
