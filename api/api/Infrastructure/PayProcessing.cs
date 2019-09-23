﻿using api.Model.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Infrastructure
{
    public class PayProcessing
    {
        private ApiDbContext _dbContext;
        public Transaction Payment { get; private set; }

        public PayProcessing(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Process(Transaction payment)
        {
            Payment = payment;
            _dbContext.Add(payment);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
