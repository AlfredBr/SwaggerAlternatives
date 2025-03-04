using sample;

using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
	app.MapScalarApiReference(options =>
	{
		options.OpenApiRoutePattern = "/openapi/v1.json";
	});
}

app.UseHttpsRedirection();

app.MapPersonRoutes(Sample.People());
await app.RunAsync();
