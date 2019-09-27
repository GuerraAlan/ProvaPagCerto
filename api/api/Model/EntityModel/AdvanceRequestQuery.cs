using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model.EntityModel
{
    public static class AdvanceRequestQuery
    {
        public static IQueryable<AdvanceRequest> AvailableToAdvanceRequest(this IQueryable<AdvanceRequest> requests, long transactionId)
        {
            return requests.Where(request => request.TransactionId == transactionId).Include(t => t.Transaction);
        }
    }
}
