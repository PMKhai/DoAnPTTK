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
    public class ResetPasswordViewModel :BaseViewModel
    {
        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }
        private string _CurrentPassword;
        public string CurrentPassword { get => _CurrentPassword; set { _CurrentPassword = value; OnPropertyChanged(); } }
        private string _NewPassword;
        public string NewPassword { get => _NewPassword; set { _NewPassword = value; OnPropertyChanged(); } }
        private string _ConfirmPassword;
        public string ConfirmPassword { get => _ConfirmPassword; set { _ConfirmPassword = value; OnPropertyChanged(); } }
        public ICommand CurrentPasswordChangedCommand { get; set; }
        public ICommand NewPasswordChangedCommand { get; set; }
        public ICommand ConfirmPasswordChangedCommand { get; set; }
        public ICommand OKCommand { get; set; }
        public ResetPasswordViewModel()
        {
            CurrentPassword = "";
            NewPassword = "";
            ConfirmPassword = "";
            UserName = getCurrUserName();
            CurrentPasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { CurrentPassword = p.Password; });
            NewPasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { NewPassword = p.Password; });
            ConfirmPasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { ConfirmPassword = p.Password; });
            OKCommand = new RelayCommand<Object>((p) => { return true; }, (p) => {
                if(CurrentPassword == "" || NewPassword == "" || ConfirmPassword == "")
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin !!!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                string passEncode = MD5Hash(Base64Encode(CurrentPassword));
                var count = DataProvider.Ins.DB.TaiKhoans.Where(x => x.UserName == UserName && x.MatKhau == passEncode).Count();
                if (count > 0)
                {
                    if(NewPassword == ConfirmPassword)
                    {
                        var user = DataProvider.Ins.DB.TaiKhoans.Find(UserName);

                        if (user == null)
                        {
                            MessageBox.Show("Không thể chỉnh sửa mật khẩu !", "Thông báo lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        passEncode = MD5Hash(Base64Encode(NewPassword));
                        user.MatKhau = passEncode;

                        DataProvider.Ins.DB.SaveChanges();
                        MessageBox.Show("Thay đổi mật khẩu thành công!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Xác nhận mật khẩu không khớp! Vui lòng nhập lại", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                   
                }
                else
                {
     
                    MessageBox.Show("Mật khẩu hiện tại không đúng! Vui lòng nhập lại", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                
            });
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
        string getCurrUserName()
        {
            LoginWindow loginWindow = new LoginWindow();


            if (loginWindow.DataContext == null)
                return null;
            var loginMV = loginWindow.DataContext as LoginViewModel;
            return loginMV.UserName;
        }
    }
}
