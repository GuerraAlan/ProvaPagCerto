using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model.Validations
{
    public class JsonRequired : RequiredAttribute
    {
        public JsonRequired()
        {
            ErrorMessage = $"{0}: Required.";
        }
    }
}
