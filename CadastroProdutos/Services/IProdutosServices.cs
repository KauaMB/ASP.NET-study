using System;
using CadastroProdutos.Models;

namespace CadastroProdutos.Services;

public interface IProdutosServices
{
    public List<Produto> BuscarTodos();

    public Produto? BuscarPorId(int id);

    public int AdicionarProduto(Produto novoProduto);

    public Produto? AtualizarProduto(int id, Produto produtoAtualizado);

    public Produto? DeletarProduto(int id);
}
