using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Collections.Generic;

namespace sample;
public static class Routes
{
    public static void MapPersonRoutes(this WebApplication app, List<Person> people)
    {
        app.MapGet("/person", () => Results.Ok(people));
        app.MapGet("/person/{name}", (string name) => Results.Ok(people.FirstOrDefault(p => p.Name == name)));
        app.MapGet("/person/{id:int}", (int id) =>
        {
            var person = people.ElementAtOrDefault(id);
            return person != null ? Results.Ok(person) : Results.NotFound();
        });
        app.MapDelete("/person/{id:int}", (int id) =>
        {
            if (id < 0 || id >= people.Count)
            {
                return Results.NotFound();
            }
            people.RemoveAt(id);
            return Results.NoContent();
        });
        app.MapPost("/person", (Person person) =>
        {
            people.Add(person);
            return Results.Created($"/person/{people.Count}", person);
        });
    }
}