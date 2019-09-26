using api.Model.EntityModel;
using api.Model.EntityModel.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace api.Infrastructure
{
    public class AdvanceRequestProcessing
    {
        private ApiDbContext _dbContext;
        public AdvanceRequest Request { get; private set; }

        public AdvanceRequestProcessing(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Process(AdvanceRequest request)
        {
            Request = request;
            
            var requestTransaction = _dbContext.Transaction.Include(t => t.AdvanceRequests).Where(t => t.Id == request.TransactionId).ToList()?.First();

            if(requestTransaction == null)
            {
                Console.WriteLine("RequestTransactionID Invalid");//TODO: Ver maneira melhor depois, exception?
                return false;
            }

            if(requestTransaction.AdvanceRequests.Any(ar => !(ar.AnalysisResult.Equals(AdvanceRequestStatus.Finalizada)&& ar.AnalysisResult.Equals(true))))
            {
                Console.WriteLine("Already open request");
                return false;
            }

            var adiantadas = requestTransaction.AdvanceRequests.Select(ar => ar.InstallmentsAmount).Sum();

            if(request.InstallmentsAmount + adiantadas > requestTransaction.InstallmentsAmount)
            {
                Console.WriteLine("Exceded Installments limit");
                return false;
            }

            _dbContext.Add(request);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
