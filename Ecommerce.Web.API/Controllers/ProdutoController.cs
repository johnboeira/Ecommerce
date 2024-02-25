﻿using Ecommerce.Domain;
using Ecommerce.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private EcommerceDbContext dbContext;

        public ProdutoController()
        {
            dbContext = new EcommerceDbContext();

            if (dbContext.Produtos.Count() == 0) {
                var produto = new Produto()
                {
                    Codigo = 1,
                    Nome = "Peso 5KG",
                    Preco = 50.0
                };

                dbContext.Produtos.Add(produto);

                dbContext.SaveChanges();
            }
        }

        [HttpGet]
        public List<Produto> GetProducts()
        {
            return dbContext.Produtos.ToList();
        }

        [HttpGet("{codigo}")]
        public IActionResult GetProduct(int codigo)
        {
            var produtoEncontrado = dbContext.Produtos.FirstOrDefault(produto => produto.Codigo == codigo);

            var produtoNaoFoiEncontrado = produtoEncontrado is null;

            if (produtoNaoFoiEncontrado)
                return NotFound();

            return Ok(produtoEncontrado);
        }

        [HttpPost]
        public void CreateProduct([FromBody] Produto produto)
        {
            dbContext.Produtos.Add(produto);

            dbContext.SaveChanges();
        }

        [HttpPut()]
        public IActionResult UpdateProduct([FromBody] Produto produtoAtualizado)
        {
            var produtoEncontrado = dbContext.Produtos.FirstOrDefault(produto => produto.Codigo == produtoAtualizado.Codigo);

            var produtoNaoFoiEncontrado = produtoEncontrado is null;

            if (produtoNaoFoiEncontrado)
                return NotFound();

            produtoEncontrado.Nome = produtoAtualizado.Nome;

            dbContext.SaveChanges();

            return Ok(dbContext.Produtos.ToList());
        }

        [HttpDelete()]
        public IActionResult DeleteProduct([FromBody] Produto produtoParaDeletar)
        {
            var produtoEncontrado = dbContext.Produtos.FirstOrDefault(produto => produto.Codigo == produtoParaDeletar.Codigo);

            var produtoNaoFoiEncontrado = produtoEncontrado is null;

            if (produtoNaoFoiEncontrado)
                return NotFound();

            dbContext.Produtos.Remove(produtoEncontrado);

            dbContext.SaveChanges();

            return Ok(dbContext.Produtos.ToList());
        }
    }
}
