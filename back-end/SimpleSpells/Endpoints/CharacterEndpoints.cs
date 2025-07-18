using Microsoft.AspNetCore.Mvc;
using SimpleSpells.DTOs;
using SimpleSpells.Services;

namespace SimpleSpells.Endpoints
{
    public static class CharacterEndpoints
    {
        public static void MapCharacterEndpoints(this WebApplication app)
        {
            //functions for the default minimal characters
            app.MapGet("/characters", async (ICharacterService service) =>
            {
                var characters = await service.GetAllMinimalAsync();
                return Results.Ok(characters);
            });

            app.MapGet("/characters/{id:int}", async (int id, [FromServices] ICharacterService service) =>
            {
                var character = await service.GetMinimalByIdAsync(id);
                return character is not null ? Results.Ok(character) : Results.NotFound();
            });

            app.MapPost("/characters", async ([FromBody] CharacterMinimalDto dto, ICharacterService service) =>
            {
                var created = await service.AddAsync(dto);
                return Results.Created($"/characters/{created.Id}", created);
            });

            app.MapPut("/characters/{id:int}", async (int id, [FromBody] CharacterMinimalDto dto, [FromServices] ICharacterService service) =>
            {
                if (id != dto.Id)
                    return Results.BadRequest("ID mismatch");

                var updated = await service.UpdateAsync(id, dto);
                return updated is not null ? Results.Ok(updated) : Results.NotFound();
            });

            app.MapDelete("/characters/{id:int}", async (int id, [FromServices] ICharacterService service) =>
            {
                var deleted = await service.DeleteAsync(id);
                return deleted ? Results.NoContent() : Results.NotFound();
            });
            // functions for the full characters containing their spells
            app.MapGet("/characters/spells", async (ICharacterService service) =>
            {
                var characters = await service.GetAllAsync();
                return Results.Ok(characters);
            });

            app.MapGet("/characters/spells/{id:int}", async (int id, [FromServices] ICharacterService service) =>
            {
                var character = await service.GetByIdAsync(id);
                return character is not null ? Results.Ok(character) : Results.NotFound();
            });
        }
    }
}
