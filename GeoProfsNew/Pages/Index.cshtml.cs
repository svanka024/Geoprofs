using GeoProfsNew.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Data;

namespace GeoProfsNew.Pages
{
    public class IndexModel : PageModel
    {
        public ActionResult DisplayData()
        {
            // Read data from files and store it in a model
            var data = ReadDataFromFiles();

            // Pass data to the view
            return View(data);
        }
    }
    using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
    adapter.Fill(dataTable);

                    // Vul de DataGridView met de gegevens
                    dataGridView1.DataSource = dataTable;
                }
            }
        }
}

