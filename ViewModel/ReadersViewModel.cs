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
        public ICommand SelectedItemCommand { get; set; }

        public ReadersViewModel()
        {
            LoadDBCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) => {
                if (p == null)
                    return;
                var db = DataProvider.Ins.DB.DocGias.ToList();
                p.ItemsSource= db;
            });

            SelectedItemCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) => {
                if (p == null)
                    return;
                DocGia dg = (DocGia)p.SelectedItem as DocGia;
            });

        }
    }
}
