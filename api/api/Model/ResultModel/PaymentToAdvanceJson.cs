using api.Model.EntityModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model.ResultModel
{
    public class PaymentToAdvanceJson : IActionResult
    {
        public PaymentToAdvanceJson() { }

        public PaymentToAdvanceJson(Transaction payment)
        {
            Id = payment.Id ?? 0;
            Amount = payment.TransactionValue;
            TransferAmount = payment.TransferAmount;
            CardLastDigits = payment.CardLastDigits;
        }

        public long Id { get; set; }
        public double Amount { get; set; }
        public double TransferAmount { get; set; }
        public int CardLastDigits { get; set; }

        public Task ExecuteResultAsync(ActionContext context)
        {
            return new JsonResult(this).ExecuteResultAsync(context);
        }
    }
}
