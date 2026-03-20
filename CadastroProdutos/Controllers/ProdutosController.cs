using CadastroProdutos.Models;
using CadastroProdutos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CadastroProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private IProdutosServices ProdutosServices;

        public ProdutosController(IProdutosServices produtosServices)
        {
            ProdutosServices = produtosServices;
        }

        [HttpGet]
        public ActionResult<List<Produto>> Get()
        {
            return Ok(ProdutosServices.BuscarTodos());
        }



        [HttpGet("{id}")]
        public ActionResult<List<Produto>> BuscarPorId(int id)
        {
            var resultado = ProdutosServices.BuscarPorId(id);

            if (resultado == null) return NotFound("O item no id especificado não existe");

            return Ok(resultado);
        }

        [HttpPost]
        public ActionResult<Produto> AdicionarProduto(Produto novoProduto)
        {
            ProdutosServices.AdicionarProduto(novoProduto);
            return Created();
        }

        [HttpPut("{id}")]
        public ActionResult AtualizarProduto(Produto produtoAtualizado, int id)
        {
            var produtoModificado = ProdutosServices.AtualizarProduto(id, produtoAtualizado);

            if (produtoModificado is null) return NotFound("O id especificado é inexistente");

            return Ok(produtoAtualizado);
        }

        [HttpDelete("{id}")]
        public ActionResult DeletarProduto(int id)
        {
            var resultado = ProdutosServices.DeletarProduto(id);

            if (resultado is null) return NotFound("O id especificado é inexistente");

            return Ok(resultado);
        }
    }
}