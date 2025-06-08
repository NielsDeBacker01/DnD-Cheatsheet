using SimpleSpells.Model;

namespace SimpleSpells.Repositories
{
    public interface ICharacterRepository
    {
        Task<List<Character>> GetAllAsync();
        Task<Character?> GetByIdAsync(int id);
        Task<Character> AddAsync(Character character);
        Task<Character?> UpdateAsync(Character character);
        Task<bool> DeleteAsync(int id);
    }
}
