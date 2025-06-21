using Microsoft.EntityFrameworkCore;
using SimpleSpells.Model;

namespace SimpleSpells.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<Spell> Spells { get; set; }
        public DbSet<Character> Characters { get; set; }
        /*// SEED DATA - This only runs during migrations
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
                    Name = "Eldritch blast{1}",
                    Url = "https://dnd5e.wikidot.com/spell:eldritch-blast",
                    SpellLevel = 0,
                    Vsm = "V,S",
                    Targets = "1",
                    Range = 120,
                    Hitcheck = CheckType.Spell_Attack,
                    Effect = "{base=1D10} force damage",
                    Availability = { SpellSource.Warlock },
                },         
                new Spell
                {
                    Id = 2,
                    Name = "Gust",
                    Url = "https://dnd5e.wikidot.com/spell:gust",
                    SpellLevel = 0,
                    Vsm = "V,S",
                    Targets = "1",
                    Range = 30,
                    Hitcheck = CheckType.Strength_Saving_Throw,
                    Effect = "-Push medium creature 5ft -Push object 10ft",
                    Availability = { SpellSource.Druid, SpellSource.Sorcerer, SpellSource.Wizard },
                },  
                new Spell
                {
                    Id = 3,
                    Name = "Bless",
                    Url = "https://dnd5e.wikidot.com/spell:bless",
                    SpellLevel = 1,
                    Vsm = "V,S,M",
                    Requirements = "Concentration 1 minute",
                    Targets = "3",
                    Range = 30,
                    Hitcheck = CheckType.Guaranteed,
                    Effect = "d4 attack roll / saving throw bonus",
                    Upcast = "1 extra target",
                    Availability = { SpellSource.Artificer },
                },  
                new Spell
                {
                    Id = 4,
                    Name = "Chromatic orb",
                    Url = "https://dnd5e.wikidot.com/spell:chromatic-orb",
                    SpellLevel = 1,
                    Vsm = "V,S,M",
                    Requirements = "50 GP diamond",
                    Targets = "1",
                    Range = 90,
                    Hitcheck = CheckType.Spell_Attack,
                    Effect = "{Base: 3D8} acid/cold/fire/lightning/poison/thunder damage",
                    Upcast = "{Base: 1d8} extra damage",
                    Availability = { SpellSource.Sorcerer, SpellSource.Wizard },
                },
                new Spell
                {
                    Id = 5,
                    Name = "Call lightning",
                    Url = "https://dnd5e.wikidot.com/spell:call-lightning",
                    SpellLevel = 3,
                    Vsm = "V,S",
                    Requirements = "Concentration 10 minutes",
                    Targets = "1",
                    Range = 120,
                    AOE = "15ft square",
                    Hitcheck = CheckType.Dexterity_Saving_Throw,
                    Effect = "Spawn 60ft cloud {Base: 3d10} lightning damage",
                    Upcast = "{Base: 1d10} extra damage",
                    Availability = { SpellSource.Artificer },
                },  
                new Spell
                {
                    Id = 6,
                    Name = "Eldritch blast",
                    Url = "https://dnd5e.wikidot.com/spell:dark-star",
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
