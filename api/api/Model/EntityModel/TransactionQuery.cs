﻿using api.Model.EntityModel.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace api.Model.EntityModel
{
    public static class TransactionQuery
    {
        public static IQueryable<Transaction> AvailableToAdvanceRequest(this IQueryable<Transaction> transactions)
        {
            return transactions.Where(transaction =>
                                        !transaction.AdvanceRequests.Any(ar => !(ar.AnalysisResult.Equals(AdvanceRequestStatus.Finalizada)
                                                                                && ar.AnalysisResult.Equals(true)))).Include(t => t.AdvanceRequests);
        }
    }
}
