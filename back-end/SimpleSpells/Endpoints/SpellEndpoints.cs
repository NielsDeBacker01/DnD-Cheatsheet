using Microsoft.AspNetCore.Mvc;
using SimpleSpells.Services;

namespace SimpleSpells.Endpoints
{
    public static class SpellEndpoints
    {
        public static void MapSpellEndpoints(this WebApplication app)
        {
            app.MapGet("/spells", async (ISpellService service) =>
            {
                var spells = await service.GetAllAsync();
                return Results.Ok(spells);
            });

            app.MapGet("/spells/{id:int}", async (int id, [FromServices] SpellService service) =>
            {
                var spell = await service.GetByIdAsync(id);
                return spell is not null ? Results.Ok(spell) : Results.NotFound();
            });
        }
    }
}
