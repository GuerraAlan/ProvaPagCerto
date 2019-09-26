using api.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model.ResultModel
{
    public class AdvanceRequestErrorJson : IActionResult
    {
        private AdvanceRequestProcessing _aAdvanceRequestProcessing;

        public AdvanceRequestErrorJson(AdvanceRequestProcessing aAdvanceRequestProcessing)
        {
            _aAdvanceRequestProcessing = aAdvanceRequestProcessing;
        }

        public Task ExecuteResultAsync(ActionContext context)
        {
            return new JsonResult(this).ExecuteResultAsync(context);
        }
    }
}
