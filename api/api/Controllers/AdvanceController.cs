using api.Infrastructure;
using api.Model.EntityModel;
using api.Model.ResultModel;
using api.Model.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers
{
    [Route("api/v1/advance")]
    [ApiController]
    public class AdvanceController : ControllerBase
    {
        private readonly ApiDbContext _dbContext;

        public AdvanceController(ApiDbContext apiDbContext)
        {
            _dbContext = apiDbContext;
        }

        [HttpPost]
        [Route("request")]
        public async Task<IActionResult> RequestAdvance(AdvanceRequestModel model)
        {
            var requestAdvanceProcessing = new AdvanceRequestProcessing(_dbContext);

            var advanceRequest = model.Map();

            if (!requestAdvanceProcessing.Process(advanceRequest))
            {
                return new AdvanceRequestErrorJson(requestAdvanceProcessing);
            }

            return new AdvanceRequestJson(requestAdvanceProcessing.Request);
        }
    }
}
