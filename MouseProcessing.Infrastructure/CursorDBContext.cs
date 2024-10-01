using Microsoft.EntityFrameworkCore;
using MouseProcessing.Infrastructure.Entities;
using System.Reflection;

namespace MouseProcessing.Infrastructure
{
    public class CursorDBContext : DbContext
    {
        public DbSet<CursorInfoEntity> CursorInfos { get; set; } = null!;
        public CursorDBContext(DbContextOptions<CursorDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
