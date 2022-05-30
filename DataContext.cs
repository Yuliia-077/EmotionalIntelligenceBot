using EmotionalIntelligenceBot.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmotionalIntelligenceBot
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {

        }

        public DbSet<AppUser> Users { get; set; }
    }
}
