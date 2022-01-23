using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace api.Models
{
    public class Error : IActionResult
    {
        public string ErrorMessage { get; set; }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var json = new JsonResult(this) { StatusCode = 400 };

            await json.ExecuteResultAsync(context);
        }

    }
}