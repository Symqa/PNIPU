using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using System.IO;
using System;

namespace Lab3.Pages
{
    public class IndexModel : PageModel
    {
        public List<EmployeesAddresses> employeesAddressesList { get; private set; } 
                                        = new List<EmployeesAddresses>();
        public List<EmployeesInfo> employeesInfoList { get; private set; }
                                    = new List<EmployeesInfo>();
        public List<EmployeesOlderThanFour> employeesOlderThanFoursList { get; private set; }
                                            = new List<EmployeesOlderThanFour>();
        public void OnGet()
        {
            string connectionString = "" +
                "Server=localhost;" +
                "Database=sheremet;" +
                "Uid=root;" +
                "Pwd=12345";

            Dictionary<string, string> sqlRequests = new Dictionary<string, string>()
            {
                {nameof(EmployeesAddresses), System.IO.File.ReadAllText("P:\\PNIPU\\БД\\Labs\\№2\\Запросы\\getEmployeesAddresses.sql").Replace('\n', ' ')},
                {nameof(EmployeesInfo), System.IO.File.ReadAllText("P:\\PNIPU\\БД\\Labs\\№2\\Запросы\\getEmployeesInfo.sql").Replace('\n', ' ')},
                {nameof(EmployeesOlderThanFour), System.IO.File.ReadAllText("P:\\PNIPU\\БД\\Labs\\№2\\Запросы\\getOlderThan4.sql").Replace('\n', ' ')}
            };
            

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

            }
        }
    }
}
