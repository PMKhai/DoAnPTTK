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
    public class ReadersViewModel: BaseViewModel
    {

        private string _InfoSearch;
        public string InfoSearch { get => _InfoSearch; set { _InfoSearch = value; OnPropertyChanged(); } }
        public ICommand SearchCommand { get; set; }

        public ICommand LoadDBCommand { get; set; }
        public ICommand LostFocusCommand { get; set; }
        public ICommand DisplayAddingReeaderCommand { get; set; }
        
        public ICommand DeleteCommand { get; set; }
        public ICommand TextChangedCommand { get; set; }
        public ReadersViewModel()
        {
            LoadDBCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) => {
                if (p == null)
                    return;
                var db = DataProvider.Ins.DB.DocGias.ToList();

                if (db == null)
                {
                    MessageBox.Show("Không thể hiển thị danh đọc giả!", "Thông báo lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                p.ItemsSource = db;
            });

            LostFocusCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) => {
                if (p == null)
                    return;
                DocGia dg = (DocGia)p.SelectedItem as DocGia;
               
                var reader = DataProvider.Ins.DB.DocGias.Find(dg.IDDg);

                if (reader == null)
                {
                    MessageBox.Show("Không thể chỉnh sửa đọc giả!", "Thông báo lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                reader.HoTen = dg.HoTen;
                reader.NgaySinh = dg.NgaySinh;
                reader.DiaChi = dg.DiaChi;
                reader.NgayTaoThe = dg.NgayTaoThe;

                DataProvider.Ins.DB.SaveChanges();

            });
            //DeleteCommand = new RelayCommand<KeyEventArgs>((p) => { return true; }, (p) => {
            //    if (p == null)
            //        return;
            //    DocGia dg = (DocGia)p.SelectedItem as DocGia;

            //    var reader = DataProvider.Ins.DB.DocGias.Find(dg.IDDg);

            //    if (reader == null)
            //    {
            //        MessageBox.Show("Không thể chỉnh sửa đọc giả!", "Thông báo lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            //        return;
            //    }

            //    reader.HoTen = dg.HoTen;
            //    reader.NgaySinh = dg.NgaySinh;
            //    reader.DiaChi = dg.DiaChi;
            //    reader.NgayTaoThe = dg.NgayTaoThe;

            //    DataProvider.Ins.DB.SaveChanges();

            //});

            DisplayAddingReeaderCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) => {
                AddingReaderWindow window = new AddingReaderWindow();
                window.ShowDialog();
                p.ItemsSource = DataProvider.Ins.DB.DocGias.ToList();
            });
            TextChangedCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) => { InfoSearch = p.Text; });

            SearchCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) => {
                var stringSearch = InfoSearch;
                var query = (from k in DataProvider.Ins.DB.DocGias.ToList() where k.HoTen.ToLower().Contains(stringSearch.ToLower()) select k).ToList();

                if (p == null)
                    return;
                p.ItemsSource = query;
            });
        }
    }
}
