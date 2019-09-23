using api.Model.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Infrastructure
{
    public class PayProcessing
    {
        private ApiDbContext _dbContext;
        public PayProcessing(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Process(Transaction payment)
        {
            _dbContext.Add(payment);
            return true;
        }
    }
}
