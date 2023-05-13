using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CVC_Project.Data;
using System.Text;

namespace CVC_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ShopDbContext _context;

        public ProductsController(ShopDbContext context)
        {
            _context = context;
        }
        ///api/Products?subcateid={id}&sortBy=mostviewed 
        //api/Products?subcateid={id}&sortBy=newest
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(int subcateid, string sortBy)
        {
            IQueryable<Product> products = _context.Products.Where(p => p.SubCateId == subcateid);

            if (sortBy == "newest")
            {
                products = products.OrderByDescending(p => p.UpdatedTime);
            }
            else if (sortBy == "mostviewed")
            {
                products = products.OrderByDescending(p => p.View);
            }
            else
            {
                // Default sorting if the sortBy parameter is not provided or invalid
                products = products.OrderBy(p => p.Id);
            }

            return await products.ToListAsync();
        }

        /*        // GET: api/Products
                [HttpGet]
                public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
                {
                    if (_context.Products == null)
                    {
                        return NotFound();
                    }
                    return await _context.Products!.ToListAsync();
                }*/

        // GET: api/Products/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            if (_context.Products == null)
            {
                return NotFound();
            }
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/id          
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            var addproduct = new Product
            {
                Id = product.Id,
                Name = product.Name,
                ShortDesc = product.ShortDesc,
                Images = product.Images,
                CreatedTime = DateTime.Now,
                CreatedBy = product.CreatedBy,
                SubCateId = product.SubCateId,
                UpdatedTime = DateTime.Now,
                Status = product.Status,
                Colors = product.Colors,
                FullDesc = product.FullDesc,
                Others = product.Others,
                Brand = product.Brand,
                Origin = product.Origin,
                Model = product.Model,
                Serial = product.Serial,
                View = product.View,
                Certificates = product.Certificates,
            };
            _context.Products.Add(addproduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (_context.Products == null)
            {
                return NotFound();
            }
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/Products/FilterByNewest
        [HttpGet("FilterByNewest")]
        public async Task<ActionResult<IEnumerable<Product>>> FilterByNewest()
        {
            var products = await _context.Products.OrderByDescending(p => p.UpdatedTime).ToListAsync();
            return Ok(products);
        }

        // GET: api/Products/FilterByMostViewed
        [HttpGet("FilterByMostViewed")]
        public async Task<ActionResult<IEnumerable<Product>>> FilterByMostViewed()
        {
            var products = await _context.Products.OrderByDescending(p => p.View).ToListAsync();
            return Ok(products);
        }
        [HttpGet("IncreaseView")]
        public async Task<ActionResult> IncreaseView(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                return NotFound("Product not found.");
            }

            // Tăng số lượt view của sản phẩm lên 1
            StringBuilder sb = new StringBuilder(product.View);
            sb.Append("1");
            product.View = sb.ToString();

            // Lưu thay đổi vào cơ sở dữ liệu
            await _context.SaveChangesAsync();

            return Ok("View count increased successfully.");
        }
        [HttpGet("SimilarProducts/{subcateid}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetSimilarProducts(int subcateid)
        {
            // Lấy Subcate dựa vào subcateid
            var subcate = await _context.SubCategories.FindAsync(subcateid);
            if (subcate == null)
            {
                return NotFound();
            }

            // Lấy danh sách sản phẩm tương tự dựa vào Subcate ID và sắp xếp ngẫu nhiên
            var similarProducts = await _context.Products
                .Where(p => p.SubCateId == subcateid)
                .OrderBy(x => Guid.NewGuid())
                .ToListAsync();

            return Ok(similarProducts);
        }



        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }

    }

}
