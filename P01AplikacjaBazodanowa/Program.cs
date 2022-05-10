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

             string sql = "SELECT * FROM zawodnicy where kraj = @kraj";
            string kraj = "pol' or 1=1--";
           
            //string sql = $"SELECT * FROM zawodnicy where kraj = '{kraj}'";

            command = new SqlCommand(sql, connection);

            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "@kraj";
            sqlParameter.Value = kraj;

            command.Parameters.Add(sqlParameter);

            connection.Open();

            sqlDataReader = command.ExecuteReader();// wyslanie polecenia SQL do bazy 

            while (sqlDataReader.Read())
            {
                string wynik = (string)sqlDataReader.GetValue(2) + " " + (string)sqlDataReader.GetValue(3);
                    

                Console.WriteLine(wynik);
            }
           

            connection.Close();
            Console.ReadKey();


        }
    }
}
