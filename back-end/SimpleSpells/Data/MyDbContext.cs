using Microsoft.EntityFrameworkCore;
using SimpleSpells.Model;

namespace SimpleSpells.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<Spell> Spells { get; set; }
        public DbSet<Character> Characters { get; set; }

        // SEED DATA - This only runs during migrations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacterSpell>()
                .HasKey(cs => new { cs.CharacterId, cs.SpellId });

            modelBuilder.Entity<SpellSourceMapping>()
                .HasKey(ssm => new { ssm.SpellId, ssm.Source }); 

            modelBuilder.Entity<CharacterSpell>()
                .HasOne(cs => cs.Character)
                .WithMany(c => c.CharacterSpells)
                .HasForeignKey(cs => cs.CharacterId);

            modelBuilder.Entity<CharacterSpell>()
                .HasOne(cs => cs.Spell)
                .WithMany()
                .HasForeignKey(cs => cs.SpellId);

            SeedSpells(modelBuilder);
            SeedCharacters(modelBuilder);
            SeedCharacterSpells(modelBuilder);
            SeedAvailability(modelBuilder);
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
                    Class = CharacterClass.Ranger,
                },
                new Character
                {
                    Id = 2,
                    Name = "Sandalphon",
                    Level = 7,
                    SpellAtkBonus = 5,
                    Class = CharacterClass.Fighter,
                },
                new Character
                {
                    Id = 3,
                    Name = "Shabar",
                    Level = 20,
                    SpellAtkBonus = 12,
                    Class = CharacterClass.Cleric,
                },
                new Character
                {
                    Id = 4,
                    Name = "Gale",
                    Level = 1,
                    SpellAtkBonus = 6,
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
                },
                new Spell
                {
                    Id = 2,
                    Name = "Eldritch blast{5}",
                    Url = "https://dnd5e.wikidot.com/spell:eldritch-blast",
                    SpellLevel = 0,
                    Vsm = "V,S",
                    Targets = "2",
                    Range = 120,
                    Hitcheck = CheckType.Spell_Attack,
                    Effect = "{base=1D10} force damage",
                },
                new Spell
                {
                    Id = 3,
                    Name = "Eldritch blast{11}",
                    Url = "https://dnd5e.wikidot.com/spell:eldritch-blast",
                    SpellLevel = 0,
                    Vsm = "V,S",
                    Targets = "3",
                    Range = 120,
                    Hitcheck = CheckType.Spell_Attack,
                    Effect = "{base=1D10} force damage",
                },
                new Spell
                {
                    Id = 4,
                    Name = "Eldritch blast{17}",
                    Url = "https://dnd5e.wikidot.com/spell:eldritch-blast",
                    SpellLevel = 0,
                    Vsm = "V,S",
                    Targets = "4",
                    Range = 120,
                    Hitcheck = CheckType.Spell_Attack,
                    Effect = "{base=1D10} force damage",
                },
                new Spell
                {
                    Id = 5,
                    Name = "Gust",
                    Url = "https://dnd5e.wikidot.com/spell:gust",
                    SpellLevel = 0,
                    Vsm = "V,S",
                    Targets = "1",
                    Range = 30,
                    Hitcheck = CheckType.Strength_Saving_Throw,
                    Effect = "-Push medium creature 5ft -Push object 10ft",
                },
                new Spell
                {
                    Id = 6,
                    Name = "Bless",
                    Url = "https://dnd5e.wikidot.com/spell:bless",
                    SpellLevel = 1,
                    Vsm = "V,S,M",
                    Concentration = "1 minute",
                    Targets = "3",
                    Range = 30,
                    Hitcheck = CheckType.Guaranteed,
                    Effect = "d4 attack roll / saving throw bonus",
                    Upcast = "1 extra target",
                },
                new Spell
                {
                    Id = 7,
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
                },
                new Spell
                {
                    Id = 8,
                    Name = "Call lightning",
                    Url = "https://dnd5e.wikidot.com/spell:call-lightning",
                    SpellLevel = 3,
                    Vsm = "V,S",
                    Requirements = "Open sky",
                    Concentration = "10 minutes",
                    Targets = "1",
                    Range = 120,
                    AOE = "15ft square",
                    Hitcheck = CheckType.Dexterity_Saving_Throw,
                    Effect = "Spawn 60ft cloud {Base: 3d10} lightning damage",
                    Upcast = "{Base: 1d10} extra damage",
                },
                new Spell
                {
                    Id = 9,
                    Name = "Dark star",
                    Url = "https://dnd5e.wikidot.com/spell:dark-star",
                    SpellLevel = 8,
                    Vsm = "V,S,M",
                    Concentration = "1 minute",
                    Targets = "",
                    Range = 150,
                    AOE = "40ft square",
                    Hitcheck = CheckType.Constitution_Saving_Throw,
                    Effect = "Difficult terrain, Darkness, Thunder immunity, Deafened, {Base: 8d10} force damage",
                }
            );
        }

        private void SeedCharacterSpells(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacterSpell>().HasData(
                // Aragorn's spells
                new CharacterSpell { CharacterId = 1, SpellId = 1 },
                new CharacterSpell { CharacterId = 1, SpellId = 5 },
                new CharacterSpell { CharacterId = 1, SpellId = 6 },

                // Sandalphon's spells
                new CharacterSpell { CharacterId = 2, SpellId = 2 },

                // Shabar's spells
                new CharacterSpell { CharacterId = 3, SpellId = 4 },
                new CharacterSpell { CharacterId = 3, SpellId = 6 },
                new CharacterSpell { CharacterId = 3, SpellId = 8 },
                new CharacterSpell { CharacterId = 3, SpellId = 9 },

                // Gale's spells
                new CharacterSpell { CharacterId = 4, SpellId = 5 },
                new CharacterSpell { CharacterId = 4, SpellId = 6 },
                new CharacterSpell { CharacterId = 4, SpellId = 7 }
            );
        }
        
        private void SeedAvailability(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpellSourceMapping>().HasData(
                new SpellSourceMapping { SpellId = 1, Source = SpellSource.Warlock },
                new SpellSourceMapping { SpellId = 2, Source = SpellSource.Warlock },
                new SpellSourceMapping { SpellId = 3, Source = SpellSource.Warlock },
                new SpellSourceMapping { SpellId = 4, Source = SpellSource.Warlock },
                new SpellSourceMapping { SpellId = 5, Source = SpellSource.Druid },
                new SpellSourceMapping { SpellId = 5, Source = SpellSource.Sorcerer },
                new SpellSourceMapping { SpellId = 5, Source = SpellSource.Wizard },
                new SpellSourceMapping { SpellId = 6, Source = SpellSource.Cleric },
                new SpellSourceMapping { SpellId = 6, Source = SpellSource.Sorcerer },
                new SpellSourceMapping { SpellId = 7, Source = SpellSource.Wizard },
                new SpellSourceMapping { SpellId = 7, Source = SpellSource.Sorcerer },
                new SpellSourceMapping { SpellId = 8, Source = SpellSource.Druid },
                new SpellSourceMapping { SpellId = 9, Source = SpellSource.Wizard }
            );
        }
    }
}
