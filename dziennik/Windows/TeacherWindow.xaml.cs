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
    /// Logika interakcji dla klasy TeacherWindow.xaml
    /// </summary>
    public partial class TeacherWindow : Window
    {
        private Teacher dane;
        private databaseService _databaseService { get; set; } = new databaseService();
        private Student current_student { get; set; }
        public TeacherWindow(int pesel, string password)
        {
            InitializeComponent();

            dane = _databaseService.GetTeacherData(pesel, password);

            LoadClass(dane.PESEL);

            _listBox_uczniowie.SelectionChanged += LoadStudent;
        }
        private void LoadClass(int id)
        {
            List<Student> students = new List<Student>(_databaseService.GetStudentsFromClass(id));

            students.ForEach(student =>
            {
                _listBox_uczniowie.Items.Add(new ListBoxItem { Content = student.imie + " " + student.nazwisko, Tag = student.PESEL });
            });
        }

        private void LoadStudent(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (_listBox_uczniowie.SelectedItem == null)
            {
                return;
            }

            ListBoxItem itemBox = (ListBoxItem)_listBox_uczniowie.SelectedItem;

            LoadStudentData((int)itemBox.Tag);
        }

        private void LoadStudentData(int pesel)
        {
            Student student = _databaseService.GetStudentData(pesel);

            current_student = student;

            _textblock_imie_nazwisko.Text = student.imie + " " + student.nazwisko;

            _textblock_punkty.Text = student.punkty.ToString();

            _textblock_pesel.Text = student.PESEL.ToString();

            _treeView_oceny.Items.Clear();

            student.oceny.GroupBy(o => o.nazwa).ToList().ForEach(group =>
            {
                TreeViewItem przedmiot = new TreeViewItem { Header = group.Key };

                foreach (var item in group)
                {
                    przedmiot.Items.Add(new TreeViewItem { Header = item.ocena });
                }

                _treeView_oceny.Items.Add(przedmiot);

            });
        }

        private void Add_Points_Button(object sender, RoutedEventArgs e)
        {
            if(!int.TryParse(_textblock_pesel.Text, out _))
            {
                return;
            }
            int pesel = int.Parse(_textblock_pesel.Text);
            AppPointsForm appPointsForm = new AppPointsForm(pesel);
            appPointsForm.ShowDialog();

            LoadStudentData(pesel);
            MessageBox.Show("Zaktualizowano punkty");
        }

        private void Add_Grade_Button(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(_textblock_pesel.Text, out _))
            {
                return;
            }
            int pesel = int.Parse(_textblock_pesel.Text);
            AppGradeForm appGradeForm = new AppGradeForm(pesel);
            appGradeForm.ShowDialog();

            LoadStudentData(pesel);
            MessageBox.Show("Dodano ocene");
        }
    }
}
