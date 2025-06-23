using SimpleSpells.DTOs;
using SimpleSpells.Mapping;
using SimpleSpells.Repositories;

namespace SimpleSpells.Services
{
    public class SpellService : ISpellService
    {
        private readonly ISpellRepository _repository;

        public SpellService(ISpellRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<SpellDto>> GetAllAsync()
        {
            var spells = await _repository.GetAllAsync();
            return spells.Select(SpellMapper.MapToDto).ToList();
        }

        public async Task<SpellDto?> GetByIdAsync(int id)
        {
            var spell = await _repository.GetByIdAsync(id);
            return spell == null ? null : SpellMapper.MapToDto(spell);
        }
    }
}
