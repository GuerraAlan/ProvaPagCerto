using api.Model.Validations;
using System;
using System.ComponentModel.DataAnnotations;

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
