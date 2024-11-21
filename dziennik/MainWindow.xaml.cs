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
        }

        private void GetType(object sender, RoutedEventArgs e)
        {
            string typ = databaseService.GetType(int.Parse(pesel.Text), haslo.Text);

            if (typ == "")
            {
                MessageBox.Show("Za szybko");
                return;
            }

            if(typ == "n")
            {
                TeacherWindow teacherWindow = new TeacherWindow(int.Parse(pesel.Text), haslo.Text);
                teacherWindow.Show();
                this.Close();
                return;
            }

            StudentWindow studentWindow = new StudentWindow(int.Parse(pesel.Text), haslo.Text);
            studentWindow.Show();
            this.Close();
        }
    }
}
