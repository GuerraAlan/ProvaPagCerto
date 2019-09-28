using System.ComponentModel.DataAnnotations;

namespace api.Model.Validations
{
    public class JsonCreditCard : ValidationAttribute
    {
        public JsonCreditCard() : base()
        {
            ErrorMessage = "{0}: Invalid.";
        }

        public override bool IsValid(object value)
        {
            if (value == null || value.ToString().Length != 14) return false;
            return new CreditCardAttribute().IsValid(value);
        }
    }
}
