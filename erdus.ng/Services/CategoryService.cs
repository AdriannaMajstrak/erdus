using erdus.ng.Data;
using erdus.ng.Repositories;
using System.Collections.Generic;

namespace erdus.ng.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IDatabaseRepository _databaseRepository;

        public CategoryService(IDatabaseRepository databaseRepository)
        {
            _databaseRepository = databaseRepository;
        }

        public Dictionary<int, string> GetAllCategories()
        {
            return _databaseRepository.GetAllCategories();
        }

        public Category GetCategoryById(int id)
        {
            return _databaseRepository.GetCategoryById(id);
        }
    }
}
