using dziennik.Class;
using dziennik.Services;
using dziennik.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace dziennik.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        private databaseService _databaseService { get; set; } = new databaseService();
        private Student dane;
        public StudentWindow(int pesel, string password)
        {
            InitializeComponent();

            dane = _databaseService.GetStudentData(pesel);

            LoadData();
        }

        private void LoadData()
        {
            _textblock_imie_nazwisko.Text = dane.imie + " " + dane.nazwisko;

            _textblock_punkty.Text = dane.punkty.ToString();

            _textblock_pesel.Text = dane.PESEL.ToString();

            dane.oceny.GroupBy(o => o.nazwa).ToList().ForEach(group =>
            {
                TreeViewItem przedmiot = new TreeViewItem { Header = group.Key };

                foreach (var item in group)
                {
                    przedmiot.Items.Add(new TreeViewItem { Header = item.ocena });
                }

                _treeView_oceny.Items.Add(przedmiot);

            });

        }
    }
}
