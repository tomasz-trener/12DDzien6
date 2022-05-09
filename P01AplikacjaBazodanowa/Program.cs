using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01AplikacjaBazodanowa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection; // sluzy do naziwaznia komunikacji z baza
            SqlCommand command; // przechowuje polecenia SQL 
            SqlDataReader sqlDataReader; // czytya wynik z bazy 


            string connectionString = @"Data Source=.;Initial Catalog=A_Zawodnicy;User ID=sa;Password=alx"; // SQL SErver Auth
           // string connectionString = "Data Source=.;Initial Catalog=A_Zawodnicy;integrated scurity=true"; // windows auth
            connection = new SqlConnection(connectionString);

            command = new SqlCommand("SELECT * FROM zawodnicy", connection);

            connection.Open();

            sqlDataReader = command.ExecuteReader();// wyslanie polecenia SQL do bazy 

            while (sqlDataReader.Read())
            {
                string wynik = (string)sqlDataReader.GetValue(2) + " " + (string)sqlDataReader.GetValue(3) + " " +
                     (DateTime)sqlDataReader.GetValue(5);

                Console.WriteLine(wynik);
            }
           

            connection.Close();
            Console.ReadKey();


        }
    }
}
