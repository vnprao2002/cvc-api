using CVC_Project.Data;
using CVC_Project.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

using System.Linq;


namespace CVC_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubcateController : ControllerBase
    {
        private readonly ShopDbContext _dbContext;

        public SubcateController(ShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetProductsBySubCateID(int subcateid)
        {
            var products = _dbContext.Products
                .Where(p => p.SubCateId == subcateid)
                .ToList();

            return Ok(products);
        }

        [HttpGet("GetSubcate")]
        public IActionResult GetSubCategories()
        {
            var subCategories = _dbContext.SubCategories
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    s.CateId
                })
                .ToList();

            return Ok(subCategories);
        }
        [HttpGet("{id}")]
        public IActionResult GetSubCategory(int id)
        {
            var subCategory = _dbContext.SubCategories.FirstOrDefault(s => s.Id == id);

            if (subCategory == null)
            {
                return NotFound();
            }

            var result = new
            {
                subCategory.Id,
                subCategory.Name,
                subCategory.CateId
            };

            return Ok(result);
        }
    }
}
