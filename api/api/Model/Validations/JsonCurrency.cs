using System.ComponentModel.DataAnnotations;

namespace api.Model.Validations
{
    public class JsonCurrency : RangeAttribute
    {
        private const double Minimum = 0;
        private const double Maximum = 999999.99;

        public JsonCurrency() : base(Minimum, Maximum)
        {
            ErrorMessage = "{0}: Between {Minimum} and {Maximum}.";
        }
    }
}
