using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using QC = Microsoft.Data.SqlClient;

namespace Learning_IT
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //using (var connection = new QC.SqlConnection(
            //    "Server=tcp:learningit.database.windows.net,1433;Initial" +
            //    " Catalog=serverlearning;Persist Security Info=False;User ID=gabriel;" +
            //    "Password={stancu123456a!};MultipleActiveResultSets=False;" +
            //    "Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            //    ))
            //{
            //    connection.Open();
            //    Console.WriteLine("Connected successfully.");

            //    Console.WriteLine("Press any key to finish...");
            //    Console.ReadKey(true);
            //}



            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
