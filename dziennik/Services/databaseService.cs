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


    }
}
