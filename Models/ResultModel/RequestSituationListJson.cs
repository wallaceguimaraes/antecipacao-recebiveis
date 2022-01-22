using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models.EntityModel;
using Microsoft.AspNetCore.Mvc;

namespace api.Models.ResultModel
{
    public class RequestSituationListJson: IActionResult
    {
        public RequestSituationListJson() { }

        public RequestSituationListJson(IEnumerable<RequestSituation> requestSituations)
        {
            RequestSituations = requestSituations.Select(requestSituation => new RequestSituationJson(requestSituation)).ToList();
        }
        
        public IEnumerable<RequestSituationJson> RequestSituations { get; set; }

        public Task ExecuteResultAsync(ActionContext context)
        {
            return new JsonResult(this).ExecuteResultAsync(context);
        }
        
        
    }
}