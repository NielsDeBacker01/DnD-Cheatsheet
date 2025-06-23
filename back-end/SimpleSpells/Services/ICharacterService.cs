using SimpleSpells.DTOs;

namespace SimpleSpells.Services
{
    public interface ICharacterService
    {
        Task<List<CharacterFullDto>> GetAllAsync();
        Task<CharacterFullDto?> GetByIdAsync(int id);
        Task<List<CharacterMinimalDto>> GetAllMinimalAsync();
        Task<CharacterMinimalDto?> GetMinimalByIdAsync(int id);
        Task<CharacterMinimalDto> AddAsync(CharacterMinimalDto dto);
        Task<CharacterMinimalDto?> UpdateAsync(int id, CharacterMinimalDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
