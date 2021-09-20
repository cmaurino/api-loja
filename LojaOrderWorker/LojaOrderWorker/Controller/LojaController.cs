using EstoqueAPI.Models;
using EstoqueAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaOrderWorker.Controllers
{
    public class LojaController : ControllerBase
    {
        private readonly EstoqueService _estoqueService;

        public LojaController(EstoqueService estoqueService)
        {
            _estoqueService = estoqueService;
        }
        public ActionResult<Produto> Get(string id)
        {
            var Produto = _estoqueService.Get(id);

            if (Produto == null)
            {
                return NotFound();
            }

            return Produto;
        }
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

    }
}
