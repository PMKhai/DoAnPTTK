using QLTV_MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV_MVVM.Model
{
    public class Book : BaseViewModel
    {
        public int IDSach { get; set; }
        public string TenSach { get; set; }
        public string TacGia { get; set; }
        public string NhaXB { get; set; } 
        public DateTime? NamXB { get; set; }
     
       
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
                //if (SelectedLoaiSach != null)
                //{
                //    Sach = new ObservableCollection<Model.Sach>(SelectedLoaiSach.Saches);
                //}
            }
        }
    }
}
