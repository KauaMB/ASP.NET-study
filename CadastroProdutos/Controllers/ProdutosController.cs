using CadastroProdutos.Models;
using CadastroProdutos.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CadastroProdutos.Controllers
{
    [Authorize]
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
        public ActionResult<List<Produto>> BuscarTodos()
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

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult<Produto> AdicionarProduto(Produto novoProduto)
        {
            try{
            ProdutosServices.AdicionarProduto(novoProduto);
            return Created();
            }

            catch(Exception e) {
                return BadRequest(e.Message);
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public ActionResult AtualizarProduto(Produto produtoAtualizado, int id)
        {
            try {
            var produtoModificado = ProdutosServices.AtualizarProduto(id, produtoAtualizado);

            if (produtoModificado is null) return NotFound("O id especificado é inexistente");

            return Ok(produtoAtualizado);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public ActionResult DeletarProduto(int id)
        {
            var resultado = ProdutosServices.DeletarProduto(id);

            if (resultado is null) return NotFound("O id especificado é inexistente");

            return Ok(resultado);
        }
    }
}