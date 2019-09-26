using api.Infrastructure;
using api.Model.EntityModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        }

        public long Id { get; set; }
        public DateTime InitialDate { get; set; }
        public int InstallmentsAmount { get; set; }
        public double TotalRequestValue { get; set; }

        public Task ExecuteResultAsync(ActionContext context)
        {
            return new JsonResult(this).ExecuteResultAsync(context);
        }
    }
}
