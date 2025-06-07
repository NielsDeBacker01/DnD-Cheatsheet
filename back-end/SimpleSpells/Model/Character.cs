using Microsoft.EntityFrameworkCore;

namespace SimpleSpells.Model
{
    public enum CharacterClass{Artificer,Barbarian,Bard,Cleric,Druid,Fighter,Monk,Paladin,Ranger,Rogue,Sorcer,Warlock,Wizard}

    public class Character
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required int Level { get; set; } = 1;
        public required int SpellAtkBonus { get; set; } = 0;
        public List<Spell> Spells { get; set; } = new();
        public required CharacterClass Class { get; set; } = CharacterClass.Artificer;
    }
}
