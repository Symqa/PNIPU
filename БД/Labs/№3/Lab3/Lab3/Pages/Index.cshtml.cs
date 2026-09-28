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

                // --- ЗАПРОС 1: Адреса
                using (MySqlCommand cmd1 = new MySqlCommand(sqlRequests[nameof(EmployeesAddresses)], connection))
                {
                    using (MySqlDataReader reader = cmd1.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employeesAddressesList.Add(new EmployeesAddresses
                            {
                                id = reader.GetInt32(0),
                                fullName = reader.GetString(1),
                                address = reader.GetString(2)
                            });
                        }
                    }
                }

                // --- ЗАПРОС 2: Информация ---
                using (MySqlCommand cmd2 = new MySqlCommand(sqlRequests[nameof(EmployeesInfo)], connection))
                {
                    using (MySqlDataReader reader2 = cmd2.ExecuteReader())
                    {
                        while (reader2.Read())
                        {
                            employeesInfoList.Add(new EmployeesInfo
                            {
                                id = reader2.GetInt32(0),
                                fullName = reader2.GetString(1),
                                phoneNumber = reader2.GetString(2),
                                salary = reader2.GetDecimal(3)
                            });
                        }
                    }
                }
                // --- ЗАПРОС 3: Стаж больше 4 ---
                using (MySqlCommand cmd3 = new MySqlCommand(sqlRequests[nameof(EmployeesOlderThanFour)], connection))
                {
                    using (MySqlDataReader reader3 = cmd3.ExecuteReader())
                    {
                        while (reader3.Read())
                        {
                            employeesOlderThanFoursList.Add(new EmployeesOlderThanFour
                            {
                                id = reader3.GetInt32(0),
                                fullName = reader3.GetString(1),
                                yearsOfService = reader3.GetInt32(2)
                            });
                        }
                    }
                }
            }
        }

 
    }
}
