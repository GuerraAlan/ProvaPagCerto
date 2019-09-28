using api.Model.Validations;
using System.ComponentModel.DataAnnotations;

namespace api.Model.ViewModel
{
    public class FinishRequestAnalysisModel
    {
        [Display(Name = "requestId"), JsonRequired]
        public long? RequestId { get; set; }
        [Display(Name = "approved"), JsonRequired]
        public bool? Approved { get; set; }
    }
}
