using System.ComponentModel.DataAnnotations;

namespace CadastroProdutos.DTOs;

public record class LoginDto
(
    [Required]
    string Usuario,
    [Required]
    string Senha
);
