using api.Model.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model.ResultModel
{
    public class AdvanceRequestNotFoundErrorJson : IActionResult
    {
        private OngoingRequestModel _ongoingRequestModel;

        public AdvanceRequestNotFoundErrorJson(OngoingRequestModel ongoingRequestModel)
        {
            _ongoingRequestModel = ongoingRequestModel;
        }

        public Task ExecuteResultAsync(ActionContext context)
        {
            return new JsonResult(this).ExecuteResultAsync(context);
        }
    }
}
