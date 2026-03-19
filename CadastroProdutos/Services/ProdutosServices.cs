using System;
using CadastroProdutos.Models;
using Microsoft.VisualBasic;

namespace CadastroProdutos.Services;

public class ProdutosServices : IProdutosServices
{

    private static List<Produto> produtos = new List<Produto>
    {
        new Produto() {Id = 1, Nome = "Mouse", Preco = 99.90m, Estoque = 50},
        new Produto() {Id = 2, Nome = "Teclado", Preco = 249.90m, Estoque = 30}
    };

    public List<Produto> BuscarTodos()
    {
        return produtos;
    }

    public Produto? BuscarPorId(int id)
    {
       return produtos.Find(item => item.Id == id);
    }

    public int AdicionarProduto(Produto novoProduto)
    {
        produtos.Add(novoProduto);
        return 1;
    }

    public Produto? AtualizarProduto(int id, Produto produtoAtualizado)
    {
        var produtoModificado = produtos.Find(item => item.Id == id);
        if (produtoModificado is null) return produtoModificado;

        produtoModificado.Nome = produtoAtualizado.Nome;
        produtoModificado.Preco = produtoAtualizado.Preco;
        produtoModificado.Estoque = produtoAtualizado.Estoque;

        return produtoModificado;
    }

    public Produto? DeletarProduto(int id)
    { 
        var produtoDeletado = produtos.Find(item => item.Id == id);

        if (produtoDeletado is null) return produtoDeletado;

        produtos.Remove(produtoDeletado);

        return produtoDeletado;
    }

}
