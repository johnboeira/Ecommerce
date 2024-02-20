using Ecommerce.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Ecommerce.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        List<Produto> produtos;

        public ProdutoController()
        {
            produtos = new List<Produto>() { };

            var produto = new Produto()
            {
                Codigo = 1,
                Nome = "Peso 5KG",
                Preco = 50.0
            };

            produtos.Add(produto);
        }

        [HttpGet]
        public List<Produto> GetProducts()
        {
            return produtos;
        }

        [HttpGet("{codigo}")]
        public IActionResult GetProduct(int codigo)
        {
            var produtoEncontrado = produtos.Find(produto => produto.Codigo == codigo);

            var produtoNaoFoiEncontrado = produtoEncontrado is null;

            if (produtoNaoFoiEncontrado)
                return NotFound();

            return Ok(produtoEncontrado);
        }

        [HttpPost]
        public void CreateProduct([FromBody] Produto produto)
        {
            produtos.Add(produto);
        }

        [HttpPut()]
        public IActionResult UpdateProduct([FromBody] Produto produtoAtualizado)
        {
            var produtoEncontrado = produtos.Find(produto => produto.Codigo == produtoAtualizado.Codigo);

            var produtoNaoFoiEncontrado = produtoEncontrado is null;

            if (produtoNaoFoiEncontrado)
                return NotFound();

            produtos.Remove(produtoEncontrado);
            produtos.Add(produtoAtualizado);

            return Ok(produtos);
        }

        [HttpDelete()]
        public IActionResult DeleteProduct([FromBody] Produto produtoParaDeletar)
        {
            var produtoEncontrado = produtos.Find(produto => produto.Codigo == produtoParaDeletar.Codigo);

            var produtoNaoFoiEncontrado = produtoEncontrado is null;

            if (produtoNaoFoiEncontrado)
                return NotFound();

            produtos.Remove(produtoEncontrado);

            return Ok(produtos);
        }
    }
}
