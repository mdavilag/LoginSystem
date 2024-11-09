using LoginSystemApi.Mappings;
using LoginSystemApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginSystemApi.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
                
        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap);
        }
    }
}
