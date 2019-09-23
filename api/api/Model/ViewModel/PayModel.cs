using api.Model.EntityModel;
using api.Model.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model.ViewModel
{
    public class PayModel
    {
        [Display(Name = "amount"), JsonRequired, JsonCurrency]
        public double? Amount { get; set; }
        [Display(Name = "installmentsAmmount"), JsonRequired, JsonInstallmentRange]
        public int? InstallmentsAmmount { get; set; }
        [Display(Name = "credicCardNumber"), JsonRequired, JsonCreditCard]
        public string CreditCardNumber { get; set; }

        public Transaction Map() => new Transaction
        {
            InitialDate = DateTime.Now,
            InstallmentsAmmount = InstallmentsAmmount.Value,
            TransactionValue = Amount.Value,
            CardLastDigits = int.Parse(CreditCardNumber.Substring(12))
        };

    }
}
