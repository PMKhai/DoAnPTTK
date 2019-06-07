using QLTV_MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QLTV_MVVM.Model
{
    public class LentBook : BaseViewModel
    {
        public int Id { get; set; }
        public int STT { get; set; }
        public string DonVi { get; set; } = "Quyển";
        public int SoLuong { get; set; } = 1;

        private ObservableCollection<Model.LoaiSach> _LoaiSach;
        public ObservableCollection<Model.LoaiSach> LoaiSach { get => _LoaiSach; set { _LoaiSach = value; OnPropertyChanged(); } }
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
        private ObservableCollection<Model.Sach> _Sach;
        public ObservableCollection<Model.Sach> Sach { get => _Sach; set { _Sach = value; OnPropertyChanged(); } }
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
                   
                   
                  
                  
                    //a.TacGia = SelectedSach.TacGia;
                    //a.NhaXB = SelectedSach.NhaXB;
                    //a.NamXB = SelectedSach.NamXB;
                }
            }
        }
        
        //  public ObservableCollection<Model.LoaiSach> Sach { get; set; }
    }
}
