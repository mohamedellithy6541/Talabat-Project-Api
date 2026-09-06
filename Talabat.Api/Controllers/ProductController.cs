using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Entities;
using Talabat.Core.Repositories;

namespace Talabat.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IGeneraicRepository<Product> _generaicRepository;

        public ProductController(IGeneraicRepository<Product> generaicRepository)
        {
            _generaicRepository = generaicRepository;
        }
        [HttpGet("products")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _generaicRepository.GatAllAsync());
        }
        [HttpGet("products/{id:int}")]
        public async Task<ActionResult<Product>> GetBYId(int id)
        {
            return Ok(await _generaicRepository.GetById(id));
        }
    }
}
