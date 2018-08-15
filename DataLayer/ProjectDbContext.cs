using FrameworkLab.Entities;
using Microsoft.EntityFrameworkCore;

namespace FrameworkLab.DataLayer
{
    public class ProjectDbContext : DbContext
    {
        public DbSet<Master> Masters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseInMemoryDatabase("SharedName");
        }
    }
}