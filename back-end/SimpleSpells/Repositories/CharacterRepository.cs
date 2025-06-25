using Microsoft.EntityFrameworkCore;
using SimpleSpells.Data;
using SimpleSpells.Model;

namespace SimpleSpells.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly MyDbContext _context;

        public CharacterRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<Character>> GetAllAsync()
        {
            return await _context.Characters
            .Include(c => c.CharacterSpells)
                .ThenInclude(cs => cs.Spell)
            .ToListAsync();
        }

        public async Task<Character?> GetByIdAsync(int id)
        {
            return await _context.Characters
                .Include(c => c.CharacterSpells)
                    .ThenInclude(cs => cs.Spell)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Character> AddAsync(Character character)
        {
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            return character;
        }

        public async Task<Character?> UpdateAsync(Character character)
        {
            var existing = await _context.Characters.Include(c => c.CharacterSpells).FirstOrDefaultAsync(c => c.Id == character.Id);
            if (existing == null) return null;

            // Update properties
            existing.Name = character.Name;
            existing.Level = character.Level;
            existing.SpellAtkBonus = character.SpellAtkBonus;
            existing.Class = character.Class;
            existing.CharacterSpells = character.CharacterSpells;

            await _context.SaveChangesAsync();
            return existing;            
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var character = await _context.Characters.FindAsync(id);
            if (character == null) return false;

            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}