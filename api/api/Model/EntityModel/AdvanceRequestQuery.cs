using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace api.Model.EntityModel
{
    public static class AdvanceRequestQuery
    {
        public static IQueryable<AdvanceRequest> AvailableToAdvanceRequest(this IQueryable<AdvanceRequest> requests, long transactionId)
        {
            return requests.Where(request => request.TransactionId == transactionId).Include(t => t.Transaction);
        }

        public static IQueryable<AdvanceRequest> GetById(this IQueryable<AdvanceRequest> requests, long requestId)
        {
            return requests.Where(request => request.Id == requestId).Include(t => t.Transaction);
        }

        public static IQueryable<AdvanceRequest> GetBetweenDates(this IQueryable<AdvanceRequest> requests, DateTime InitalDate, DateTime FinalDate)
        {
            return requests.Where(request => request.InitialDate >= InitalDate && request.InitialDate <= FinalDate).Include(t => t.Transaction);
        }
    }
}
