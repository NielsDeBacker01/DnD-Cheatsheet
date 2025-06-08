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

        public async Task<List<CharacterDto>> GetAllAsync()
        {
            var characters = await _repository.GetAllAsync();
            return characters.Select(MapToDto).ToList();
        }

        public async Task<CharacterDto?> GetByIdAsync(int id)
        {
            var character = await _repository.GetByIdAsync(id);
            return character == null ? null : MapToDto(character);
        }

        public async Task<CharacterDto> AddAsync(CharacterDto dto)
        {
            var character = MapToEntity(dto);
            var created = await _repository.AddAsync(character);
            return MapToDto(created);
        }

        public async Task<CharacterDto?> UpdateAsync(int id, CharacterDto dto)
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

            var updated = await _repository.UpdateAsync(existing);
            return updated == null ? null : MapToDto(updated);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        #region Mapping functions

        private static CharacterDto MapToDto(Character character) => new()
        {
            Id = character.Id,
            Name = character.Name,
            Level = character.Level,
            SpellAtkBonus = character.SpellAtkBonus,
            Class = character.Class.ToString()
        };

        private static Character MapToEntity(CharacterDto dto) => new()
        {
            Id = dto.Id,
            Name = dto.Name,
            Level = dto.Level,
            SpellAtkBonus = dto.SpellAtkBonus,
            Class = Enum.TryParse<CharacterClass>(dto.Class, out var parsedClass) ? parsedClass : CharacterClass.Artificer
        };

        #endregion
    }
}
