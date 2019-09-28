using System;
using System.Collections.Generic;
using System.Linq;

namespace api.Model.EntityModel
{
    public class Transaction : EntityModel
    {
        public static readonly double FLAT_RATE = 0.9;
        public DateTime? TransferDate { get; set; }
        public bool? AcquirerConfirmation { get; set; }
        public double TransactionValue { get; set; }
        public int InstallmentsAmount { get; set; }
        public int CardLastDigits { get; set; }
        public double TransferAmount { get; set; }
        public virtual List<AdvanceRequest> AdvanceRequests { get; set; }

        public virtual int AvailableInstallmentsAmmount => InstallmentsAmount - AdvanceRequests.Sum(ar => ar.InstallmentsAmount);
        public virtual double RemainingValue => TransferAmount - AdvanceRequests.Sum(ar => ar.TotalRequestValue);
    }
}
