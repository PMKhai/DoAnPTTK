using System;
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
    public class SettingViewModel : BaseViewModel
    {
        public ICommand LoadDBCommand1 { get; set; }
        public ICommand LoadDBCommand2 { get; set; }
        public ICommand LoadDBCommand3 { get; set; }
        public ICommand LoadDBCommand4 { get; set; }
        public ICommand LostFocusCommand1 { get; set; }
        public ICommand LostFocusCommand2 { get; set; }
        public ICommand LostFocusCommand3 { get; set; }
        public ICommand LostFocusCommand4 { get; set; }


        public SettingViewModel()
        {
            LoadDBCommand1 = new RelayCommand<TextBox>((p) => { return true; }, (p) => {
                if (p == null)
                    return;
                var a = DataProvider.Ins.DB.ThamSoes.ToList();
                p.Text = a[0].GiaTri;
            });

            LoadDBCommand2 = new RelayCommand<TextBox>((p) => { return true; }, (p) => {
                if (p == null)
                    return;
                var a = DataProvider.Ins.DB.ThamSoes.ToList();
                p.Text = a[1].GiaTri;
            });

            LoadDBCommand3 = new RelayCommand<TextBox>((p) => { return true; }, (p) => {
                if (p == null)
                    return;
                var a = DataProvider.Ins.DB.ThamSoes.ToList();
                p.Text = a[2].GiaTri;
            });

            LoadDBCommand4 = new RelayCommand<TextBox>((p) => { return true; }, (p) => {
                if (p == null)
                    return;
                var a = DataProvider.Ins.DB.ThamSoes.ToList();
                p.Text = a[3].GiaTri;
            });

            LostFocusCommand1 = new RelayCommand<TextBox>((p) => { return true; }, (p) => {
                if (p == null)
                    return;
                var newValue = p.Text;
                if (int.Parse(newValue) < 0)
                {
                    MessageBox.Show("Nhập không đúng giá trị!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var a = DataProvider.Ins.DB.ThamSoes.ToList()[0];

                var b = DataProvider.Ins.DB.ThamSoes.Find(a.IDTs);
                b.GiaTri = newValue;

                DataProvider.Ins.DB.SaveChanges();

            });

            LostFocusCommand2 = new RelayCommand<TextBox>((p) => { return true; }, (p) => {
                if (p == null)
                    return;
                var newValue = p.Text;
                if (int.Parse(newValue) < 0)
                {
                    MessageBox.Show("Nhập không đúng giá trị!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var a = DataProvider.Ins.DB.ThamSoes.ToList()[1];

                var b = DataProvider.Ins.DB.ThamSoes.Find(a.IDTs);
                b.GiaTri = newValue;

                DataProvider.Ins.DB.SaveChanges();

            });

            LostFocusCommand3 = new RelayCommand<TextBox>((p) => { return true; }, (p) => {
                if (p == null)
                    return;
                var newValue = p.Text;
                if (int.Parse(newValue) < 0)
                {
                    MessageBox.Show("Nhập không đúng giá trị!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var a = DataProvider.Ins.DB.ThamSoes.ToList()[2];

                var b = DataProvider.Ins.DB.ThamSoes.Find(a.IDTs);
                b.GiaTri = newValue;

                DataProvider.Ins.DB.SaveChanges();

            });

            LostFocusCommand4 = new RelayCommand<TextBox>((p) => { return true; }, (p) => {
                if (p == null)
                    return;
                var newValue = p.Text;
                if (int.Parse(newValue) < 0)
                {
                    MessageBox.Show("Nhập không đúng giá trị!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var a = DataProvider.Ins.DB.ThamSoes.ToList()[3];

                var b = DataProvider.Ins.DB.ThamSoes.Find(a.IDTs);
                b.GiaTri = newValue;

                DataProvider.Ins.DB.SaveChanges();

            });
        }

    }
}