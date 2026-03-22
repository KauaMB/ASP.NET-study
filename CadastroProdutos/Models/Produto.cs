using System;
using System.ComponentModel.DataAnnotations;

namespace CadastroProdutos.Models;

public class Produto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O usuário deve passar um nome.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O usuário deve passar um valor de preço.")]
    [Range(0, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero.")]
    public decimal Preco { get; set; }

    [Required(ErrorMessage = "O usuário deve pasar um valor de estoque.")]
    [Range(0, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero.")]
    public int Estoque { get; set; }
}
