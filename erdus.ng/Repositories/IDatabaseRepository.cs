using erdus.ng.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace erdus.ng.Repositories
{
    public interface IDatabaseRepository
    {
        void AddRequest(Request request);
        void SaveChangesInDB();
        ICollection<Request> GetAllRequests();
        Request GetRequestById(int id);
        void UpdateRequest(Request request);
        void MoveToDeleted(int id);
        Status GetStatusById(int id);
        Dictionary<int, string> GetAllStatuses();
        Dictionary<int, string> GetAllCategories();
        Category GetCategoryById(int id);
    }
}