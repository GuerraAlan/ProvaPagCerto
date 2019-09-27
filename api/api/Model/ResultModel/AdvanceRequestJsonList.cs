using api.Model.EntityModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model.ResultModel
{
    public class AdvanceRequestJsonList : IActionResult
    {
        public AdvanceRequestJsonList() { }

        public AdvanceRequestJsonList(List<AdvanceRequest> requests)
        {
            Requests = requests.Select(t => new AdvanceRequestJson(t)).ToList();
        }

        public List<AdvanceRequestJson> Requests { get; set; }

        public Task ExecuteResultAsync(ActionContext context)
        {
            return new JsonResult(this).ExecuteResultAsync(context);
        }
    }
}
