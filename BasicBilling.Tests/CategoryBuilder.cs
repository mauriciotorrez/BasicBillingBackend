using BasicBilling.API.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicBilling.Tests
{
    public class CategoryBuilder
    {
        private readonly Category _categoryEntity;
        public CategoryBuilder()
        {
            _categoryEntity = new Category
            {
                CategoryId = 1,
                CategoryName = "WATER"
            };
        }

        public CategoryBuilder WithId(int catId)
        {
            _categoryEntity.CategoryId = catId;
            return this;
        }

        public CategoryBuilder Withname(string catName)
        {
            _categoryEntity.CategoryName = catName;
            return this;
        }

        public Category Build()
        {
            _categoryEntity.CategoryId = 1;
            return _categoryEntity;
        }
    }
}
