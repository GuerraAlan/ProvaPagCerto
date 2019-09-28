using api.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace api.Model.ResultModel
{
    public class AdvanceRequestErrorJson : IActionResult
    {
        private AdvanceRequestProcessing _advanceRequestProcessing;

        public AdvanceRequestErrorJson(AdvanceRequestProcessing AdvanceRequestProcessing)
        {
            _advanceRequestProcessing = AdvanceRequestProcessing;
        }

        public Task ExecuteResultAsync(ActionContext context)
        {
            return new JsonResult(this).ExecuteResultAsync(context);
        }
    }
}
