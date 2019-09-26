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
            InstallmentValues = possibleInstallments(payment).ToList();

            NetValue = Math.Round((1 - (AdvanceRequest.RATE * payment.InstallmentsAmount)) * TransferAmount, 2);
        }

        public long Id { get; set; }
        public double Amount { get; set; }
        public double TransferAmount { get; set; }
        public double NetValue { get; }
        public int CardLastDigits { get; set; }
        public List<Installment> InstallmentValues { get; set; }

        public Task ExecuteResultAsync(ActionContext context)
        {
            return new JsonResult(this).ExecuteResultAsync(context);
        }

        private IEnumerable<Installment> possibleInstallments(Transaction transaction)
        {
            var available = transaction.AvailableInstallmentsAmmount;

            for (int i = 1; i <= available; i++)
            {
                yield return calcInstallment(i, available, transaction.RemainingValue);
            }
        }

        private Installment calcInstallment(int numberOfInstallments, int maxInstallments, double value)
        {
            var missing = maxInstallments - numberOfInstallments +1;
            var rate = 1 - (numberOfInstallments * AdvanceRequest.RATE);
            return new Installment(numberOfInstallments, (((double)numberOfInstallments / (double)(maxInstallments)) * value)*rate);
        }

        public class Installment
        {
            public int InstallmentAmount { get; set; }
            public double Value { get; set; }

            public Installment(int amount, double value)
            {
                InstallmentAmount = amount;
                Value = Math.Round(value, 2);
            }

        }
    }

    
}
