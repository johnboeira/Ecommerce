using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain
{
    public class Cliente: Usuario
    {
        public List<Compra> Compras { get; set; }
        public Carrinho Carrinho { get; set; }
    }
}
