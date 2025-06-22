using SimpleSpells.DTOs;

namespace SimpleSpells.Services
{
    public interface ICharacterService
    {
        Task<List<CharacterMinimalDto>> GetAllAsync();
        Task<CharacterMinimalDto?> GetByIdAsync(int id);
        Task<CharacterMinimalDto> AddAsync(CharacterMinimalDto dto);
        Task<CharacterMinimalDto?> UpdateAsync(int id, CharacterMinimalDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
