using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueAPI.Models
{
    public class Produto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [Required(ErrorMessage = "O preenchimento do campo 'Nome' é obrigatório")]
        [BsonRequired]
        [MaxLength(100, ErrorMessage = "O campo 'Nome' não pode exceder 100 caracteres.")]
        [BsonElement("Nome")]
        public string Nome { get; set; }
        [MaxLength(300, ErrorMessage = "O campo 'Descrição' não pode exceder 300 caracteres.")]
        public string Descricao { get; set; }
        [MaxLength(30, ErrorMessage = "O campo 'Categoria' não pode exceder 30 caracteres.")]
        public string Categoria { get; set; }
        [BsonRequired]
        [Required(ErrorMessage = "O preenchimento do campo 'Valor' é obrigatório")]
        [Range(0.01, 1000000, ErrorMessage = "Insira um valor abaixo de 1.000.000")]
        public double Valor { get; set; }
        [BsonRequired]
        [Required(ErrorMessage = "O preenchimento do campo 'QtdDisponivel' é obrigatório")]
        [Range(0, 1000000, ErrorMessage = "Insira um valor abaixo de 1.000.000")]
        public int QtdDisponivel { get; set; }
    }
}
