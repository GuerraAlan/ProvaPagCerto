using api.Infrastructure;
using api.Model.ResultModel;
using api.Model.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ApiDbContext _dbContext;

        public ValuesController(ApiDbContext apiDbContext)
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
    }
}
