using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;
using System.Windows;
using dziennik.Class;

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
        public List<Student> getStudents()
        {
            if(!DoesConnected())
            {
                return null;
            }

            string query = "SELECT imie,nazwisko,klasa FROM uczniowie";

            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();

            List<Student> students = new List<Student>();

            while (reader.Read())
            {
                students.Add(new Student { Imie = (string)reader["imie"], Nazwisko = (string)reader["nazwisko"], klasa = (string)reader["klasa"] });
            }

            // Zamknięcie SqlDataReader
            reader.Close();

            connection.Close();

            return students;
        }
        public string Login(int pesel, string password)
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
        private bool DoesConnected()
        {
            try
            {
                connection.Open();
                MessageBox.Show("Połączenie udane!");
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
