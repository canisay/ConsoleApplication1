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

            string connectionProperties = "Server=RICH-MAC\\SQLEXPRESS;Database=testdb;Trusted_Connection=true;";

            SqlConnection myDbConnection = new SqlConnection( connectionProperties );

            connect( myDbConnection );

            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand( "SELECT * FROM test_tbl", myDbConnection );
            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                Console.WriteLine(myReader["id"].ToString());
            }
        }

        private static void connect( SqlConnection connection )
        {
            Console.WriteLine("called"); 
            try
            {
                Console.WriteLine("try"); 
                connection.Open();
            }
            catch( Exception e )
            {
                Console.WriteLine("exception caught"); 
                Console.WriteLine(e.ToString());
                Environment.Exit(0);
            }
        }

    }
}
