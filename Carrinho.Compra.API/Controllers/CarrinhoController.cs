using Carrinho.Compra.Domain.Interface.Service;
using Carrinho.Compra.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Carrinho.Compra.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarrinhoController : ControllerBase
    {
        private readonly ICarrinhoService _service;
        public CarrinhoController(ICarrinhoService service)
        {
            _service = service;
        }
       
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var cesta = await _service.Get(id);
            if (cesta == null)
                return NotFound();

            return Ok(cesta);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cesta = await _service.GetAll();
            return Ok(cesta);
        }


        [HttpPost]
        public async Task<IActionResult> Add(CarrinhoModel cestaModel)
        {
            var model = await _service.Add(cestaModel);

            return CreatedAtAction(nameof(Get),new { id = cestaModel.Id },cestaModel);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CarrinhoModel cestaModel){
            var model = await _service.Update(cestaModel);

            if (model == null)
                return NotFound();
            return Ok(model);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var removido = await _service.Delete(Id);

            if (!removido)
                return NotFound();

            return NoContent();
        }       
       
    }
}
