using api.Infrastructure;
using api.Model.EntityModel;
using api.Model.ResultModel;
using api.Model.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers
{
    [Route("api/v1/transaction")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ApiDbContext _dbContext;

        public TransactionController(ApiDbContext apiDbContext)
        {
            _dbContext = apiDbContext;
        }

        [HttpPost]
        [Route("pay")]
        public async Task<IActionResult> Pay(PayModel model)
        {
            var payProcessing = new PayProcessing(_dbContext);

            var payment = model.Map();

            if (!payProcessing.Process(payment))
            {
                return new PaymentErrorJson(payProcessing);
            }

            return new PaymentJson(payProcessing.Payment);
        }

        [HttpGet]
        [Route("available-to-advance")]
        public async Task<IActionResult> GetAvailableToAdvanceRequest()
        {
            var transactions = _dbContext.Transaction.AvailableToAdvanceRequest().ToList();

            return new PaymentsToAdvanceListJson(transactions);
        }
    }
}
