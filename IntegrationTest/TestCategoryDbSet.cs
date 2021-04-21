using BasicBilling.API.Interface;
using BasicBilling.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntegrationTest
{
    public class TestCategoryDbSet : ICategoryRepository
    {
        private readonly TestBasicBillingDBContext _context;
        public TestCategoryDbSet(TestBasicBillingDBContext context)
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
