using api.Model.EntityModel;
using api.Model.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model.ViewModel
{
    public class AdvanceRequestModel
    {
        [Display(Name = "transactionId"), JsonRequired]
        public long? TransactionId { get; set; }
        [Display(Name = "installmentsAmount"), JsonRequired, JsonInstallmentRange]
        public int? InstallmentsAmount { get; set; }

        public AdvanceRequest Map() => new AdvanceRequest
        {
            InitialDate = DateTime.Now,
            InstallmentsAmount = InstallmentsAmount.Value,
            TransactionId = TransactionId.Value
        };
    }
}
