using QLTV_MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;

namespace QLTV_MVVM.ViewModel
{
    public class AddingReaderViewModel: BaseViewModel
    {
        public bool IsAddingReader { get; set; }


        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }

        private string _Address;
        public string Address { get => _Address; set { _Address = value; OnPropertyChanged(); } }

        private DateTime _DayOfbirth = System.DateTime.Today;
        public DateTime DayOfbirth { get => _DayOfbirth; set { _DayOfbirth = value; OnPropertyChanged(); } }

        private DateTime _RegistrationDate = System.DateTime.Today;
        public DateTime RegistrationDate { get => _RegistrationDate; set { _RegistrationDate = value; OnPropertyChanged(); } }

        public ICommand AddReader { get; set; }

        public AddingReaderViewModel()
        {
            AddReader = new RelayCommand<AddingReaderWindow>((p) => { return true; }, (p) => {
                var name = Name;
                var address = Address;
                var dayOfBirth = DayOfbirth;
                var redistrationDate = RegistrationDate;

                DocGia docGia = new DocGia();
                docGia.HoTen = name;
                docGia.DiaChi = address;
                docGia.NgaySinh = dayOfBirth;
                docGia.NgayTaoThe = redistrationDate;
                DataProvider.Ins.DB.DocGias.Add(docGia);
                if (DataProvider.Ins.DB.SaveChanges() == 1)
                {
                    IsAddingReader = true;
                    Name = "";
                    Address = "";
                    DayOfbirth = System.DateTime.Today;
                    RegistrationDate = System.DateTime.Today;

                    p.Close();    
                }
                else
                {
                    MessageBox.Show("Lỗi không được đọc giả");
                }
            });

        }
    }
}
