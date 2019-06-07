﻿using System;
using System.Collections.Generic;
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
    public class StatisticalViewModel: BaseViewModel
    {
        public ICommand LoadDBCommand { get; set; }

        public StatisticalViewModel()
        {
            LoadDBCommand = new RelayCommand<DataGrid>((p) => { return true; }, (p) => {
                if (p == null)
                    return;
                var db = DataProvider.Ins.DB.ChiTietPhieuMuons.ToList();

                if (db == null)
                {
                    MessageBox.Show("Không thể hiển thị danh đọc giả!", "Thông báo lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }


                p.ItemsSource = db;
            });
        }
    }
}