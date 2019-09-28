using api.Model.EntityModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace api.Model.ResultModel
{
    public class PaymentJson : IActionResult
    {
        public PaymentJson() { }

        public PaymentJson(Transaction payment)
        {
            Id = payment.Id ?? 0;
            InitialDate = payment.InitialDate;
            Amount = payment.TransferAmount;
        }

        public long Id { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime? CanceledAt { get; set; }
        public double Amount { get; set; }

        public Task ExecuteResultAsync(ActionContext context)
        {
            return new JsonResult(this).ExecuteResultAsync(context);
        }
    }
}
