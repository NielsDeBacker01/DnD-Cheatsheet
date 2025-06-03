using Microsoft.EntityFrameworkCore;

namespace SimpleSpells.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        // Example DbSet
        public DbSet<Spell> Spells { get; set; }
    }

    public class Spell
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
