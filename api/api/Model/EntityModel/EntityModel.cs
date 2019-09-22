using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model.EntityModel
{
    public abstract class EntityModel
    {
        public long Id { get; set; }
        public DateTime InitialDate { get; set; }
    }
}
