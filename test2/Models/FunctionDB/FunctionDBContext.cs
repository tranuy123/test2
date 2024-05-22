using Microsoft.EntityFrameworkCore;

namespace test2.Models.FunctionDB
{

    public class FunctionDBContext : DbContext
    {
        public FunctionDBContext(DbContextOptions<FunctionDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
