﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using QLTV_MVVM.Model;
using QLTV_MVVM.UserControl_QLTV;

namespace QLTV_MVVM.ViewModel
{
    public class BooksViewModel: BaseViewModel
    {
        private ObservableCollection<Model.Book> _Book;
        public ObservableCollection<Model.Book> Book { get => _Book; set { _Book = value; OnPropertyChanged(); } }
        private ObservableCollection<Model.LoaiSach> _LoaiSach;
        public ObservableCollection<Model.LoaiSach> LoaiSach { get => _LoaiSach; set { _LoaiSach = value; OnPropertyChanged(); } }
        private ObservableCollection<Model.Sach> _Sach;
        public ObservableCollection<Model.Sach> Sach { get => _Sach; set { _Sach = value; OnPropertyChanged(); } }
        private LoaiSach _LS;
        public LoaiSach LS
        { get => _LS;
            set
            {
                _LS = value;
                if(_LS != null)
                {
                    Sach = new ObservableCollection<Model.Sach>(DataProvider.Ins.DB.Saches.Where(k => k.IDLoai == _LS.IdLoai));
                    
                }
                else
                {
                    Sach = new ObservableCollection<Model.Sach>(DataProvider.Ins.DB.Saches);

                }
                loadDgrBook();
                OnPropertyChanged();
            }
        }
        private string _Searching;
        public string Searching { get => _Searching; set { _Searching = value; OnPropertyChanged(); } }
        //public ICommand LoadDBCommand { get; set; }
        public ICommand DisplayAddingBookCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand TextChangedCommand { get; set; }
        public ICommand LostFocusCommand { get; set; }
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
        void loadDgrBook()
        {
            Book = new ObservableCollection<Book>();
           
            if(Sach == null)
            {
                Sach = new ObservableCollection<Model.Sach>(DataProvider.Ins.DB.Saches);
            }
            if(LoaiSach == null)
            {
                LoaiSach = new ObservableCollection<Model.LoaiSach>(DataProvider.Ins.DB.LoaiSaches);
            }
            int i = 1;
            foreach (var item in Sach)
            {
                Book a = new Book();
          
                a.Sach = item;
                a.LoaiSach = new ObservableCollection<Model.LoaiSach>(DataProvider.Ins.DB.LoaiSaches);
                a.SelectedLoaiSach = item.LoaiSach;
                Book.Add(a);
                i++;
            }
            
        }

        public BooksViewModel()
        {
           
            
            loadDgrBook();

        

            DisplayAddingBookCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) => {
                AddingBookWindow wd = new AddingBookWindow();
                wd.ShowDialog();
                Sach = new ObservableCollection<Sach>(DataProvider.Ins.DB.Saches);
                

                if (Sach == null)
                {
                    MessageBox.Show("Không thể hiển thị danh sách sách!", "Thông báo lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                loadDgrBook();
            });
            DeleteCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) =>
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
                            Sach rd = (Sach)p.SelectedItem as Sach;

                            var book = DataProvider.Ins.DB.Saches.Find(rd.IDSach);
                            DataProvider.Ins.DB.Saches.Remove(book);
                            DataProvider.Ins.DB.SaveChanges();
                             Sach.Remove(book);
                        }

                     

                    }
                
                    
               

            });
           
            TextChangedCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) =>{Searching = p.Text; });
            SearchCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                if (Searching == null || Searching == "")
                {
                    if(LS == null)
                    {
                        Sach = new ObservableCollection<Model.Sach>(DataProvider.Ins.DB.Saches);

                    }
                    else
                    {
                        Sach = new ObservableCollection<Model.Sach>(DataProvider.Ins.DB.Saches.Where(k => k.IDLoai == LS.IdLoai));
                    }
                    loadDgrBook();
                    return;
                }
                if(LS == null)
                {
                    Sach = new ObservableCollection<Model.Sach>(DataProvider.Ins.DB.Saches.Where(k => k.TenSach.Contains(Searching.ToLower())));
                }
                else
                {
                    Sach = new ObservableCollection<Model.Sach>(DataProvider.Ins.DB.Saches.Where(k => k.IDLoai == LS.IdLoai && k.TenSach.Contains(Searching.ToLower())));

                }
                loadDgrBook();
             
            });
            LostFocusCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) => {
                if (p == null)
                    return;
                if (p.SelectedItem == null)
                {
                    return;
                }
                Book sa = (Book)p.SelectedItem as Book;
                
                var bk = DataProvider.Ins.DB.Saches.Find(sa.Sach.IDSach);

                if (bk == null)
                {
                    MessageBox.Show("Không thể chỉnh sửa đọc giả!", "Thông báo lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                bk.TenSach = sa.Sach.TenSach;
                bk.TacGia = sa.Sach.TacGia;
                bk.NhaXB = sa.Sach.NhaXB;
                bk.NgayNhap = sa.Sach.NgayNhap;
                bk.NamXB = sa.Sach.NamXB;
                bk.IDLoai = sa.SelectedLoaiSach.IdLoai;

                DataProvider.Ins.DB.SaveChanges();

            });
        }

    }
}
