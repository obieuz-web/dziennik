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
    /// Logika interakcji dla klasy AppPointsForm.xaml
    /// </summary>
    public partial class AppPointsForm : Window
    {
        private int PESEL;
        public int points_saved { get; set; }
        public AppPointsForm(int _PESEL)
        {
            InitializeComponent();
            PESEL = _PESEL;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            databaseService databaseService = new databaseService();

            if(!int.TryParse(punkty.Text, out _))
            {
                return;
            }

            int points = int.Parse(punkty.Text);

            points_saved = points;

            databaseService.AddPoints(PESEL, points);

            this.Close();
        }
    }
}
