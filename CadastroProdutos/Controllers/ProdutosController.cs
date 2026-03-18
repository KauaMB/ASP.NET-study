using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CadastroProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private static List<Produto> produtos = new List<Produto>
        {
         new Produto() {Id = 1, Nome = "Mouse", Preco = 99.90m, Estoque = 50},
         new Produto() {Id = 2, Nome = "Teclado", Preco = 249.90m, Estoque = 30}
        };

        [HttpGet]
        public ActionResult<List<Produto>> Get()
        {
            return Ok(produtos);


        }



        [HttpGet("{id}")]
        public ActionResult<List<Produto>> BuscarPorId(int id)
        {
            var produto = produtos.Find(item => item.Id == id);

            if (produto is null)
            {
                return NotFound($"O item de id {id} não foi encontrado");
            }

            return Ok(produto);
        }

        [HttpPost]
        public ActionResult<Produto> AdicionarProduto(Produto novoProduto)
        {
            produtos.Add(novoProduto);
            return Created();
        }

        [HttpPut("{id}")]
        public ActionResult AtualizarProduto(Produto produtoAtualizado, int id)
        {
            var atualizador = produtos.Find(item => item.Id == id);

            atualizador.Nome = produtoAtualizado.Nome;
            atualizador.Estoque = produtoAtualizado.Estoque;
            atualizador.Preco = produtoAtualizado.Preco;

            return Ok(atualizador);
        }

        [HttpDelete("{id}")]
        public ActionResult DeletarProduto(int id)
        {
            var produtoDeletado = produtos.Find(item => item.Id == id);

            if (produtoDeletado is null)
                return NotFound("Produto não encontrado");

            produtos.Remove(produtoDeletado);

            return NoContent();
        }
    }
}