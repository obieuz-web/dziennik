using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;
using System.Windows;
using dziennik.Class;
using Dapper;
using System.Windows.Controls;
using System.Diagnostics;

namespace dziennik.Services
{
    internal class databaseService
    {
        SqlConnection connection { get; set; }
        string connectionString { get; set; }
        public databaseService()
        {
            connectionString = "Data Source=10.1.49.186;Initial Catalog=Szkola;User ID=admin2;Password=zaq1@WSX;TrustServerCertificate=True;Connect Timeout=30;Encrypt=True;";
            
            connection = new SqlConnection(connectionString);
        }
        public string GetType(int pesel, string password)
        {
            if (!DoesConnected())
            {
                return null;
            }
            string query = $"SELECT COUNT(*) FROM uczniowie where PESEL = {pesel} AND haslo = ${password}";

            SqlCommand command = new SqlCommand(query, connection);

            string query1 = $"SELECT COUNT(*) FROM Nauczyciele where PESEL = {pesel} AND haslo = ${password}";

            SqlCommand command1 = new SqlCommand(query1, connection);

            int rowCount_uczen = (int)command.ExecuteScalar();

            int rowCount_nauczyciel = (int)command1.ExecuteScalar();

            connection.Close();

            if (rowCount_uczen > 0)
            {
                //shorted for uczeń
                return "u";
            }

            if (rowCount_nauczyciel > 0)
            {
                //shorted for nauczyciel
                return "n";
            }

            return "";
        }
        public Student GetStudentData(int pesel)
        {
            if(!DoesConnected())
            {
                return null;
            }
            string query = "SELECT * FROM uczniowie WHERE pesel = @pesel;";

            Student student = connection.Query<Student>(query,new { pesel }).First();

            string query_grades = "SELECT Id_ucznia, ocena, Id_przedmiotu, nazwa FROM oceny JOIN przedmioty ON oceny.Id_przedmiotu = przedmioty.Id WHERE Id_ucznia = @pesel;";

            var grades = connection.Query<Grade>(query_grades, new { pesel});

            student.oceny = new List<Grade>(grades);

            connection.Close();

            return student;

        }
        public IEnumerable<Student> GetStudentsFromClass(int id_nauczyciela)
        {
            if (!DoesConnected())
            {
                return null;
            }

            string query_find_class = "SELECT Id from klasy WHERE wychowawca = @id_nauczyciela";

            string klasa = connection.Query<string>(query_find_class, new { id_nauczyciela }).First();

            string query = "SELECT * FROM uczniowie WHERE klasa = @klasa";

            IEnumerable<Student> students = connection.Query<Student>(query, new { klasa });

            connection.Close();

            return students;
        }
        public Teacher GetTeacherData(int pesel, string password)
        {
            if (!DoesConnected())
            {
                return null;
            }
            string query = "SELECT * FROM Nauczyciele WHERE pesel = @pesel AND haslo = @password;";

            Teacher teacher = connection.Query<Teacher>(query, new { pesel, password }).First();

            connection.Close();

            return teacher;
        }

        public void AddPoints(int pesel, int punkty)
        {
            if (!DoesConnected())
            {
                return;
            }

            string query = "SELECT punkty FROM uczniowie WHERE PESEL = @pesel;";

            int points = connection.Query<int>(query, new { pesel }).First();

            points += punkty;

            string query_grades = "UPDATE uczniowie SET punkty = @points WHERE PESEL = @pesel";

            connection.Execute(query_grades, new { points, pesel });

            connection.Close();
        }
        public IEnumerable<string> getSubjects()
        {
            if (!DoesConnected())
            {
                return null;
            }

            string query = "SELECT nazwa FROM przedmioty;";

            IEnumerable<string> przedmioty = connection.Query<string>(query);

            connection.Close();

            return przedmioty;
        }
        public IEnumerable<Student> GetStudents()
        {
            if (!DoesConnected())
            { return null; }

            string query = "SELECT * FROM uczniowie;";

            IEnumerable<Student> students = connection.Query<Student>(query);

            connection.Close();

            return students;
        }

        public void AddGrade(int grade, string przedmiot, int pesel)
        {
            if (!DoesConnected())
            {
                return;
            }

            string query = "SELECT Id FROM przedmioty WHERE nazwa = @przedmiot;";

            int id_przedmiotu = connection.Query<int>(query, new {przedmiot}).First();

            string query_1 = "INSERT INTO oceny (Id_ucznia,ocena,Id_przedmiotu) VALUES(@pesel,@grade,@id_przedmiotu)";

            connection.Execute(query_1, new { pesel, grade, id_przedmiotu });

            connection.Close();

            return;
        }
        public IEnumerable<string> GetKlasy()
        {
            if (!DoesConnected())
            {
                return null;
            }

            string query = "SELECT DISTINCT klasa FROM uczniowie;";

            IEnumerable<string> klasy = connection.Query<string>(query);

            connection.Close();

            return klasy;
        }

        private bool DoesConnected()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd połączenia: {ex.Message}");
                return false;
            }
        }

        public void AddStudent(string imie, string nazwisko, string klasa, string haslo)
        {
            if (!DoesConnected())
            {
                return;
            }

            string query = "INSERT INTO uczniowie VALUES (@imie,@nazwisko,@haslo,250,@klasa);";

            connection.Execute(query, new {imie,nazwisko,haslo,klasa});

            connection.Close();

            return;
        }


    }
}
