using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueAPI.Domain
{
    public sealed class Order
    {
        public int NumeroPedido { get; set; }
        [Required]
        public string IdProduto { get; set; }
        [Required]
        public int Quantidade { get; set; }
    }
}
