using LiveCharts;
using LiveCharts.Wpf;
using QLTV_MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QLTV_MVVM.ViewModel
{
    public class ProcessOfBookViewModel : BaseViewModel
    {
        private DateTime _NgayBatDau;
        public DateTime NgayBatDau { get => _NgayBatDau; set { _NgayBatDau = value; OnPropertyChanged(); } }
        private DateTime _NgayKetThuc;
        public DateTime NgayKetThuc { get => _NgayKetThuc; set { _NgayKetThuc = value; OnPropertyChanged(); } }
        public ICommand SelectedDateChangedCommand { get; set; }
        public SeriesCollection ColumnValue { get; set; }
        public string[] Labels { get; set; }

        public Func<double, string> Formatter { get; set; }

        List<topBook> ListTopBook;
        public class topBook
        {
            public string Name { get; set; }
            public int Quantity { get; set; }
        }
        public ProcessOfBookViewModel()
        {
            NgayBatDau = DateTime.Today;
            NgayKetThuc = DateTime.Today;
            ColumnValue = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Số lượng",
                    Values = new ChartValues<double> {0,0,0,0,0}
                }
            };

            Labels = new[] { "", "", "", "", "" };
            LoadData();
            SelectedDateChangedCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) => {
                if (NgayBatDau > NgayKetThuc)
                {
                    MessageBox.Show("Chọn mốc thời gian sai!", "Thông báo lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
              
                LoadData();
            });
            void LoadData()
            {
                
                ListTopBook = new List<topBook>();
                var bookList = DataProvider.Ins.DB.Saches.ToList();
               
                foreach (var book in bookList)
                {
                    
                    var exportList = DataProvider.Ins.DB.ChiTietPhieuMuons.Where(w => w.IDSach == book.IDSach && w.PhieuMuon.NgayMuon >= NgayBatDau && w.PhieuMuon.NgayMuon <= NgayKetThuc).ToList();
                    if (exportList.Count > 0)
                    {
                        int quantity = exportList.Sum(w => w.SoLuong);
                        topBook topBook = new topBook();
                        topBook.Name = book.TenSach;
                        topBook.Quantity = quantity;
                        ListTopBook.Add(topBook);
                    }
                  
                }
                ChartValues<double> quan = new ChartValues<double>();
                var n = ListTopBook.Count;
                if(n > 5)
                {
                    n = 5;
                }
                else if (n < 1)
                {

                    for (int i = 0; i < 5; i++)
                    {
                        Labels[i] = "";
                        quan.Add(0);
                    }
                }
                else
                {
                    List<topBook> SortedList = ListTopBook.OrderByDescending(w => w.Quantity).ToList();

                    for (int i = 0; i < n; i++)
                    {
                        Labels[i] = SortedList[i].Name;
                        quan.Add(SortedList[i].Quantity);
                    }
                }
                ColumnValue[0].Values = quan;
                Formatter = value => value.ToString("N");
                
            }
        }
    }
}
