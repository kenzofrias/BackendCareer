var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(); //Adiciona um serviço para gerar documentação OpenAPI (Swagger) para a API.

var app = builder.Build(); //Constrói a aplicação web com base nas configurações definidas no builder.

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
} // Se a aplicação estiver em ambiente de desenvolvimento, mapeia o endpoint para a documentação OpenAPI (Swagger), permitindo que os desenvolvedores visualizem e testem a API.

app.UseHttpsRedirection(); // Adiciona um middleware que redireciona automaticamente solicitações HTTP para HTTPS, garantindo que a comunicação seja segura.

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.MapGet("/api/status", () =>
{
    return Results.Ok(new
    {
        application = "OrderFlow",
        status = "Online",
        message = "A API está funcionando!"
    });
});

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
