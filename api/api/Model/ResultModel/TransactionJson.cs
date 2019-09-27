using api.Model.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model.ResultModel
{
    public class TransactionJson
    {
        public TransactionJson(Transaction transaction)
        {
            InitialDate = transaction.InitialDate;
            TransactionValue = transaction.TransactionValue;
            InstallmentsAmount = transaction.InstallmentsAmount;
            CardLastDigits = transaction.CardLastDigits;
            AvailableInstallmentsAmmount = transaction.AvailableInstallmentsAmmount;
            RemainingValue = transaction.RemainingValue;
        }

        public DateTime InitialDate { get; set; }
        public double TransactionValue { get; set; }
        public int InstallmentsAmount { get; set; }
        public int CardLastDigits { get; set; }
        public int AvailableInstallmentsAmmount { get; set; }
        public double RemainingValue { get; set; }
    }
}
