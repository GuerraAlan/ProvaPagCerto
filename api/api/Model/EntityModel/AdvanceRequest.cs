using api.Model.EntityModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model.EntityModel
{
    public class AdvanceRequest : EntityModel
    {
        private static readonly double RATE = 0.038;
        public long TransactionId { get; set; }
        public virtual Transaction Transaction { get; set; }
        public AdvanceRequestStatus Status { get; set; }
        public DateTime? InitialAnalysisDate { get; set; }
        public DateTime? DoneAnalysisDate { get; set; }
        public bool? AnalysisResult { get; set; }
        public virtual double RequestValue => Transaction.TransferAmount;
        public virtual double TotalRequestValue => RequestValue * (1 - (RATE * Transaction.InstallmentsAmmount));
    }
}
