﻿using QLTV_MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;

namespace QLTV_MVVM.ViewModel
{
    public class AddingBookViewModel: BaseViewModel
    {
        private string _TenSach;
        public string TenSach { get => _TenSach; set { _TenSach = value; OnPropertyChanged(); } }
        private string _TacGia;
        public string TacGia { get => _TacGia; set { _TacGia = value; OnPropertyChanged(); } }
        private DateTime _NamXuatBan;
        public DateTime NamXuatBan { get => _NamXuatBan; set { _NamXuatBan = value; OnPropertyChanged(); } }
        private string _NhaXuatBan;
        public string NhaXuatBan { get => _NhaXuatBan; set { _NhaXuatBan = value; OnPropertyChanged(); } }
        private DateTime _NgayNhap;
        public DateTime NgayNhap { get => _NgayNhap; set { _NgayNhap = value; OnPropertyChanged(); } }
        private ObservableCollection<Model.LoaiSach> _LoaiSach;
        public ObservableCollection<Model.LoaiSach> LoaiSach { get => _LoaiSach; set { _LoaiSach = value; OnPropertyChanged(); } }
        private LoaiSach _LS;
        public LoaiSach LS { get => _LS; set { _LS = value; OnPropertyChanged(); } }

        public ICommand AddBookCommand { get; set; }

        public AddingBookViewModel()
        {
            LoaiSach = new ObservableCollection<Model.LoaiSach>(DataProvider.Ins.DB.LoaiSaches);
            NgayNhap = System.DateTime.Today;
            NamXuatBan = System.DateTime.Today;

            AddBookCommand = new RelayCommand<AddingBookWindow>((p) => { return true; }, (p) => {

                kiemTra(NamXuatBan);
                if ( TenSach == null || LoaiSach == null
                    || TacGia == null || NamXuatBan == null
                    || NhaXuatBan == null || NgayNhap == null)
                {
                    MessageBox.Show("Không thể thêm sách!", "Thông báo lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (!kiemTra(NamXuatBan))
                {
                    var str = "Chỉ nhập sách từ năm " + DataProvider.Ins.DB.ThamSoes.ToArray()[3].GiaTri + " về sau!";
                    MessageBox.Show(str, "Thông báo lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                Sach sach = new Sach();
                sach.IDLoai = LS.IdLoai;
                sach.TenSach = TenSach;
                sach.NamXB = NamXuatBan;
                sach.NhaXB = NhaXuatBan;
                sach.TacGia = TacGia;
                sach.NgayNhap = NgayNhap;

                DataProvider.Ins.DB.Saches.Add(sach);
                if (DataProvider.Ins.DB.SaveChanges() == 1)
                {
                    TenSach = null;
                    LS = null;
                    TacGia = null;
                    NhaXuatBan = null;
                    p.Close();
                }
                else
                {
                    MessageBox.Show("Không thể thêm sách!", "Thông báo lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

            });
        }

        Boolean kiemTra(DateTime NXB)
        {
            var a = "1/1/" + DataProvider.Ins.DB.ThamSoes.ToArray()[3].GiaTri;
            var date = DateTime.Parse(a);

            if(DateTime.Compare(NXB, date) >= 0)
                return true;
            return false;
        }
    }
}
