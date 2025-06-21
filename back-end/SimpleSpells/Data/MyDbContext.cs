using Microsoft.EntityFrameworkCore;
using SimpleSpells.Model;

namespace SimpleSpells.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<Spell> Spells { get; set; }
        public DbSet<Character> Characters { get; set; }
        /*
        // SEED DATA - This only runs during migrations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedSpells(modelBuilder);
            SeedCharacters(modelBuilder);
        }

        private void SeedCharacters(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>().HasData(
                new Character
                {
                    Id = 1,
                    Name = "Aragorn",
                    Level = 1,
                    SpellAtkBonus = 7,
                    SpellIds = {1, 2, 3},
                    Class = CharacterClass.Ranger,
                },
                new Character
                {
                    Id = 2,
                    Name = "Sandalphon",
                    Level = 7,
                    SpellAtkBonus = 5,
                    SpellIds = {1, 2, 3},
                    Class = CharacterClass.Fighter,
                },
                new Character
                {
                    Id = 3,
                    Name = "Shabar",
                    Level = 20,
                    SpellAtkBonus = 12,
                    SpellIds = {1, 2, 3},
                    Class = CharacterClass.Cleric,
                },
                new Character
                {
                    Id = 4,
                    Name = "Gale",
                    Level = 1,
                    SpellAtkBonus = 6,
                    SpellIds = {1, 2, 3},
                    Class = CharacterClass.Wizard,
                }
            );
        }
        
        private void SeedSpells(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Spell>().HasData(
                new Spell
                {
                    Id = 1,
                    Name = "Eldritch blast",
                    Url = "https://dnd5e.wikidot.com/spell:eldritch-blast",
                    SpellLevel = 0,
                    Vsm = "V,S",
                    Requirements = "",
                    Targets = "1",
                    Range = 0,
                    AOE = "",
                    Hitcheck = CheckType.Guaranteed,
                    Effect = "",
                    Upcast = "",
                    Availability = { SpellSource.Artificer },
                },         
                new Spell
                {
                    Id = 1,
                    Name = "Eldritch blast",
                    Url = "https://dnd5e.wikidot.com/spell:eldritch-blast",
                    SpellLevel = 0,
                    Vsm = "V,S",
                    Requirements = "",
                    Targets = "1",
                    Range = 0,
                    AOE = "",
                    Hitcheck = CheckType.Guaranteed,
                    Effect = "",
                    Upcast = "",
                    Availability = { SpellSource.Artificer },
                },  
                new Spell
                {
                    Id = 1,
                    Name = "Eldritch blast",
                    Url = "https://dnd5e.wikidot.com/spell:eldritch-blast",
                    SpellLevel = 0,
                    Vsm = "V,S",
                    Requirements = "",
                    Targets = "1",
                    Range = 0,
                    AOE = "",
                    Hitcheck = CheckType.Guaranteed,
                    Effect = "",
                    Upcast = "",
                    Availability = { SpellSource.Artificer },
                },  
                new Spell
                {
                    Id = 1,
                    Name = "Eldritch blast",
                    Url = "https://dnd5e.wikidot.com/spell:eldritch-blast",
                    SpellLevel = 0,
                    Vsm = "V,S",
                    Requirements = "",
                    Targets = "1",
                    Range = 0,
                    AOE = "",
                    Hitcheck = CheckType.Guaranteed,
                    Effect = "",
                    Upcast = "",
                    Availability = { SpellSource.Artificer },
                },
                new Spell
                {
                    Id = 1,
                    Name = "Eldritch blast",
                    Url = "https://dnd5e.wikidot.com/spell:eldritch-blast",
                    SpellLevel = 0,
                    Vsm = "V,S",
                    Requirements = "",
                    Targets = "1",
                    Range = 0,
                    AOE = "",
                    Hitcheck = CheckType.Guaranteed,
                    Effect = "",
                    Upcast = "",
                    Availability = { SpellSource.Artificer },
                },  
                new Spell
                {
                    Id = 1,
                    Name = "Eldritch blast",
                    Url = "https://dnd5e.wikidot.com/spell:eldritch-blast",
                    SpellLevel = 0,
                    Vsm = "V,S",
                    Requirements = "",
                    Targets = "1",
                    Range = 0,
                    AOE = "",
                    Hitcheck = CheckType.Guaranteed,
                    Effect = "",
                    Upcast = "",
                    Availability = { SpellSource.Artificer },
                }       
            );
        }*/
    }
}
