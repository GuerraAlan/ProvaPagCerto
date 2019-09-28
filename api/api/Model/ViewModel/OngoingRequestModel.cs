using api.Model.Validations;
using System.ComponentModel.DataAnnotations;

namespace api.Model.ViewModel
{
    public class OngoingRequestModel
    {
        [Display(Name = "transactionId"), JsonRequired]
        public long? TransactionId { get; set; }
    }
}
