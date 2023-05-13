using CVC_Project.Model;
using CVC_Project.Model.Home;

namespace CVC_Project.IService
{
    public interface IHomePage
    {
        List<SubcateDto> GetProductBySubcate(int cateId, int subcate);
        List<TypicalCategoriesDto> GetTypicalCategories();
        List<AllProductDto> GetAllProducts();
    }
}
