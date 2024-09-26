using Microsoft.EntityFrameworkCore;
using WebApiTenis.Models;

namespace WebApiTenis.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions <AppDbContext> options): base(options)
        {
            
        }

        public DbSet<Tenis> tenis { get; set; }
    }
}
