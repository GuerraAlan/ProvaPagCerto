using api.Model.EntityModel.Enums;
using System;

namespace api.Model.EntityModel
{
    public class AdvanceRequest : EntityModel
    {
        public static readonly double RATE = 0.038;
        public long TransactionId { get; set; }
        public virtual Transaction Transaction { get; set; }
        public AdvanceRequestStatus Status { get; set; }
        public DateTime? InitialAnalysisDate { get; set; }
        public DateTime? DoneAnalysisDate { get; set; }
        public bool? AnalysisResult { get; set; }
        public int InstallmentsAmount { get; set; }
        public virtual double TotalRequestValue => ((double)InstallmentsAmount / (double)Transaction.InstallmentsAmount) * Transaction.TransferAmount * (1 - (RATE * InstallmentsAmount));
    }
}
