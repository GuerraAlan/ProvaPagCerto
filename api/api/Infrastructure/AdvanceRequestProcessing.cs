using api.Model.EntityModel;
using api.Model.EntityModel.Enums;
using System.Linq;

namespace api.Infrastructure
{
    public class AdvanceRequestProcessing : AProcessing
    {
        public AdvanceRequest Request { get; private set; }

        public AdvanceRequestProcessing(ApiDbContext dbContext) : base(dbContext) { }

        public bool Process(AdvanceRequest request)
        {
            Request = request;

            var requestTransaction = _dbContext.Transaction.Where(t => t.Id == request.TransactionId).ToList()?.First();

            if (requestTransaction == null)
            {
                LaunchError("RequestTransactionID Invalid");
                return false;
            }

            if (requestTransaction.AdvanceRequests.Any(ar => !ar.AnalysisResult.Equals(AdvanceRequestStatus.Finalizada)))
            {
                LaunchError("Already open request");
                return false;
            }

            var adiantadas = requestTransaction.AdvanceRequests.Select(ar => ar.InstallmentsAmount).Sum();

            if (request.InstallmentsAmount + adiantadas > requestTransaction.InstallmentsAmount)
            {
                LaunchError("Exceded Installments limit");
                return false;
            }

            _dbContext.Add(request);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
