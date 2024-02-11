using Ecommerce.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace Ecommerce.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        List<Produto> produtos;
        public ProdutoController()
        {
            produtos = new List<Produto>();

            var novoProduto = new Produto()
            {
                Codigo = 1,
                Nome = "Peso 5KG",
                Preco = 50.0
            };

            var novoProduto2 = new Produto()
            {
                Codigo = 2,
                Nome = "Bola",
                Preco = 30.0
            };

            produtos.Add(novoProduto);
            produtos.Add(novoProduto2);
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
        public void CreateProduct([FromBody] string value)
        {
        }

        // PUT api/<ProdutoController>/5
        [HttpPut("{id}")]
        public void UpdateProduct(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProdutoController>/5
        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        {
        }
    }
}
