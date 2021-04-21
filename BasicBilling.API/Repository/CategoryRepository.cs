using BasicBilling.API.Interface;
using BasicBilling.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicBilling.API.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BasicBillingDBContext _context;
        public CategoryRepository(BasicBillingDBContext context)
        {
            _context = context;
        }

        public Category GetCategory(int categoryId)
        {
            if (categoryId < 1)
            {
                return null;
            }
            return _context.Categories.Find(categoryId);
        }

        public Category GetCategoryByName(string categoryName)
        {
            return _context.Categories.Where(c => c.CategoryName == categoryName).FirstOrDefault();
        }
    }
}
