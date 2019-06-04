using QLTV_MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;

namespace QLTV_MVVM.ViewModel
{
    public class AddingKindOfBookViewModel : BaseViewModel
    {
        private string _TenLoaiSach;
        public string TenLoaiSach { get => _TenLoaiSach; set { _TenLoaiSach = value; OnPropertyChanged(); } }
        public ICommand AddKindOfBookCommand { get; set; }

        public AddingKindOfBookViewModel()
        {
            AddKindOfBookCommand = new RelayCommand<AddingKindOfBookWindow>((p) => { return true; }, (p) => {
                if (TenLoaiSach == null )
                {
                    MessageBox.Show("Không thể thêm loại sách!", "Thông báo lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                LoaiSach loaiSach = new LoaiSach();
                loaiSach.TenLoai = TenLoaiSach;
                DataProvider.Ins.DB.LoaiSaches.Add(loaiSach);
                if (DataProvider.Ins.DB.SaveChanges() == 1)
                {
                    p.Close();
                }
                else
                {
                    MessageBox.Show("Không thể thêm loại sách!", "Thông báo lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

            });
        }
    }
}
