using System.Threading.Tasks;
using api.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace api.Model.ResultModel
{
    public class PaymentErrorJson : IActionResult
    {
        private PayProcessing _payProcessing;

        public PaymentErrorJson(PayProcessing payProcessing)
        {
            _payProcessing = payProcessing;
        }

        public Task ExecuteResultAsync(ActionContext context)
        {
            return new JsonResult(this).ExecuteResultAsync(context);
        }
    }
}
