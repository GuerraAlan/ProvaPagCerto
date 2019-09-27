using api.Model.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
