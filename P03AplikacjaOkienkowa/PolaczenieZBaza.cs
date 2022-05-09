using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03AplikacjaOkienkowa
{
    internal class PolaczenieZBaza
    {
        string connectionString = @"Data Source=.;Initial Catalog=A_Zawodnicy;User ID=sa;Password=alx"; // SQL SErver Auth
                                                                                                        // string connectionString = "Data Source=.;Initial Catalog=A_Zawodnicy;integrated scurity=true"; // windows auth

        public PolaczenieZBaza()
        {

        }
        public PolaczenieZBaza(string connectionString)
        {
            this.connectionString= connectionString;
        }
        public PolaczenieZBaza(string adresServera, string nawaBazy)
        {
            connectionString = string.Format("Data Source ={0}; Initial Catalog = {1}; integrated scurity=true",
                adresServera, nawaBazy);
        }
        public PolaczenieZBaza(string adresServera, string nawaBazy, string nazwaUzytkownika, string haslo)
        {
            connectionString = string.Format("Data Source ={0}; Initial Catalog = {1}; User ID = {2}; Password = {3}",
                adresServera, nawaBazy, nazwaUzytkownika, haslo);
        }

        
        public object[][] WykonajPolecenieSQL(string sql)
        {
            SqlConnection connection; // sluzy do naziwaznia komunikacji z baza
            SqlCommand command; // przechowuje polecenia SQL 
            SqlDataReader sqlDataReader; // czytya wynik z bazy 

            connection = new SqlConnection(connectionString);

            command = new SqlCommand(sql, connection);

            connection.Open();

            sqlDataReader = command.ExecuteReader();// wyslanie polecenia SQL do bazy 

            int liczbaKolumn = sqlDataReader.FieldCount;

            List<object[]> listaWierszy = new List<object[]>();

            while (sqlDataReader.Read())
            {
                //string wynik = (string)sqlDataReader.GetValue(2) + " " + (string)sqlDataReader.GetValue(3) + " " +
                //     (DateTime)sqlDataReader.GetValue(5);
                object[] komorki = new object[liczbaKolumn];
                for (int i = 0; i < liczbaKolumn; i++)
                    komorki[i] = sqlDataReader.GetValue(i);

                listaWierszy.Add(komorki);
            }
            connection.Close();
            return listaWierszy.ToArray();
        }
    }
}
