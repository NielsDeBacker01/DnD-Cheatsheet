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
                Action = spell.Action.ToString(),
                Concentration = spell.Concentration,
                Targets = spell.Targets,
                Range = spell.Range,
                AOE = spell.AOE,
                Hitcheck = spell.Hitcheck.ToString(),
                Effect = spell.Effect,
                Upcast = spell.Upcast,
                Sources = spell.Sources.Select(a => a.Source).ToList(),
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
                Action = Enum.TryParse<ActionCost>(dto.Action, out var action) ? action : ActionCost.Action,
                Concentration = dto.Concentration,
                Targets = dto.Targets,
                Range = dto.Range,
                AOE = dto.AOE,
                Hitcheck = Enum.TryParse<CheckType>(dto.Hitcheck, out var check) ? check : CheckType.Guaranteed,
                Effect = dto.Effect,
                Upcast = dto.Upcast,
                Sources = dto.Sources.Select(a => new SpellSourceMapping{Source = a}).ToList()
            };
        }

        #endregion
    }
}
