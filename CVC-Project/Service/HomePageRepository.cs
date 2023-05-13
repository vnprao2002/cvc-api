using CVC_Project.Data;
using CVC_Project.Exceptions;
using CVC_Project.IService;
using CVC_Project.Model.Home;
using System.Security.Cryptography;
using AutoMapper;

namespace CVC_Project.Service
{
    public class HomePageRepository : IHomePage
    {
        private readonly ShopDbContext _shopDbContext;
        private readonly IMapper _mapper;

        public HomePageRepository(ShopDbContext shopDbContext, IMapper mapper) 
        {
            _shopDbContext = shopDbContext;
            _mapper = mapper;
        }

        public List<AllProductDto> GetAllProducts()
        {
            var products = from p in _shopDbContext.Products
                           join pt in _shopDbContext.Images on p.Id equals pt.ProductId
                           orderby p.CreatedTime descending
                           select new { p, pt };
            var list = products.Select(x => new AllProductDto
            {
                ProductName = x.p.Name,
                Status = x.p.Status,
                Id = x.p.Id,
                Url = x.pt.Url
            });
            return list.ToList();
        }

        public List<SubcateDto> GetProductBySubcate(int cateId, int subcateId)
        {
            var products = from cate in _shopDbContext.Categories
                          join subcate in _shopDbContext.SubCategories on cate.Id equals subcate.CateId
                          join p in _shopDbContext.Products on subcate.Id equals p.SubCateId
                          join pt in _shopDbContext.Images on p.Id equals pt.ProductId
                          where cate.Id == cateId && subcate.Id == subcateId
                          select new { cate, subcate, p, pt };
            var list = products.Select(x => new SubcateDto
            {
                SubName= x.subcate.Name,
                ProductName= x.p.Name,
                Status = x.p.Status,
                Id  = x.p.Id,
                Url = x.pt.Url
            });
            return list.ToList();

        }

        public List<TypicalCategoriesDto> GetTypicalCategories()
        {
            var product = from cate in _shopDbContext.Categories
                          join subcate in _shopDbContext.SubCategories on cate.Id equals subcate.CateId
                          orderby subcate.View descending
                          select new { cate, subcate };

            var list = product.Select(x => new TypicalCategoriesDto
            {
                Id = x.subcate.Id,
                Name = x.subcate.Name,
                CateId = x.cate.Id,
                Image = x.subcate.Image
            }).Take(12);

            return list.ToList();
        }


    }
}
