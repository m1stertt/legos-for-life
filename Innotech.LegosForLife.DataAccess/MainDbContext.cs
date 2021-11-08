using InnoTech.LegosForLife.Core.Models;
using Innotech.LegosForLife.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Innotech.LegosForLife.DataAccess
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options): base(options)
        {
            
        }

        public virtual DbSet<ProductEntity> Products { get; set; }
    }
}