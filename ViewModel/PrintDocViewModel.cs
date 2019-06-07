using QLTV_MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace QLTV_MVVM.ViewModel
{
    public class PrintDocViewModel : BaseViewModel
    {
        
        
        
        public PhieuMuon PhieuMuon { get; set; }
        public ObservableCollection<Model.LentBook> SachDcThue { get; set; }
        public string TongCong { get; set; }
        public ICommand PrintCommand { get; set; }
        public PrintDocViewModel()
        {
           
            PrintCommand = new RelayCommand<PrintDoc>((p) => { return true; }, (p) => {
                if (p == null)
                    return;

                PrintDialog printDlg = new PrintDialog();
                p.btnPrint.Visibility = System.Windows.Visibility.Hidden;
                printDlg.PrintVisual(p, "User Control Printing.");
                p.Close();

            });
        }
    }
}
