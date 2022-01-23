using api.Models.EntityModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.ResultModel
{
    public class TransferListJson: IActionResult
    {
        public TransferListJson() { }
        public TransferListJson(IEnumerable<Transfer> transfers)
        {
            Transfers = transfers.Select(transfer => new TransferJson(transfer)).ToList();
        }
        public IEnumerable<TransferJson> Transfers { get; set; }
        public Task ExecuteResultAsync(ActionContext context)
        {
            return new JsonResult(this).ExecuteResultAsync(context);
        }
    }
}