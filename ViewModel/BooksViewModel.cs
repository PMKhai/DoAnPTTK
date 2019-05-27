using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class BooksViewModel: BaseViewModel
    {

        private ObservableCollection<Model.LoaiSach> _LoaiSach;
        public ObservableCollection<Model.LoaiSach> LoaiSach { get => _LoaiSach; set { _LoaiSach = value; OnPropertyChanged(); } }

        public ICommand LoadDBCommand { get; set; }

        public BooksViewModel()
        {
            LoaiSach = new ObservableCollection<Model.LoaiSach>(DataProvider.Ins.DB.LoaiSaches);


            LoadDBCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) => {
                if (p == null)
                    return;
                var db = DataProvider.Ins.DB.Saches.ToList();

                foreach(Sach s in db)
                {
                    var ls = DataProvider.Ins.DB.LoaiSaches.Find(s.IDLoai);
                    if (ls == null)
                        return;
                    s.TenLoaiSach = ls.TenLoai;
                }

                if (db == null)
                {
                    MessageBox.Show("Không thể hiển thị danh sách sách!", "Thông báo lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                p.ItemsSource = db;
            });
        }

    }
}
