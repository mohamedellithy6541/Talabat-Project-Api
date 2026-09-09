using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Entities;
using Talabat.Core.ISpecification;
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
            var spec = new ProductWithBrandAndTypeSpecification();
            return Ok(await _generaicRepository.GatAllWithSpecAsync(spec));
        }
        [HttpGet("products/{id:int}")]
        public async Task<ActionResult<Product>> GetBYId(int id)
        {
            var spec = new ProductWithBrandAndTypeSpecification(id);

            return Ok(await _generaicRepository.GetByIdWithSpec(spec));
        }
    }
}
