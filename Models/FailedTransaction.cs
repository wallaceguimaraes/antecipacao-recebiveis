using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace api.Models
{
    public class FailedTransaction : IActionResult
    {
        public string ErrorMessage { get; set; }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var json = new JsonResult(this) { StatusCode = 201 };

            await json.ExecuteResultAsync(context);
        }
        
    }
}