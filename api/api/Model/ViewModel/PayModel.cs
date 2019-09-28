using api.Model.EntityModel;
using api.Model.Validations;
using System;
using System.ComponentModel.DataAnnotations;

namespace api.Model.ViewModel
{
    public class PayModel
    {
        [Display(Name = "amount"), JsonRequired, JsonCurrency]
        public double? Amount { get; set; }
        [Display(Name = "installmentsAmount"), JsonRequired, JsonInstallmentRange]
        public int? InstallmentsAmount { get; set; }
        [Display(Name = "credicCardNumber"), JsonRequired]
        public string CreditCardNumber { get; set; }

        public Transaction Map() => new Transaction
        {
            InitialDate = DateTime.Now,
            InstallmentsAmount = InstallmentsAmount.Value,
            TransactionValue = Amount.Value,
            CardLastDigits = int.Parse(CreditCardNumber.Substring(12))
        };

    }
}
