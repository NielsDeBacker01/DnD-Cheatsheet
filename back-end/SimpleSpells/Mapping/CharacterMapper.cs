using SimpleSpells.DTOs;
using SimpleSpells.Model;

namespace SimpleSpells.Mapping
{
    public class CharacterMapper
    {
        public static CharacterMinimalDto MapToMinimalDto(Character character) => new()
        {
            Id = character.Id,
            Name = character.Name,
            Level = character.Level,
            SpellAtkBonus = character.SpellAtkBonus,
            Class = character.Class.ToString(),
            SpellIds = character.CharacterSpells?.Select(cs => cs.SpellId).ToList() ?? new List<int>()
        };

        public static CharacterFullDto MapToFullDto(Character character) => new()
        {
            Id = character.Id,
            Name = character.Name,
            Level = character.Level,
            SpellAtkBonus = character.SpellAtkBonus,
            Class = character.Class.ToString(),
            Spells = character.CharacterSpells?.Where(cs => cs.Spell != null).Select(cs => SpellMapper.MapToDto(cs.Spell!)).ToList() ?? new List<SpellDto>()
        };

        public static Character MapToEntity(CharacterMinimalDto dto) => new()
        {
            Id = dto.Id,
            Name = dto.Name,
            Level = dto.Level,
            SpellAtkBonus = dto.SpellAtkBonus,
            Class = Enum.TryParse<CharacterClass>(dto.Class, out var parsedClass) ? parsedClass : CharacterClass.Artificer,
            CharacterSpells = dto.SpellIds?.Select(spellId => new CharacterSpell { SpellId = spellId }).ToList() ?? new List<CharacterSpell>()
        };
    }
}