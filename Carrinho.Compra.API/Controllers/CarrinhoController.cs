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
            var carrinho = await _service.Get(id);
            if (carrinho == null)
                return NotFound();

            return Ok(carrinho);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var carrinho = await _service.GetAll();
            return Ok(carrinho);
        }


        [HttpPost("Adicionar")]
        public async Task<IActionResult> Add(CarrinhoModel carrinhoModel)
        {
            var model = await _service.Add(carrinhoModel);

            return CreatedAtAction(nameof(Get), new { id = model.Id }, model);

        }


        [HttpPut("Atualizar")]
        public async Task<IActionResult> Update(CarrinhoModel carrinhoModel)
        {
            var model = await _service.Update(carrinhoModel);

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

        [HttpPost("Finalizar/{id}")]
        public async Task<IActionResult> FinalizarCompra(Guid id)
        {
          
            try
            {
                await _service.FinalizarCompra(id);

                return Ok(new
                {
                    mensagem = "Compra finalizada com sucesso."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = ex.Message
                });
            }

        }

    }
}
