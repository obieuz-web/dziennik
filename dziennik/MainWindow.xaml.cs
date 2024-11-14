using dziennik.Class;
using dziennik.Services;
using dziennik.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace dziennik
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        databaseService databaseService;
        public MainWindow()
        {
            InitializeComponent();
            databaseService = new databaseService();

            //List<Student> students = databaseService.getStudents();

            //CreateStudentTree(students);

            MessageBox.Show(databaseService.Login(2137,"123"));
        }
        private void CreateStudentTree(List<Student> students)
        {

            students.GroupBy(s => s.klasa).ToList().ForEach(group =>
            {
                TreeViewItem klasa = new TreeViewItem { Header=group.Key };

                foreach (var item in group)
                {
                    klasa.Items.Add(new TreeViewItem { Header = item.Imie + " " + item.Nazwisko });
                }
                //_treeView.Items.Add(klasa);
            });
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StartUpWindow startUpWindow = new StartUpWindow();
            startUpWindow.Show();

            this.Close();

            string typ = databaseService.Login(int.Parse(pesel.Text), haslo.Text);

            if (typ == "u")
            {
                MessageBox.Show("Witaj uczniu");
            }
            else if(typ == "n")
            {
                MessageBox.Show("Witaj szanowny nauczycielu");
            }
            else
            {
                MessageBox.Show("Za szybko");
            }
        }
    }
}
