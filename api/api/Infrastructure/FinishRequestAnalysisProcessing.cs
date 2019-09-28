using api.Model.EntityModel;
using api.Model.EntityModel.Enums;
using api.Model.ViewModel;
using System;
using System.Linq;

namespace api.Infrastructure
{
    public class FinishRequestAnalysisProcessing : AProcessing
    {
        public AdvanceRequest Request { get; private set; }

        public FinishRequestAnalysisProcessing(ApiDbContext dbContext) : base(dbContext) { }

        public bool Process(FinishRequestAnalysisModel request)
        {
            Request = _dbContext.AdvanceRequest.GetById(request.RequestId.Value).ToList().First();

            if (Request == null)
            {
                LaunchError("RequestTransactionID Invalid");
                return false;
            }

            if (Request.Status == AdvanceRequestStatus.Finalizada)
            {
                LaunchError("Request Analysis already done");
                return false;
            }

            if (Request.Status != AdvanceRequestStatus.EmAnalise)
            {
                LaunchError("Request Analysis yet to start");
                return false;
            }

            Request.DoneAnalysisDate = DateTime.Now;
            Request.Status = AdvanceRequestStatus.Finalizada;
            Request.AnalysisResult = request.Approved;

            _dbContext.SaveChanges();
            return true;
        }
    }
}
