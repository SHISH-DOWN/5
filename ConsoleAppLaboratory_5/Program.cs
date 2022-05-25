using System;
using Microsoft.Data.Sqlite;

namespace ConsoleAppLaboratory_5
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = new SqliteConnection("Data Source=warehouses.db;Cache=Shared;Mode=ReadOnly;");

            connection.Open();

            var cmd = connection.CreateCommand();
            cmd.CommandText = "select sklady.kod, sklady.vmest from sklady inner join yasshiki on sklady.kod = yasshiki.sklad group by sklady.kod having count(yasshiki.kod) > sklady.vmest;";
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"Kod: {reader.GetInt32(0)} Sklad:{reader.GetInt32(1)}");
            }

            connection.Close(); 
        }
    }
}