using erdus.ng.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace erdus.ng.Repositories
{
    public class DatabaseRepository : IDatabaseRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public DatabaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddRequest(Request request)
        {
            _dbContext.Requests.Add(request);
        }


        public void SaveChangesInDB()
        {
            _dbContext.SaveChanges();
        }

        public ICollection<Request> GetAllRequests()
        {
            return _dbContext.Requests
                .Include(x => x.Requester)
                .Include(x => x.ResponsiblePerson)
                .Include(x => x.RequestStatus)
                .Include(x => x.RequestCategory).ToList();
        }

        public Request GetRequestById(int id)
        {
            var result = _dbContext
                 .Requests
                 .Include(x => x.Requester)
                 .Include(x => x.ResponsiblePerson)
                 .Include(x => x.RequestStatus)
                 .Include(x => x.RequestCategory)
                 .FirstOrDefault(x => x.Id == id);

            return result;
        }

        public void UpdateRequest(Request request)
        {
            _dbContext.Update(request);
        }

        public void MoveToDeleted(int id)
        {
            var request = _dbContext.Requests.FirstOrDefault(x => x.Id == id);
            _dbContext.RequestsDeleted.Add(new RequestDeleted()
            {
                Address = request.Address,
                Content = request.Content,
                CreationDate = request.CreationDate,
                Id = request.Id,
                Location = request.Location,
                Photo = request.Photo,
                Requester = request.Requester,
                RequesterId = request.RequesterId,
                RequestStatus = request.RequestStatus,
                RequestStatusId = request.RequestStatusId,
                ResponsiblePerson = request.ResponsiblePerson,
                ResponsiblePersonId = request.ResponsiblePersonId,
                Topic = request.Topic,
                RequestCategory = request.RequestCategory,
                RequestCategoryId = request.RequestCategoryId,
                Answer = request.Answer
            });
            _dbContext.Requests.Remove(request);
        }

        public Dictionary<int, string> GetAllStatuses()
        {
            return _dbContext.Statuses.ToDictionary(x => x.Id, x => x.Name);
        }

        public Status GetStatusById(int id)
        {
            return _dbContext.Statuses.FirstOrDefault(x => x.Id == id);
        }

        public Dictionary<int, string> GetAllCategories()
        {
            return _dbContext.Categories.ToDictionary(x => x.Id, x => x.Name);
        }

        public Category GetCategoryById(int id)
        {
            return _dbContext.Categories.FirstOrDefault(x => x.Id == id);
        }

    }
}
