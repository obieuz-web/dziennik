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
    /// Logika interakcji dla klasy AddStudentForm.xaml
    /// </summary>
    public partial class AddStudentForm : Window
    {
        databaseService databaseService;
        public AddStudentForm()
        {
            InitializeComponent();

            databaseService = new databaseService();

            List<string> klasy = (List<string>)databaseService.GetKlasy();

            klasy.ForEach(k =>
            {
                klasa.Items.Add(k);
            });
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string imie_ucznia = imie.Text;
            string nazwisko_ucznia = nazwisko.Text;
            string klasa_ucznia = klasa.SelectedItem.ToString();
            string haslo_ucznia = haslo.Text;


            databaseService.AddStudent(imie_ucznia,nazwisko_ucznia,klasa_ucznia,haslo_ucznia);

            this.Close();
        }
    }
}
