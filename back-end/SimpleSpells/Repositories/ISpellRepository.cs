using SimpleSpells.Model;

namespace SimpleSpells.Repositories
{
    public interface ISpellRepository
    {
        Task<List<Spell>> GetAllAsync();
        Task<Spell?> GetByIdAsync(int id);
    }
}
