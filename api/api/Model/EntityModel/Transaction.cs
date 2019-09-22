using api.Model.EntityModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model.EntityModel
{
    public class Transaction : EntityModel
    {
        private static readonly double FLAT_RATE = 0.9;
        public DateTime? TransferDate { get; set; }
        public bool? AcquirerConfirmation { get; set; }
        public double TransactionValue { get; set; }
        public int InstallmentsAmmount { get; set; }
        public int CardLastDigits { get; set; }
        public virtual double TransferAmount => TransactionValue - FLAT_RATE;
        public virtual List<AdvanceRequest> AdvanceRequests { get; set; }
    }
}
