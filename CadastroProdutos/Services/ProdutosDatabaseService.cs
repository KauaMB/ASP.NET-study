using System;
using CadastroProdutos.Database;
using CadastroProdutos.Models;

namespace CadastroProdutos.Services;

public class ProdutosDatabaseService : IProdutosServices
{
    private ApplicationDbContext Context;

    public ProdutosDatabaseService (ApplicationDbContext context)
    {
        Context = context;
    }

    public void AdicionarProduto(Produto novoProduto)
    {
        Context.Produtos.Add(novoProduto);
        Context.SaveChanges();
    }

    public Produto? AtualizarProduto(int id, Produto produtoAtualizado)
    {   
        var produtoModificado = Context.Produtos.Find(id);

        if (produtoModificado is null) return null;

        produtoModificado.Nome = produtoAtualizado.Nome;
        produtoModificado.Estoque = produtoAtualizado.Estoque;
        produtoModificado.Preco = produtoAtualizado.Preco;
        Context.SaveChanges();

        return produtoModificado;
    }

    public Produto? BuscarPorId(int id)
    {
        return Context.Produtos.FirstOrDefault(item => item.Id == id);
    }

    public List<Produto> BuscarTodos()
    {
        return Context.Produtos.ToList();
    }

    public Produto? DeletarProduto(int id)
    {
        var produtoDeletado = Context.Produtos.FirstOrDefault(x => x.Id == id);
        if (produtoDeletado is null) return null;

        Context.Produtos.Remove(produtoDeletado);
        Context.SaveChanges();
        return produtoDeletado;
    }
}
