using QLTV_MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QLTV_MVVM.ViewModel
{
    public class LoginViewModel: BaseViewModel
    {
        public bool IsLogin { get; set; }

        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }

        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }

        public ICommand LoginCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }

        public LoginViewModel()
        {
            Password = "";
            UserName = "";
            IsLogin = false;
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { Login(p); });

            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; });

        }

        void Login(Window p)
        {
        
            if (p == null)
            {
                return; 
            }
            string passEncode = MD5Hash(Base64Encode(Password));
            var count = DataProvider.Ins.DB.TaiKhoans.Where(x => x.UserName == UserName && x.MatKhau == passEncode).Count();
            if(count > 0 )
            {
                
                IsLogin = true;
                MainWindow mainWindow = new MainWindow();
                p.Hide();
                mainWindow.ShowDialog();
                p.Close();
            }
            else
            {
                IsLogin = false;
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu !");
            }
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }



        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
    }
}
