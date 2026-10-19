using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using MySqlConnector;
using Microsoft.Data.SqlClient.DataClassification;

namespace Lab4.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            string connectionString = "" +
              "Server=localhost;" +
              "Database=sheremet_4;" +
              "Uid=root;" +
              "Pwd=12345";
        }


        public class SqlRequest
        {
            public string Query { get; set; }
        }

        public IActionResult OnPostExecuteSql([FromBody] SqlRequest request)
        {
            string connectionString = "" +
              "Server=localhost;" +
              "Uid=root;" +
              "Pwd=12345";

            try
            {

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(request.Query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.FieldCount > 0)
                            {
                                var columns = new System.Collections.Generic.List<string>();
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    columns.Add(reader.GetName(i));
                                }

                                var rows = new System.Collections.Generic.List<System.Collections.Generic.List<string>>();
                                while (reader.Read())
                                {
                                    var row = new System.Collections.Generic.List<string>();
                                    for (int i = 0; i < reader.FieldCount; i++)
                                    {
                                        row.Add(reader.IsDBNull(i) ? "NULL" : reader.GetValue(i).ToString());
                                    }
                                    rows.Add(row);
                                }
                                return new JsonResult(new
                                {
                                    success = true,
                                    isData = true,
                                    columns = columns,
                                    rows = rows,
                                    message = $"Найдено строк: {rows.Count}"
                                });
                            } else
                            {
                                // CREATE, DROP, ALTER, INSERT, UPDATE, DELETE)
                                return new JsonResult(new
                                {
                                    success = true,
                                    isData = false,
                                    message = $"Команда успешно выполнена. Затронуто строк: {reader.RecordsAffected}"
                                });
                            }
                        }
                    }
                }

            } 
            catch (MySqlException sqlEx)
            {
                return new JsonResult(new { success = false, message = $"Ошибка SQL: {sqlEx.Message}" });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, message = $"Системная ошибка: {ex.Message}" });
            }
        }
    }
}
