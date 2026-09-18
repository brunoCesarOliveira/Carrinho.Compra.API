using Carrinho.Compra.Domain.Interface.Service;
using Carrinho.Compra.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Carrinho.Compra.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemCarrinhoController : ControllerBase
    {
        private readonly IService<ItemCarrinhoModel> _service;
        public ItemCarrinhoController(IService<ItemCarrinhoModel> service)
        {
            _service = service;
        }
     

        [HttpDelete("Item/{id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var removido = await _service.Delete(Id);

            if (!removido)
                return NotFound();

            return NoContent();
        }

    }
}
