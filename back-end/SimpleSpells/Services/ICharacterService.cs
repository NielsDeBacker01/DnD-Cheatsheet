using SimpleSpells.DTOs;

namespace SimpleSpells.Services
{
    public interface ICharacterService
    {
        Task<List<CharacterDto>> GetAllAsync();
        Task<CharacterDto?> GetByIdAsync(int id);
        Task<CharacterDto> AddAsync(CharacterDto dto);
        Task<CharacterDto?> UpdateAsync(int id, CharacterDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
