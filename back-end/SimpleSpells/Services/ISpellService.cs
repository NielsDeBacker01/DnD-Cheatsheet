using SimpleSpells.DTOs;

namespace SimpleSpells.Services
{
    public interface ISpellService
    {
        Task<List<SpellDto>> GetAllAsync();
        Task<SpellDto?> GetByIdAsync(int id);
    }
}
