using Shaghaf.Core.Entities;
using Shaghaf.Core.Specifications;
using System;
using System.Linq.Expressions;

namespace Shaghaf.Core.Specifications
{
    public class MenuItemByCategorySpec : BaseSpecifications<MenuItem>
    {
        public MenuItemByCategorySpec(string category)
            : base(m => m.Category.ToLower() == category.ToLower())
        {
            AddOrderBy(m => m.Name); // Order by Name 
        }
    }
}
