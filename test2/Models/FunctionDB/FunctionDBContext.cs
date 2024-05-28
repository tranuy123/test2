using Microsoft.EntityFrameworkCore;

namespace test2.Models.FunctionDB
{

    public class FunctionDBContext : DbContext
    {
        public FunctionDBContext(DbContextOptions<FunctionDBContext> options) : base(options)
        { 
        }

        public virtual DbSet<Sto_ReadByStrored> Sto_ReadByStrored { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sto_ReadByStrored>().HasNoKey();
        }
    }
}
