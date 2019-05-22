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

        public ICommand LoadDBCommand { get; set; }
        public ICommand LostFocusCommand { get; set; }
        public ICommand DisplayAddingReeaderCommand { get; set; }

        public ReadersViewModel()
        {
            LoadDBCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) => {
                if (p == null)
                    return;
                var db = DataProvider.Ins.DB.DocGias.ToList();
                p.ItemsSource = db;
            });

            LostFocusCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) => {
                if (p == null)
                    return;
                DocGia dg = (DocGia)p.SelectedItem as DocGia;

                var reader = DataProvider.Ins.DB.DocGias.Find(dg.IDDg);

                reader.HoTen = dg.HoTen;
                reader.NgaySinh = dg.NgaySinh;
                reader.DiaChi = dg.DiaChi;
                reader.NgayTaoThe = dg.NgayTaoThe;

                DataProvider.Ins.DB.SaveChanges();

            });

            DisplayAddingReeaderCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) => {
                AddingReaderWindow window = new AddingReaderWindow();
                window.ShowDialog();
                p.ItemsSource = DataProvider.Ins.DB.DocGias.ToList();
            });
        }
    }
}
