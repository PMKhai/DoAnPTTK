using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using QLTV_MVVM.Model;

namespace QLTV_MVVM.ViewModel
{
    public class UserControlReaders: BaseViewModel
    {

        public ICommand CloseWindowCommand { get; set; }

        public UserControlReaders()
        {
            CloseWindowCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) => {     });

            var db = DataProvider.Ins.DB.DocGias.ToList();

        }
    }
}
