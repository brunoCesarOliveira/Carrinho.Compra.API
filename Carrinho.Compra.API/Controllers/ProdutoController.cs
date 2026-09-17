using Carrinho.Compra.Domain.Interface.Service;
using Carrinho.Compra.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Carrinho.Compra.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IService<ProdutoModel> _service;
        public ProdutoController(IService<ProdutoModel> service)
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

        [HttpGet("produtos")]
        public async Task<IActionResult> GetAll()
        {
            var produtos = await _service.GetAll();
            return Ok(produtos);
        }


        [HttpPost("Adicionar")]
        public async Task<IActionResult> Add(ProdutoModel produtoModel)
        {
            var model = await _service.Add(produtoModel);

            return CreatedAtAction(nameof(Get),new { id = produtoModel.Id },produtoModel);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProdutoModel produtoModel){
            var model = await _service.Update(produtoModel);

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
