var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
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

app.MapGet("/teste", () => "Esse é um endpoint de teste");

var produtos = new List<Produto>
{
    new Produto() {Id = 1, Nome = "Mouse", Preco = 99.90m, Estoque = 50},
    new Produto() {Id = 2, Nome = "Teclado", Preco = 249.90m, Estoque = 30}
};

app.MapGet("/produtos", () => produtos);

app.MapGet("/produtos/{id}", (int id) =>
{
    var produto = produtos.Find(item => item.Id == id);

    return produto is not null
    ? Results.Ok(produto)
    : Results.NotFound($"O id {id} não foi encontrado.");
}).WithName("GetById");

app.MapPost("/produtos", (ProdutoDto novoProduto) =>
{
    var index = produtos.Count + 1;

    var produto = new Produto()
    {
        Id = index,
        Nome = novoProduto.Nome,
        Preco = novoProduto.Preco,
        Estoque = novoProduto.Estoque

    };

    produtos.Add(produto);

    return Results.CreatedAtRoute("GetById", new { id = index }, produto);
});

app.MapPut("/produtos/{id}", (int id, ProdutoDto produtoAtualizado) =>
{
    var modificandoProduto = produtos.Find(item => item.Id == id);

    if (modificandoProduto is null)
    {
        return Results.NotFound("O id indicado não foi encontrado.");
    }

    modificandoProduto.Nome = produtoAtualizado.Nome;
    modificandoProduto.Preco = produtoAtualizado.Preco;
    modificandoProduto.Estoque = produtoAtualizado.Estoque;

    return Results.NoContent();

});

app.MapDelete("/produto/{id}", (int id) =>
{
    var produtoRemovido = produtos.Find(item => item.Id == id);

    if (produtoRemovido is null)
    {
        return Results.NotFound($"O produto de id {id} não foi encontrado.");
    }
    else
    {
        produtos.Remove(produtoRemovido);
        return Results.NoContent();
    }
});
    
app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public int Estoque { get; set; }
}

record ProdutoDto(string Nome, decimal Preco, int Estoque);