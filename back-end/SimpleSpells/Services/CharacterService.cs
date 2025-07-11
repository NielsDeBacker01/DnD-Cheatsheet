using SimpleSpells.DTOs;
using SimpleSpells.Model;
using SimpleSpells.Mapping;
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

        public async Task<List<CharacterFullDto>> GetAllAsync()
        {
            var characters = await _repository.GetAllAsync();
            return characters.Select(CharacterMapper.MapToFullDto).ToList();
        }

        public async Task<CharacterFullDto?> GetByIdAsync(int id)
        {
            var character = await _repository.GetByIdAsync(id);
            return character == null ? null : CharacterMapper.MapToFullDto(character);
        }

        public async Task<List<CharacterMinimalDto>> GetAllMinimalAsync()
        {
            var characters = await _repository.GetAllAsync();
            return characters.Select(CharacterMapper.MapToMinimalDto).ToList();
        }

        public async Task<CharacterMinimalDto?> GetMinimalByIdAsync(int id)
        {
            var character = await _repository.GetByIdAsync(id);
            return character == null ? null : CharacterMapper.MapToMinimalDto(character);
        }


        public async Task<CharacterMinimalDto> AddAsync(CharacterMinimalDto dto)
        {
            var character = CharacterMapper.MapToEntity(dto);
            var created = await _repository.AddAsync(character);
            return CharacterMapper.MapToMinimalDto(created);
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
            return updated == null ? null : CharacterMapper.MapToMinimalDto(updated);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}