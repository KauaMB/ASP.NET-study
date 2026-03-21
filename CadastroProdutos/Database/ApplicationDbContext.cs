using System;
using CadastroProdutos.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroProdutos.Database;

public class ApplicationDbContext : DbContext
{
    public DbSet<Produto> Produtos { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }
}
