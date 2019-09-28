using api.Model.EntityModel;
using Microsoft.EntityFrameworkCore;

namespace api.Infrastructure
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<AdvanceRequest> AdvanceRequest { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }
    }
}
