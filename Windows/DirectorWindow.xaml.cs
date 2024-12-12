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
    /// Logika interakcji dla klasy DirectorWindow.xaml
    /// </summary>
    public partial class DirectorWindow : Window
    {
        databaseService databaseService;
        public DirectorWindow(int pesel, string password)
        {
            InitializeComponent();
            databaseService = new databaseService();

            _treeView_uczniowie.SelectedItemChanged += LoadStudent;

            Init();

        }
        public void Init()
        {
            _treeView_uczniowie.Items.Clear();
            List<Student> students = new List<Student>(databaseService.GetStudents());


            students.GroupBy(s => s.klasa).ToList().ForEach(g =>
            {
                TreeViewItem klasa = new TreeViewItem { Header = g.Key };
                foreach (var student in g)
                {
                    klasa.Items.Add(new TreeViewItem { Header = student.imie + " " + student.nazwisko, Tag = student.PESEL });
                }
                _treeView_uczniowie.Items.Add(klasa);
            });
        }

        private void Add_Points_Button(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(_textblock_pesel.Text, out _))
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
            int pesel = int.Parse(_textblock_pesel.Text);
            AppGradeForm appGradeForm = new AppGradeForm(pesel);
            appGradeForm.ShowDialog();

            LoadStudentData(pesel);
            MessageBox.Show("Dodano ocene");
        }
        private void LoadStudent(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (_treeView_uczniowie.SelectedItem == null)
            {
                return;
            }

            TreeViewItem treeView = (TreeViewItem)_treeView_uczniowie.SelectedItem;

            LoadStudentData((int)treeView.Tag);
        }

        private void LoadStudentData(int pesel)
        {
            Student student = databaseService.GetStudentData(pesel);

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

        private void Add_Student_Button(object sender, RoutedEventArgs e)
        {
            AddStudentForm addStudentForm = new AddStudentForm();
            addStudentForm.ShowDialog();

            Init();
            MessageBox.Show("Dodano studenta");
        }
    }
}
