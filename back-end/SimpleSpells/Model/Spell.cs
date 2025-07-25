using Microsoft.EntityFrameworkCore;

namespace SimpleSpells.Model
{
    public enum ActionCost{Action, Bonus_Action, Reaction};
    public enum CheckType{Guaranteed, Spell_Attack, Weapon_Attack, Strength_Saving_Throw, Dexterity_Saving_Throw, Constitution_Saving_Throw, Wisdom_Saving_Throw, Intelligence_Saving_Throw, Charisma_Saving_Throw, Flat_Saving_Throw};

    public class Spell
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Url { get; set; }
        public required int SpellLevel { get; set; }
        public required string Vsm { get; set; }
        public string Requirements { get; set; } = "";
        public ActionCost Action { get; set; } = ActionCost.Bonus_Action;
        public string Concentration { get; set; } = "";
        public required string Targets { get; set; } = "1";
        public required int Range { get; set; }
        public string AOE { get; set; } = "";
        public CheckType Hitcheck { get; set; } = CheckType.Spell_Attack;
        public required string Effect { get; set; }
        public string Upcast { get; set; } = "";
        public List<SpellSourceMapping> Sources { get; set; } = new();
    }
}