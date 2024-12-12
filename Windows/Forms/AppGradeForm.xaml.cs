using dziennik.Services;
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

namespace dziennik.Windows.Forms
{
    /// <summary>
    /// Logika interakcji dla klasy AppGradeForm.xaml
    /// </summary>
    public partial class AppGradeForm : Window
    {
        private databaseService databaseService;
        private int pesel;
        public AppGradeForm(int _pesel)
        {
            InitializeComponent();

            pesel = _pesel;
            databaseService = new databaseService();

            Init();
        }
        public void Init()
        {
            List<string> list = (List<string>)databaseService.getSubjects(); ;

            list.ForEach(x =>
            {
                przedmiot.Items.Add(x);
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(grade.Text, out _))
            {
                return;
            }
            databaseService.AddGrade(int.Parse(grade.Text), przedmiot.SelectedItem.ToString(), pesel);

            this.Close();
        }
    }
}
