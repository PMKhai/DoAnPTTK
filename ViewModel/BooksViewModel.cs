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
        private ObservableCollection<Model.Sach> _Sach;
        public ObservableCollection<Model.Sach> Sach { get => _Sach; set { _Sach = value; OnPropertyChanged(); } }
        public ICommand LoadDBCommand { get; set; }
        public ICommand DisplayAddingBookCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public BooksViewModel()
        {
            LoaiSach = new ObservableCollection<Model.LoaiSach>(DataProvider.Ins.DB.LoaiSaches);
            

            LoadDBCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) => {
                if (p == null)
                    return;
               // var db = DataProvider.Ins.DB.Saches.ToList();
                Sach = new ObservableCollection<Sach>(DataProvider.Ins.DB.Saches);
                foreach (Sach s in Sach)
                {
                    var ls = DataProvider.Ins.DB.LoaiSaches.Find(s.IDLoai);
                    if (ls == null)
                        return;
                    s.TenLoaiSach = ls.TenLoai;
                }

                if (Sach == null)
                {
                    MessageBox.Show("Không thể hiển thị danh sách sách!", "Thông báo lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                p.ItemsSource = Sach;
            });

            DisplayAddingBookCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) => {
                AddingBookWindow wd = new AddingBookWindow();
                wd.ShowDialog();
                Sach = new ObservableCollection<Sach>(DataProvider.Ins.DB.Saches);
                foreach (Sach s in Sach)
                {
                    var ls = DataProvider.Ins.DB.LoaiSaches.Find(s.IDLoai);
                    if (ls == null)
                        return;
                    s.TenLoaiSach = ls.TenLoai;
                }

                if (Sach == null)
                {
                    MessageBox.Show("Không thể hiển thị danh sách sách!", "Thông báo lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                p.ItemsSource = Sach;
            });
            DeleteCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
             


               
                    DataGridRow dgr = (DataGridRow)(p.ItemContainerGenerator.ContainerFromIndex(p.SelectedIndex));
                    if (!dgr.IsEditing)
                    {
                        // User is attempting to delete the row
                        var result = MessageBox.Show(
                            "Bạn chắc chắn muốn xóa dữ liệu dòng.\n\nTiếp Tục ?",
                            "Xóa Dữ Liệu",
                            MessageBoxButton.YesNo,
                            MessageBoxImage.Question,
                            MessageBoxResult.No);
                        if (result == MessageBoxResult.Yes)
                        {
                            Sach rd = (Sach)p.SelectedItem as Sach;

                            var book = DataProvider.Ins.DB.Saches.Find(rd.IDSach);
                            DataProvider.Ins.DB.Saches.Remove(book);
                            DataProvider.Ins.DB.SaveChanges();
                        Sach.Remove(book);
                        }

                     

                    }
                

               

            });

        }

    }
}
