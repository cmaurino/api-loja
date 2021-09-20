using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaOrderWorker.Domain
{
    public sealed class Order
    {
        public int NumeroPedido { get; set; }
        public string IdProduto { get; set; }
        public int Quantidade { get; set; }
    }
}
