using api.Model.EntityModel;
using api.Model.EntityModel.Enums;
using api.Model.ViewModel;
using System;
using System.Linq;

namespace api.Infrastructure
{
    public class StartRequestAnalysisProcessing : AProcessing
    {
        public AdvanceRequest Request { get; private set; }

        public StartRequestAnalysisProcessing(ApiDbContext dbContext) : base(dbContext) { }

        public bool Process(StartRequestAnalysisModel request)
        {
            Request = _dbContext.AdvanceRequest.GetById(request.RequestId.Value).ToList().First();

            if (Request == null)
            {
                LaunchError("Request not found");
                return false;
            }

            if (Request.Status != AdvanceRequestStatus.AguardandoAnalise)
            {
                LaunchError("Request Analysis already started");
                return false;
            }

            Request.InitialAnalysisDate = DateTime.Now;
            Request.Status = AdvanceRequestStatus.EmAnalise;

            _dbContext.SaveChanges();
            return true;
        }
    }
}
