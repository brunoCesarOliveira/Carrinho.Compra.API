using Carrinho.Compra.Domain.Interface.Service;
using Carrinho.Compra.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Carrinho.Compra.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CupomController : ControllerBase
    {
        private readonly IService<CupomModel> _service;
        public CupomController(IService<CupomModel> service)
        {
            _service = service;
        }
       
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var produto = await _service.Get(id);
            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        [HttpGet("cupons")]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<CupomModel>? produtos = await _service.GetAll();
            return Ok(produtos);
        }
       
    }
}
