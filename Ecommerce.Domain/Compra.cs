using System;

namespace Ecommerce.Domain
{
    public class Compra
    {
        public Produto Produto { get; set; }
        public DateTime Data { get; set; }
        public Cliente Cliente { get; set; }

    }
}
