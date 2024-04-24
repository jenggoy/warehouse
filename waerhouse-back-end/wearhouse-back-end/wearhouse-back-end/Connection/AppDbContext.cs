using Microsoft.EntityFrameworkCore;
using wearhouse_back_end.Models.DatabaseModels;

namespace wearhouse_back_end.Connection
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            
        }

        public DbSet<MsUser> MsUser { get; set; }
        public DbSet<MsCategory> MsCategory { get; set; }
    }
}
