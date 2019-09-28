using api.Model.EntityModel;
using api.Model.EntityModel.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace api.Model.ResultModel
{
    public class AdvanceRequestJson : IActionResult
    {
        public AdvanceRequestJson() { }

        public AdvanceRequestJson(AdvanceRequest request)
        {
            Id = request.Id ?? 0;
            InitialDate = request.InitialDate;
            InstallmentsAmount = request.InstallmentsAmount;
            TotalRequestValue = request.TotalRequestValue;
            Status = request.Status;
            AnalysisResult = request.AnalysisResult;
            DoneAnalysisDate = request.DoneAnalysisDate;
            Transaction = new TransactionJson(request.Transaction);
        }

        public long Id { get; set; }
        public DateTime InitialDate { get; set; }
        public int InstallmentsAmount { get; set; }
        public double TotalRequestValue { get; set; }
        public AdvanceRequestStatus Status { get; set; }
        public bool? AnalysisResult { get; set; }
        public DateTime? DoneAnalysisDate { get; set; }
        public TransactionJson Transaction { get; set; }

        public Task ExecuteResultAsync(ActionContext context)
        {
            return new JsonResult(this).ExecuteResultAsync(context);
        }
    }
}
