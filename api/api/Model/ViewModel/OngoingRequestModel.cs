using api.Model.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model.ViewModel
{
    public class OngoingRequestModel
    {
        [Display(Name = "transactionId"), JsonRequired]
        public long? TransactionId { get; set; }
    }
}
