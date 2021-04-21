using BasicBilling.API.Models;

namespace BasicBilling.API.Interface
{
    public interface ICategoryRepository
    {
        Category GetCategoryByName(string categoryName);
        Category GetCategory(int categoryId);
    }
}
