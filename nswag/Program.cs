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

	// nswag supports both the swaggerUI style and the reDoc style

	// app.UseSwaggerUi(options =>
	// {
	// 	options.DocumentPath = "/openapi/v1.json";
	// });

	app.UseReDoc(options =>
	{
		options.DocumentPath = "/openapi/v1.json";
	});
}

app.UseHttpsRedirection();
app.MapPersonRoutes(Sample.People());
await app.RunAsync();
