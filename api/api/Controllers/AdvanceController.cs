using api.Infrastructure;
using api.Model.EntityModel;
using api.Model.EntityModel.Enums;
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
            advanceRequest.Status = AdvanceRequestStatus.AguardandoAnalise;

            if (!requestAdvanceProcessing.Process(advanceRequest))
            {
                return new AdvanceRequestErrorJson(requestAdvanceProcessing);
            }

            return new AdvanceRequestJson(requestAdvanceProcessing.Request);
        }

        [HttpGet]
        [Route("ongoing-request")]
        public async Task<IActionResult> OngoingRequest(OngoingRequestModel model)
        {
            var advanceRequest = _dbContext.AdvanceRequest.AvailableToAdvanceRequest(model.TransactionId.Value).ToList().First();

            if (advanceRequest == null)
            {
                return new AdvanceRequestNotFoundErrorJson(model.TransactionId.Value);
            }

            return new AdvanceRequestJson(advanceRequest);
        }

        [HttpPut]
        [Route("start-request-analysis")]
        public async Task<IActionResult> StartRequestAnalysis(StartRequestAnalysisModel model)
        {
            var startRequestAnalysisProcessing = new StartRequestAnalysisProcessing(_dbContext);

            if (!startRequestAnalysisProcessing.Process(model))
            {
                return new AdvanceRequestNotFoundErrorJson(model.RequestId.Value);
            }

            return new AdvanceRequestJson(startRequestAnalysisProcessing.Request);
        }

        [HttpPut]
        [Route("finish-request-analysis")]
        public async Task<IActionResult> FinishRequestAnalysis(FinishRequestAnalysisModel model)
        {
            var finishRequestAnalysisProcessing = new FinishRequestAnalysisProcessing(_dbContext);

            if (!finishRequestAnalysisProcessing.Process(model))
            {
                return new AdvanceRequestNotFoundErrorJson(model.RequestId.Value);
            }

            return new AdvanceRequestJson(finishRequestAnalysisProcessing.Request);
        }

        [HttpGet]
        [Route("requests-between-dates")]
        public async Task<IActionResult> RequestsBetweenDates(RequestsBetweenDatesModel model)
        {
            var advanceRequests = _dbContext.AdvanceRequest.GetBetweenDates(model.InitalDate.Value, model.FinalDate.Value).ToList();

            return new AdvanceRequestJsonList(advanceRequests);
        }
    }
}
