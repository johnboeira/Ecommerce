using Ecommerce.Domain.Shared;
using System;

namespace Ecommerce.Domain
{
    public class Produto : Entidade
    {
        public int Codigo { get; set; }
        public double Preco { get; set; }
        public string Nome { get; set; }
    }
}
