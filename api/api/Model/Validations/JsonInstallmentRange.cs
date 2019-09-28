using System.ComponentModel.DataAnnotations;

namespace api.Model.Validations
{
    public class JsonInstallmentRange : RangeAttribute
    {
        private const int Minimum = 1;
        private const int Maximum = 24;

        public JsonInstallmentRange() : base(Minimum, Maximum)
        {
            ErrorMessage = "{0}: Between " + Minimum + " and " + Maximum + ".";
        }
    }
}
