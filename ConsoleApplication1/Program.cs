using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
 
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            printArgs(args);
            arrayStuff();


            string connectionProperties = "Server=RICH-MAC\\SQLEXPRESS;Database=testdb;Trusted_Connection=true;";

            SqlConnection myDbConnection = new SqlConnection( connectionProperties );

            connect( myDbConnection );

            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand( "SELECT * FROM test_tbl", myDbConnection );
            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                Console.WriteLine("ID from db:" + myReader["id"].ToString());
            }
        }

        private static void connect( SqlConnection connection )
        {
            try
            {
                connection.Open();
            }
            catch( Exception e )
            {
                Console.WriteLine("exception caught"); 
                Console.WriteLine(e.ToString());
            }
        }

        private static void printArgs(string[] args)
        {
           Console.WriteLine("Number of command line parameters = {0}",args.Length);
           foreach (string s in args)
           {
                Console.WriteLine(s);
           }
        }

        private static void arrayStuff()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };

            int[,] numbersM = { { 9, 99 }, { 3, 33 }, { 5, 55 } };

            foreach (int i in numbersM)
            {
                Console.Write(i);
            }

        }

    }
}
