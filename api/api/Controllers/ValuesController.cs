using api.Infrastructure;
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

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public void Pay(PayModel payment)
        {

        }
        /*
         private static readonly double FLAT_RATE = 0.9;
        public DateTime? TransferDate { get; set; }
        public bool? AcquirerConfirmation { get; set; }
        public double TransactionValue { get; set; }
        public int InstallmentsAmmount { get; set; }
        public int CardLastDigits { get; set; }
        public virtual double TransferAmount => TransactionValue - FLAT_RATE;
        public virtual List<AdvanceRequest> AdvanceRequests { get; set; }
             */
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
