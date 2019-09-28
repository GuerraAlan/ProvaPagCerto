using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace api.Model.ResultModel
{
    public class AdvanceRequestNotFoundErrorJson : IActionResult
    {
        public long Id { get; set; }

        public AdvanceRequestNotFoundErrorJson(long id)
        {
            Id = id;
        }

        public Task ExecuteResultAsync(ActionContext context)
        {
            return new JsonResult(this).ExecuteResultAsync(context);
        }
    }
}
