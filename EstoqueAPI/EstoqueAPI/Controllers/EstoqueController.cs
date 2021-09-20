using EstoqueAPI.Models;
using EstoqueAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly EstoqueService _estoqueService;

        public ProdutosController(EstoqueService estoqueService)
        {
            _estoqueService = estoqueService;
        }
        [HttpGet]
        public ActionResult<List<Produto>> Get() =>
            _estoqueService.Get();

        [HttpGet("{id:length(24)}", Name = "GetProduto")]
        public ActionResult<Produto> Get(string id)
        {
            var Produto = _estoqueService.Get(id);

            if (Produto == null)
            {
                return NotFound();
            }

            return Produto;
        }

        [HttpPost]
        public ActionResult<Produto> Create(Produto Produto)
        {
            _estoqueService.Create(Produto);

            return CreatedAtRoute("GetProduto", new { id = Produto.Id.ToString() }, Produto);
        }

        [HttpPost("{id:length(24)}")]
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Produto ProdutoIn)
        {
            var Produto = _estoqueService.Get(id);

            if (Produto == null)
            {
                return NotFound();
            }

            Produto.Id = null;

            _ = _estoqueService.UpdateAsync(id, ProdutoIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var Produto = _estoqueService.Get(id);

            if (Produto == null)
            {
                return NotFound();
            }

            _estoqueService.Remove(Produto.Id);

            return NoContent();
        }
    }
}
