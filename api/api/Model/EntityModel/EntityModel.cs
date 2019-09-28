using System;

namespace api.Model.EntityModel
{
    public abstract class EntityModel
    {
        public long? Id { get; set; }
        public DateTime InitialDate { get; set; }
    }
}