using SimpleSpells.DTOs;
using SimpleSpells.Model;
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
            return spells.Select(MapToDto).ToList();
        }

        public async Task<SpellDto?> GetByIdAsync(int id)
        {
            var spell = await _repository.GetByIdAsync(id);
            return spell == null ? null : MapToDto(spell);
        }

        #region Mapping functions

        private static SpellDto MapToDto(Spell spell)
        {
            return new SpellDto
            {
                Id = spell.Id,
                Name = spell.Name,
                Url = spell.Url,
                SpellLevel = spell.SpellLevel,
                Vsm = spell.Vsm,
                Requirements = spell.Requirements,
                Targets = spell.Targets,
                Range = spell.Range,
                AOE = spell.AOE,
                Hitcheck = spell.Hitcheck.ToString(),
                Effect = spell.Effect,
                Upcast = spell.Upcast,
                Availability = spell.Availability.Select(a => a.ToString()).ToList()
            };
        }

        private static Spell MapToEntity(SpellDto dto)
        {
            return new Spell
            {
                Id = dto.Id,
                Name = dto.Name,
                Url = dto.Url,
                SpellLevel = dto.SpellLevel,
                Vsm = dto.Vsm,
                Requirements = dto.Requirements,
                Targets = dto.Targets,
                Range = dto.Range,
                AOE = dto.AOE,
                Hitcheck = Enum.TryParse<CheckType>(dto.Hitcheck, out var check) ? check : CheckType.Guaranteed,
                Effect = dto.Effect,
                Upcast = dto.Upcast,
                Availability = dto.Availability.Select(Enum.Parse<SpellSource>).ToList()
            };
        }

        #endregion
    }
}
