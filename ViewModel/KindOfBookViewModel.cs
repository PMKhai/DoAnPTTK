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
    public class KindOfBookViewModel: BaseViewModel
    {
        public ICommand LoadDBCommand { get; set; }
        public ICommand LostFocusCommand { get; set; }
        public ICommand DisplayAddingKindOfBookCommand { get; set; }

        public KindOfBookViewModel()
        {
            LoadDBCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) => {
                if (p == null)
                    return;
                var db = DataProvider.Ins.DB.LoaiSaches.ToList();
                
                if (db == null)
                {
                    MessageBox.Show("Không thể hiển thị danh sách loại sách!", "Thông báo lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                p.ItemsSource = db;
            });
            LostFocusCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) => {
                if (p == null)
                    return;
                LoaiSach dg = (LoaiSach)p.SelectedItem as LoaiSach;

                var LoaiSach = DataProvider.Ins.DB.LoaiSaches.Find(dg.IdLoai);

                if (LoaiSach == null)
                {
                    MessageBox.Show("Không thể chỉnh sửa loại sách!", "Thông báo lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                LoaiSach.TenLoai = dg.TenLoai;

                DataProvider.Ins.DB.SaveChanges();

            });
            DisplayAddingKindOfBookCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) => {
                AddingKindOfBookWindow window = new AddingKindOfBookWindow();
                window.ShowDialog();
                p.ItemsSource = DataProvider.Ins.DB.LoaiSaches.ToList();
            });
        }
    }
}
