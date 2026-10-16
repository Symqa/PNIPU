using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
    }
}
