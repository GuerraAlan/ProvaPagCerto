using api.Model.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model.ViewModel
{
    public class RequestsBetweenDatesModel
    {
        [Display(Name = "initalDate"), JsonRequired]
        public DateTime? InitalDate { get; set; }
        
        [Display(Name = "finalDate"), JsonRequired]
        public DateTime? FinalDate { get; set; }
    }
}
