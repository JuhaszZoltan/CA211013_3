using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA211013_3
{
    class Program
    {
        static void Main()
        {
            string connectionString =
                @"Server = (localdb)\MSSQLLocalDB;" +
                "Database = teszt;";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var sqlCommand = new SqlCommand("SELECT * FROM dolgozok;", connection);

                var sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Console.WriteLine(
                        $"{sqlDataReader.GetInt32(0)} " +
                        $"{sqlDataReader[1]} " +
                        $"{sqlDataReader["tel"]}");
                }
            }

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Console.Write("új név: ");
                string nev = Console.ReadLine();
                Console.Write("új telefonszám: ");
                string tel = Console.ReadLine();

                var sqlCommand = new SqlCommand(
                    $"INSERT INTO dolgozok VALUES ('{nev}', '{tel}');",
                    connection);

                var sqlDataAdapter = new SqlDataAdapter()
                {
                    InsertCommand = sqlCommand,
                };

                sqlDataAdapter.InsertCommand.ExecuteNonQuery();

                Console.WriteLine("megcsináltam he!");
            }

            Console.WriteLine("ok!");

            //object x1 = 10;
            //object x2 = "krumpli";
            //object x3 = new Random();
            //object x4 = new Random();

            //Console.WriteLine((x1 as Int32?) + 10);

            Console.ReadKey();
        }
    }
}
