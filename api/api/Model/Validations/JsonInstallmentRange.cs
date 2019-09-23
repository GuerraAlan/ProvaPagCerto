using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model.Validations
{
    public class JsonInstallmentRange : RangeAttribute
    {
        private const int Minimum = 1;
        private const int Maximum = 24;

        public JsonInstallmentRange() : base(Minimum, Maximum)
        {
            ErrorMessage = $"{0}: Between {Minimum} and {Maximum}.";
        }
    }
}
