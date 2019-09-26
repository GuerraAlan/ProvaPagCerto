using api.Model.EntityModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Infrastructure
{
    public class ApiDbContext : DbContext
    {
        //public DbSet<EntityModel> EntityDbContext { get; set; }

        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<AdvanceRequest> AdvanceRequest { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<Transaction>();
        //    builder.Entity<AdvanceRequest>();

        //    base.OnModelCreating(builder);
        //}

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
            //options.WithExtension(TransactionQuery);
        }
    }
}
