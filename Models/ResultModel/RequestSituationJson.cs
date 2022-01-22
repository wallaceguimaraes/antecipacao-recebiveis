using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models.EntityModel;
using Microsoft.AspNetCore.Mvc;

namespace api.Models.ResultModel
{
    public class RequestSituationJson : IActionResult
    {
        public RequestSituationJson() { }

        public RequestSituationJson(RequestSituation requestSituation)
        {
            RequestSituationId = requestSituation.RequestSituationId;
            RequestId = requestSituation.RequestId;
            AdvanceRequest = requestSituation.AdvanceRequest;
            SituationId = requestSituation.SituationId;
            Situation = requestSituation.Situation;
            StartDate = requestSituation.StartDate;
            EndDate = requestSituation.EndDate;

        }
        public int RequestSituationId { get; set; }
        public int RequestId { get; set; }
        public AdvanceRequest AdvanceRequest { get; set; }
        public int SituationId { get; set; }
        public Situation Situation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Task ExecuteResultAsync(ActionContext context)
        {
            return new JsonResult(this).ExecuteResultAsync(context);
        }

    }
}