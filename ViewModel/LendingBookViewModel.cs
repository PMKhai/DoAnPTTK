using QLTV_MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        private ObservableCollection<Model.TinhTrangPM> _TinhTrangPM;
        public ObservableCollection<Model.TinhTrangPM> TinhTrangPM { get => _TinhTrangPM; set { _TinhTrangPM = value; OnPropertyChanged(); } }


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
        private int _MaPhieu;
        public int MaPhieu { get => _MaPhieu; set { _MaPhieu = value; OnPropertyChanged(); } }
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
                    MaPhieu = SelectedPhieuMuon.IDPm;
                    // _Phone
                    LendingDay = SelectedPhieuMuon.NgayMuon;
                    ReturnDay = SelectedPhieuMuon.KyHanTra;
                    SelectedTinhTrangPM = SelectedPhieuMuon.TinhTrangPM;
                    loadDgrBook();
                    //////
                    
                }
            }
        }
        private Model.TinhTrangPM _SelectedTinhTrangPM;

        public Model.TinhTrangPM SelectedTinhTrangPM
        {
            get => _SelectedTinhTrangPM;
            set
            {
                _SelectedTinhTrangPM = value;
                OnPropertyChanged();
                if (SelectedTinhTrangPM != null)
                {

                }
            }
        }
        void loaDgrPm()
        {
            PhieuMuon = new ObservableCollection<Model.PhieuMuon>(DataProvider.Ins.DB.PhieuMuons);
        }
        void loadDgrBook()
        {
            var bookList = SelectedPhieuMuon.ChiTietPhieuMuons;

            SachDcThue = new ObservableCollection<LentBook>();
            Sach = new ObservableCollection<Model.Sach>(DataProvider.Ins.DB.Saches);


            int i = 1;
            foreach (var item in bookList)
            {
                LentBook a = new LentBook();
                a.Id = item.IDCht;
                a.STT = i;
                a.SoLuong = item.SoLuong;
                SelectedSach = a.SelectedSach;
                a.SelectedLoaiSach = item.Sach.LoaiSach;
                a.Sach = Sach;
                a.SelectedSach = item.Sach;
                SachDcThue.Add(a);
                i++;
            }
            addNewRow(i);
        }
        void addNewRow(int i)
        {
            LentBook b = new LentBook();
            b.STT = i;
            b.Sach = Sach;
            SachDcThue.Add(b);
        }
        private string _TenLoai;
        public string TenLoai { get => _TenLoai; set { _TenLoai = value; OnPropertyChanged(); } }
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
                    TenLoai = SelectedSach.LoaiSach.TenLoai;
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
                    
                }
            }
        }
        public ICommand DeleteSachCommand { get; set; }
        public ICommand UpdateSachCommand { get; set; }
        public ICommand AddPhMuonCommand { get; set; }
        public ICommand UpdatePhMuonCommand { get; set; }
        public ICommand PrintPhMuonCommand { get; set; }
        //public ICommand TurnEditableCbbCommand { get; set; }

        //
        bool isBtnAddClick = false;
        bool isBtnSaveClick = false;
        bool isBtnPrintClick = false;
        //
        public LendingBookViewModel()
        {
            TinhTrangPM = new ObservableCollection<Model.TinhTrangPM>(DataProvider.Ins.DB.TinhTrangPMs);
            DocGia = new ObservableCollection<Model.DocGia>(DataProvider.Ins.DB.DocGias);
            loaDgrPm();

           

            DeleteSachCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) =>
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
                        LentBook lb = (LentBook)p.SelectedItem as LentBook;

                        var chTietSach = DataProvider.Ins.DB.ChiTietPhieuMuons.Find(lb.Id);
                        if (chTietSach == null)
                        {
                            MessageBox.Show("Không thể xóa dòng này!", "Thông báo lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;            
                        }
                        else
                        {
                            DataProvider.Ins.DB.ChiTietPhieuMuons.Remove(chTietSach);
                            DataProvider.Ins.DB.SaveChanges();

                            loadDgrBook();
                           
                            
                        }

                    }
                }
            });
            UpdateSachCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) => {
                if (p == null)
                    return;
                LentBook lb = (LentBook)p.SelectedItem as LentBook;
                if(p.SelectedItem == null)
                {
                    return;
                }
                var chTietSach = DataProvider.Ins.DB.ChiTietPhieuMuons.Find(lb.Id);

                if (chTietSach == null)
                {
                    var chTSach = new ChiTietPhieuMuon();

                    chTSach.IDPm = MaPhieu;
                    if (lb.SelectedSach == null) // dòng này là magic
                    {
                        return;
                    }
                    chTSach.IDSach = lb.SelectedSach.IDSach;
                    chTSach.SoLuong = lb.SoLuong;
                    DataProvider.Ins.DB.ChiTietPhieuMuons.Add(chTSach);
                    DataProvider.Ins.DB.SaveChanges();
                    SelectedSach = lb.SelectedSach;
                    loadDgrBook();
                    return;
                }
                else
                {
                    chTietSach.IDSach = lb.SelectedSach.IDSach;
                    SelectedSach = lb.SelectedSach;
                    chTietSach.SoLuong = lb.SoLuong;
                    DataProvider.Ins.DB.SaveChanges();
                }
             
                

            });
            AddPhMuonCommand = new RelayCommand<Button>((p) =>
            {
                if (isBtnAddClick == true)
                {
                    p.IsEnabled = false;
                }
                else
                {
                    p.IsEnabled = true;
                }
                return true;

            }, (p) =>
            {
                isBtnAddClick = true;
                var PhMuon = new PhieuMuon(); ;


                DataProvider.Ins.DB.PhieuMuons.Add(PhMuon);
                DataProvider.Ins.DB.SaveChanges();
                MaPhieu = PhMuon.IDPm;
                SelectedTinhTrangPM = TinhTrangPM[0];
                SelectedPhieuMuon = DataProvider.Ins.DB.PhieuMuons.Find(MaPhieu);

            });
            UpdatePhMuonCommand = new RelayCommand<Button>((p) => {
                if (SelectedPhieuMuon != null || isBtnAddClick == true)
                {
                    p.IsEnabled = true;
                }
               else
                { 
                    p.IsEnabled = false;
                }
                return true;
            }, (p) =>
            {
                SelectedPhieuMuon = null;
                isBtnAddClick = false;


                // Phần thông tin phiếu
                var PhMuon = DataProvider.Ins.DB.PhieuMuons.Find(MaPhieu);
                PhMuon.UserName = "admin";
                PhMuon.IDDg = SelectedDocGia.IDDg;
                PhMuon.NgayMuon = LendingDay ?? System.DateTime.Today;
                PhMuon.KyHanTra = ReturnDay ?? System.DateTime.Today;
                PhMuon.TinhTrang = SelectedTinhTrangPM.Id;
                //

                // Phần chi tiết sách

                //

                DataProvider.Ins.DB.SaveChanges();
                loaDgrPm();
            });
            PrintPhMuonCommand = new RelayCommand<Button>((p) => {
                if (SelectedPhieuMuon != null)
                {
                    p.IsEnabled = true;
                }
                return true;
            }, (p) =>
            {

            });
        }
       
    }
}
