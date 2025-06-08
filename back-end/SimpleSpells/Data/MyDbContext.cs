using Microsoft.EntityFrameworkCore;
using SimpleSpells.Model;

namespace SimpleSpells.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<Spell> Spells { get; set; }
        public DbSet<Character> Characters { get; set; }
    }
}
