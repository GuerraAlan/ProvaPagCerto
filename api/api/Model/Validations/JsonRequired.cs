using System.ComponentModel.DataAnnotations;

namespace api.Model.Validations
{
    public class JsonRequired : RequiredAttribute
    {
        public JsonRequired()
        {
            ErrorMessage = "{0}: Required.";
        }
    }
}
