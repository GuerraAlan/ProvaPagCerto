using api.Model.EntityModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model.ResultModel
{
    public class PaymentsToAdvanceListJson : IActionResult
    {
        public PaymentsToAdvanceListJson() { }

        public PaymentsToAdvanceListJson(List<Transaction> transactions)
        {
            Payments = transactions.Select(t => new PaymentToAdvanceJson(t)).ToList();
        }

        public List<PaymentToAdvanceJson> Payments { get; set; }

        public Task ExecuteResultAsync(ActionContext context)
        {
            return new JsonResult(this).ExecuteResultAsync(context);
        }
    }
}
