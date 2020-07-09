using System.Collections.Generic;
using erdus.ng.Data;

namespace erdus.ng.Services
{
    public interface ICategoryService
    {
        Dictionary<int, string> GetAllCategories();
        Category GetCategoryById(int id);
    }
}