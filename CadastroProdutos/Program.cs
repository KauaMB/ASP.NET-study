using System.Linq.Expressions;
using System.Text;
using CadastroProdutos.Database;
using CadastroProdutos.Models;
using CadastroProdutos.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Description = @"Insira o JWT no campo abaixo usando o seguinte formato: Bearer {seu-token}",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    x.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("oauth2", document)] =
         new List<string>()
    });
});

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite("Data Source = Produtos.db"));

builder.Services.AddScoped<IProdutosServices, ProdutosDatabaseService>();

var jwtConfig = builder.Configuration.GetSection("Jwt");
var key = Encoding.ASCII.GetBytes(jwtConfig["Key"]);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtConfig["Issuer"],
        ValidAudience = jwtConfig["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

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

app.UseAuthentication();
app.UseAuthorization();

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

record ProdutoDto(string Nome, decimal Preco, int Estoque);