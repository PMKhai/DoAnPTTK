using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using QLTV_MVVM.Model;
using QLTV_MVVM.UserControl_QLTV;

namespace QLTV_MVVM.ViewModel
{
    public class StatisticalViewModel: BaseViewModel
    {
        private DateTime _NgayBatDau;
        public DateTime NgayBatDau { get => _NgayBatDau; set { _NgayBatDau = value; OnPropertyChanged(); } }
        private DateTime _NgayKetThuc;
        public DateTime NgayKetThuc { get => _NgayKetThuc; set { _NgayKetThuc = value; OnPropertyChanged(); } }
        public ICommand LoadDBCommand { get; set; }
        public ICommand SelectedDateChangedCommand { get; set; }

        public StatisticalViewModel()
        {
            NgayBatDau = DateTime.Today;
            NgayKetThuc = DateTime.Today;

            LoadDBCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) => {
                if (p == null)
                    return;
                var db = DataProvider.Ins.DB.ChiTietPhieuMuons.ToList();

                if (db == null)
                {
                    MessageBox.Show("Không thể hiển thị danh đọc giả!", "Thông báo lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }


                p.ItemsSource = db;
            });
            SelectedDateChangedCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) => {
                MessageBox.Show("");
            });
        }
    }
}
