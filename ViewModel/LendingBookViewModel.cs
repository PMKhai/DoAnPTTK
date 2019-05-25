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
        private ObservableCollection<Model.LoaiSach> _LoaiSach;
        public ObservableCollection<Model.LoaiSach> LoaiSach { get => _LoaiSach; set { _LoaiSach = value; OnPropertyChanged(); } }
        private ObservableCollection<Model.Sach> _Sach;
        public ObservableCollection<Model.Sach> Sach { get => _Sach; set { _Sach = value; OnPropertyChanged(); } }
        private ObservableCollection<Model.PhieuMuon> _PhieuMuon;
        public ObservableCollection<Model.PhieuMuon> PhieuMuon { get => _PhieuMuon; set { _PhieuMuon = value; OnPropertyChanged(); } }
        private ObservableCollection<Model.LentBook> _SachDcThue;
        public ObservableCollection<Model.LentBook> SachDcThue { get => _SachDcThue; set { _SachDcThue = value; OnPropertyChanged(); } }
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
        private Model.DocGia _SelectedDocGia;
        public Model.DocGia SelectedDocGia
        {
            get => _SelectedDocGia;
            set
            {
                _SelectedDocGia = value;
                OnPropertyChanged();
                if (SelectedDocGia != null)
                {
                   Name = SelectedDocGia.HoTen;
                   // _Phone
                    Address = SelectedDocGia.DiaChi;
                    DayOfbirth = SelectedDocGia.NgaySinh;
                    RegistrationDate = SelectedDocGia.NgayTaoThe;
                   
                }
            }
        }
        private string _MaPhieu;
        public string MaPhieu { get => _MaPhieu; set { _MaPhieu = value; OnPropertyChanged(); } }
        private DateTime? _LendingDay;
        public DateTime? LendingDay { get => _LendingDay; set { _LendingDay = value; OnPropertyChanged(); } }
        private DateTime? _ReturnDay;
        public DateTime? ReturnDay { get => _ReturnDay; set { _ReturnDay = value; OnPropertyChanged(); } }
        private Model.PhieuMuon _SelectedPhieuMuon;
        public Model.PhieuMuon SelectedPhieuMuon
        {
            get => _SelectedPhieuMuon;
            set
            {
                _SelectedPhieuMuon = value;
                OnPropertyChanged();
                if (SelectedPhieuMuon != null)
                {
           
                    SelectedDocGia = SelectedPhieuMuon.DocGia;
                    MaPhieu = SelectedPhieuMuon.IDPm.ToString();
                    // _Phone
                    LendingDay = SelectedPhieuMuon.NgayMuon;
                    ReturnDay = SelectedPhieuMuon.KyHanTra;


                    //////
                    var bookList = SelectedPhieuMuon.ChiTietPhieuMuons;

                    SachDcThue = new ObservableCollection<LentBook>();



                    int i = 1;
                    foreach (var item in bookList)
                    {
                        

                        LentBook a = new LentBook();
                        a.STT = i;
                        a.DonVi = "Quyển";
                        a.SoLuong = item.SoLuong;
                        a.Sach = item.Sach;
                        SachDcThue.Add(a);
                        i++;
                    }
                }
            }
        }
        private string _TacGia;
        public string TacGia { get => _TacGia; set { _TacGia = value; OnPropertyChanged(); } }
        private string _NhaXB;
        public string NhaXB { get => _NhaXB; set { _NhaXB = value; OnPropertyChanged(); } }

        private DateTime? _NamXB;
        public DateTime? NamXB { get => _NamXB; set { _NamXB = value; OnPropertyChanged(); } }
        private Model.Sach _SelectedSach;
        public Model.Sach SelectedSach
        {
            get => _SelectedSach;
            set
            {
                _SelectedSach = value;
                OnPropertyChanged();
                if (SelectedSach != null)
                {
                    TacGia = SelectedSach.TacGia;
                    NhaXB = SelectedSach.NhaXB;
                    NamXB = SelectedSach.NamXB;
                }
            }
        }
        private Model.LoaiSach _SelectedLoaiSach;
        public Model.LoaiSach SelectedLoaiSach
        {
            get => _SelectedLoaiSach;
            set
            {
                _SelectedLoaiSach = value;
                OnPropertyChanged();
                if (SelectedLoaiSach != null)
                {
                    Sach = new ObservableCollection<Model.Sach>(SelectedLoaiSach.Saches);
                }
            }
        }
        private Model.LentBook _SelectedSachDcThue;
        public Model.LentBook SelectedSachDcThue
        {
            get => _SelectedSachDcThue;
            set
            {
                _SelectedSachDcThue = value;
                OnPropertyChanged();
                if (SelectedSachDcThue != null)
                {
                    SelectedLoaiSach = SelectedSachDcThue.Sach.LoaiSach;
                    SelectedSach = SelectedSachDcThue.Sach;
                }
            }
        }
        public ICommand LoadDBCommand { get; set; }
       
        
        public LendingBookViewModel()
        {
            DocGia = new ObservableCollection<Model.DocGia>(DataProvider.Ins.DB.DocGias);
            PhieuMuon = new ObservableCollection<Model.PhieuMuon>(DataProvider.Ins.DB.PhieuMuons);
            
            LoaiSach = new ObservableCollection<Model.LoaiSach>(DataProvider.Ins.DB.LoaiSaches);
            LoadDBCommand = new RelayCommand<ComboBox>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                var db = DataProvider.Ins.DB.DocGias.ToList();
                p.ItemsSource = db;
            });
        }
        void LoadChiTietPM()
        {
           

        }
    }
}
