using CVC_Project.Data;
using CVC_Project.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Globalization;
using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;

namespace CVC_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomePageController : ControllerBase
    {
        private readonly ShopDbContext _context;

        public HomePageController(ShopDbContext context)
        {
            _context = context;
        }


        [HttpGet("GetAllProduct")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            if (_context.Products == null)
            {
                return NotFound();
            }
            return await _context.Products!.ToListAsync();
        }


        [HttpGet("TypicalCategories")]
        public async Task<ActionResult<IEnumerable<TypicalCategories>>> GetTypicalCategories()
        {
            if (_context.TypicalCategories == null)
            {
                return NotFound();
            }

            return await _context.TypicalCategories!.ToListAsync();

        }

        [HttpGet("SearchByKeyword")]
        public async Task<ActionResult<IEnumerable<Product>>> SearchByKeyword(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return BadRequest("Keyword is required.");
            }

            var normalizedKeyword = RemoveVietnameseDiacritics(keyword.ToLowerInvariant());

            var allProducts = await _context.Products.ToListAsync();

            var relatedProducts = allProducts
                .Where(p =>
                    RemoveVietnameseDiacritics(p.Name.ToLower()).Contains(normalizedKeyword) ||
                    RemoveVietnameseDiacritics(p.Model.ToLower()).Contains(normalizedKeyword) ||
                    RemoveVietnameseDiacritics(p.Serial.ToLower()).Contains(normalizedKeyword)
                )
                .ToList();

            if (relatedProducts.Count == 0)
            {
                return NotFound("No products found.");
            }

            return relatedProducts;
        }

        
        private bool ProductExists(int id)
        {
            return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        //Xóa dấu Tiếng Việt
        private string RemoveVietnameseDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
