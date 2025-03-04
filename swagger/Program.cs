using Microsoft.Extensions.Options;

using sample;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
	app.UseSwaggerUI(options =>
	{
		options.SwaggerEndpoint("/openapi/v1.json", "SwaggerUI");
		options.EnableTryItOutByDefault(); // Enable TryItOut by default
	});
}

app.UseHttpsRedirection();
app.MapPersonRoutes(Sample.People());

await app.RunAsync();
