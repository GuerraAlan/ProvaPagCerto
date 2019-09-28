using api.Model.EntityModel;

namespace api.Infrastructure
{
    public class PayProcessing : AProcessing
    {
        public Transaction Payment { get; private set; }

        public PayProcessing(ApiDbContext dbContext) : base(dbContext) { }

        public bool Process(Transaction payment)
        {
            payment.TransferAmount = payment.TransactionValue * (1 - Transaction.FLAT_RATE);
            Payment = payment;
            _dbContext.Add(payment);
            _dbContext.SaveChanges();
            if (payment.Id.HasValue) return true;
            else return false;
        }
    }
}
