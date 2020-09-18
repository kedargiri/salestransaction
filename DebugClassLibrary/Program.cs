using System;
using SalesTransaction.Application.DataAccessLayer;
using SalesTransaction.Application.Service.Account;

namespace DebugClassLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            TestClassLibrary();
        }

            private static void TestClassLibrary()
        {
            DataAccessHelper da = new DataAccessHelper("Data Source=10.6.0.246;Initial Catalog=Kedar;Persist Security Info=True;User ID=intern;Password=intern001");
            da.GetConnection();

            
           

           
        }
    }
}
