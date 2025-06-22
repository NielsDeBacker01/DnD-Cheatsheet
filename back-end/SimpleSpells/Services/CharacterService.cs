using SimpleSpells.DTOs;
using SimpleSpells.Model;
using SimpleSpells.Repositories;

namespace SimpleSpells.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _repository;

        public CharacterService(ICharacterRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CharacterMinimalDto>> GetAllAsync()
        {
            var characters = await _repository.GetAllAsync();
            return characters.Select(MapToMinimalDto).ToList();
        }

        public async Task<CharacterMinimalDto?> GetByIdAsync(int id)
        {
            var character = await _repository.GetByIdAsync(id);
            return character == null ? null : MapToMinimalDto(character);
        }

        public async Task<CharacterMinimalDto> AddAsync(CharacterMinimalDto dto)
        {
            var character = MapToEntity(dto);
            var created = await _repository.AddAsync(character);
            return MapToMinimalDto(created);
        }

        public async Task<CharacterMinimalDto?> UpdateAsync(int id, CharacterMinimalDto dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return null;

            // Update entity with DTO values
            existing.Name = dto.Name;
            existing.Level = dto.Level;
            existing.SpellAtkBonus = dto.SpellAtkBonus;

            // Parse enum from string safely
            if (Enum.TryParse<CharacterClass>(dto.Class, out var parsedClass))
            {
                existing.Class = parsedClass;
            }

            // Update CharacterSpells - clear existing and add new ones
            existing.CharacterSpells.Clear();
            if (dto.SpellIds != null)
            {
                existing.CharacterSpells.AddRange(
                    dto.SpellIds.Select(spellId => new CharacterSpell { SpellId = spellId, CharacterId = id })
                );
            }

            var updated = await _repository.UpdateAsync(existing);
            return updated == null ? null : MapToMinimalDto(updated);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        #region Mapping functions

        private static CharacterMinimalDto MapToMinimalDto(Character character) => new()
        {
            Id = character.Id,
            Name = character.Name,
            Level = character.Level,
            SpellAtkBonus = character.SpellAtkBonus,
            Class = character.Class.ToString(),
            SpellIds = character.CharacterSpells?.Select(cs => cs.SpellId).ToList() ?? new List<int>()
        };

        private static Character MapToEntity(CharacterMinimalDto dto) => new()
        {
            Id = dto.Id,
            Name = dto.Name,
            Level = dto.Level,
            SpellAtkBonus = dto.SpellAtkBonus,
            Class = Enum.TryParse<CharacterClass>(dto.Class, out var parsedClass) ? parsedClass : CharacterClass.Artificer,
            CharacterSpells = dto.SpellIds?.Select(spellId => new CharacterSpell { SpellId = spellId }).ToList() ?? new List<CharacterSpell>()
        };

        #endregion
    }
}