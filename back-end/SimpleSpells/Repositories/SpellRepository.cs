using Microsoft.EntityFrameworkCore;
using SimpleSpells.Data;
using SimpleSpells.Model;

namespace SimpleSpells.Repositories
{
    public class SpellRepository : ISpellRepository
    {
        private readonly MyDbContext _context;

        public SpellRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<Spell>> GetAllAsync()
        {
            return await _context.Spells.ToListAsync();
        }

        public async Task<Spell?> GetByIdAsync(int id)
        {
            return await _context.Spells.FindAsync(id);
        }
    }
}
