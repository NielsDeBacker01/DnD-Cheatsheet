using Microsoft.EntityFrameworkCore;

namespace SimpleSpells.Model
{
    public enum SpellSource{Artificer,Barbarian,Bard,Cleric,Druid,Fighter,Monk,Paladin,Ranger,Rogue,Sorcerer,Warlock,Wizard}
    public class SpellSourceMapping
    {
        public int SpellId { get; set; }
        public SpellSource Source { get; set; }
    }
}