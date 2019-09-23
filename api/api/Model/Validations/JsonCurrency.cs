using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
