using api.Model.Validations;
using System.ComponentModel.DataAnnotations;

namespace api.Model.ViewModel
{
    public class StartRequestAnalysisModel
    {
        [Display(Name = "requestId"), JsonRequired]
        public long? RequestId { get; set; }
    }
}
