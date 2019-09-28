using api.Model.EntityModel;
using api.Model.Validations;
using System;
using System.ComponentModel.DataAnnotations;

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
