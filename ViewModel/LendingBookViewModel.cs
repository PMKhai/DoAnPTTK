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


                    //////
                    var bookList = SelectedPhieuMuon.ChiTietPhieuMuons;

                    SachDcThue = new ObservableCollection<LentBook>();
                  //  LoaiSach = new ObservableCollection<Model.LoaiSach>(DataProvider.Ins.DB.LoaiSaches);
                    Sach = new ObservableCollection<Model.Sach>(DataProvider.Ins.DB.Saches);


                    int i = 1;
                    foreach (var item in bookList)
                    {
                        

                        LentBook a = new LentBook();
                        a.Id = item.IDCht;
                        a.STT = i;
                        a.DonVi = "Quyển";
                        a.SoLuong = item.SoLuong;
                        // a.LoaiSach = LoaiSach;
                        SelectedSach = a.SelectedSach;
                        a.SelectedLoaiSach = item.Sach.LoaiSach;
                         a.Sach = Sach;
                        a.SelectedSach = item.Sach;
                        SachDcThue.Add(a);
                        i++;
                    }
                }
            }
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
        //public ICommand TurnEditableCbbCommand { get; set; }

        public LendingBookViewModel()
        {
            DocGia = new ObservableCollection<Model.DocGia>(DataProvider.Ins.DB.DocGias);
            PhieuMuon = new ObservableCollection<Model.PhieuMuon>(DataProvider.Ins.DB.PhieuMuons);

           

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
                        DataProvider.Ins.DB.ChiTietPhieuMuons.Remove(chTietSach);
                        DataProvider.Ins.DB.SaveChanges();
                        SachDcThue.Remove(lb);
                    }
                }
            });
            UpdateSachCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) => {
                if (p == null)
                    return;
                LentBook lb = (LentBook)p.SelectedItem as LentBook;
                if(p.SelectedItem == null)
                {
                    //var chTSach = new ChiTietPhieuMuon()
                    //{
                    //    IDPm = MaPhieu,
                    //    IDSach = 2,
                    //    SoLuong = 0,
                         
                    //};
                    //DataProvider.Ins.DB.ChiTietPhieuMuons.Add(chTSach);
                    //DataProvider.Ins.DB.SaveChanges();
                    return;
                }
                var chTietSach = DataProvider.Ins.DB.ChiTietPhieuMuons.Find(lb.Id);

                if (chTietSach == null)
                {
                    MessageBox.Show("Không thể chỉnh sửa đọc giả!", "Thông báo lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }


                chTietSach.IDSach = lb.SelectedSach.IDSach;
                SelectedSach = lb.SelectedSach;
                chTietSach.SoLuong = lb.SoLuong;


                DataProvider.Ins.DB.SaveChanges();

            });
            //TurnEditableCbbCommand = new RelayCommand<DataGridComboBoxColumn>((p) => { return true; }, (p) => {
            //    if (p == null)
            //        return;
            //   // p.IsEditable = true;
            //    MessageBox.Show("queo");
            //});
        }
       
    }
}
