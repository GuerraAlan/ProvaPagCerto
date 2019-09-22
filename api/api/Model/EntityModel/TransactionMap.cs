

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model.EntityModel
{
    public static class TransactionMap
    {
        public static void Map(this EntityTypeBuilder<Transaction> entity)
        {
            entity.ToTable("Table");
        }
    }
}
