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
    public class LendingBookViewModel :BaseViewModel
    {
        private ObservableCollection<Model.DocGia> _DocGia;
        public ObservableCollection<Model.DocGia> DocGia { get => _DocGia; set { _DocGia = value; OnPropertyChanged(); } }
        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }
        private string _Phone;
        public string Phone { get => _Phone; set { _Phone = value; OnPropertyChanged(); } }

        private string _Address;
        public string Address { get => _Address; set { _Address = value; OnPropertyChanged(); } }

        private DateTime? _DayOfbirth;
        public DateTime? DayOfbirth { get => _DayOfbirth; set { _DayOfbirth = value; OnPropertyChanged(); } }

        private DateTime? _RegistrationDate;
        public DateTime? RegistrationDate { get => _RegistrationDate; set { _RegistrationDate = value; OnPropertyChanged(); } }
        private Model.DocGia _SelectedItem;
        public Model.DocGia SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                   Name = SelectedItem.HoTen;
                   // _Phone
                    Address = SelectedItem.DiaChi;
                    DayOfbirth = SelectedItem.NgaySinh;
                    RegistrationDate = SelectedItem.NgayTaoThe;
                   
                }
            }
        }
        public ICommand LoadDBCommand { get; set; }
       
        
        public LendingBookViewModel()
        {
            DocGia = new ObservableCollection<Model.DocGia>(DataProvider.Ins.DB.DocGias);
            LoadDBCommand = new RelayCommand<ComboBox>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                var db = DataProvider.Ins.DB.DocGias.ToList();
                p.ItemsSource = db;
            });
        }
    }
}
