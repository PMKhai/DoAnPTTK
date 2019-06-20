using QLTV_MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QLTV_MVVM.ViewModel
{
    public class AccountViewModel: BaseViewModel
    {
        private ObservableCollection<Model.TaiKhoan> _TaiKhoan;
        public ObservableCollection<Model.TaiKhoan> TaiKhoan { get => _TaiKhoan; set { _TaiKhoan = value; OnPropertyChanged(); } }
        public ICommand UpdateAccountCommand { get; set; }
        private string _InfoSearch;
        public string InfoSearch { get => _InfoSearch; set { _InfoSearch = value; OnPropertyChanged(); } }
        public ICommand SearchCommand { get; set; }
        public ICommand TextChangedCommand { get; set; }
        public AccountViewModel()
        {
            TaiKhoan = new ObservableCollection<Model.TaiKhoan>(DataProvider.Ins.DB.TaiKhoans);

            UpdateAccountCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) => {
                if (p == null)
                    return;
                TaiKhoan dg = (TaiKhoan)p.SelectedItem as TaiKhoan;

                var acc = DataProvider.Ins.DB.TaiKhoans.Find(dg.UserName);

                if (acc == null)
                {
                    MessageBox.Show("Không thể chỉnh sửa tài khoản!", "Thông báo lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                acc.HoTen = dg.HoTen;
                acc.SDT = dg.SDT;
                acc.DiaChi = dg.DiaChi;

                DataProvider.Ins.DB.SaveChanges();

            });
           
            TextChangedCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) => { InfoSearch = p.Text; });

            SearchCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) => {
                var stringSearch = InfoSearch;
                var query = (from k in DataProvider.Ins.DB.TaiKhoans.ToList() where k.UserName.ToLower().Contains(stringSearch.ToLower()) select k).ToList();

                if (p == null)
                    return;
                p.ItemsSource = query;
            });
        }
    }
}
