using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace api.Models
{
    public class FailedTransaction : IActionResult
    {
        public string Message { get; set; }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var json = new JsonResult(this) { StatusCode = 201 };

            await json.ExecuteResultAsync(context);
        }
        
    }
}