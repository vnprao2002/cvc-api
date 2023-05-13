using CVC_Project.Data;
using CVC_Project.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
                .Where(p =>  p.SubCateId == subcateid)
                .ToList();

            return Ok(products);
        }
    }
}
