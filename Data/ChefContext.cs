using ChefAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefAPI.Data
{
    public class ChefContext : DbContext
    {
        public ChefContext(DbContextOptions<ChefContext> opt) : base(opt)
        {

        }

        public DbSet<Chef> Chefs { get; set; }
    }
}