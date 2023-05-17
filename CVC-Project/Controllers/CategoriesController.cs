using CVC_Project.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CVC_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ShopDbContext _dbContext;

        public CategoriesController(ShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet("GetCategories")]
        public IActionResult GetCategories()
        {
            var categories = _dbContext.Categories
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                })
                .ToList();

            return Ok(categories);

        }
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var category = _dbContext.Categories.FirstOrDefault(s => s.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            var result = new
            {
                category.Id,
                category.Name,
            };

            return Ok(result);
        }
    }
}