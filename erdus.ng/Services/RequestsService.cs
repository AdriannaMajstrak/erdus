using erdus.ng.Data;
using erdus.ng.Helpers;
using erdus.ng.Models;
using erdus.ng.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace erdus.ng.Services
{
    public class RequestsService : IRequestsService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IFTPRepository _ftpRepository;
        private readonly IDatabaseRepository _databaseRepository;
        private readonly AppSettings _options;

        public RequestsService(UserManager<IdentityUser> userManager, IFTPRepository ftpRepository, IDatabaseRepository databaseRepository, IOptions<AppSettings> options)
        {
            _userManager = userManager;
            _ftpRepository = ftpRepository;
            _databaseRepository = databaseRepository;
            _options = options.Value;
        }

        public void CreateNewRequest(string userId, string topic, string content, string location, string address, int categoryId, Stream fileStream)
        {

            ////TODO:catch exepction
            var link = _ftpRepository.SaveFile(fileStream);

            var httpLink = link.Replace("ftp://localhost/", _options.ImagesPath, StringComparison.InvariantCultureIgnoreCase);


            Request request = new Request()
            {
                RequesterId = userId,
                Topic = topic,
                Content = content,
                Location = location,
                Address = address,
                Photo = httpLink,
                RequestCategoryId = categoryId
            };

            _databaseRepository.AddRequest(request);
            _databaseRepository.SaveChangesInDB();
        }

        public void UpdateRequest(int id, string responsiblePersonId, string topic, string content, string location, string address)
        {
            var responsiblePerson = _userManager.FindByIdAsync(responsiblePersonId).Result;

            ////TODO:catch exepction
            var request = GetRequestById(id);

            request.Topic = topic;
            request.Content = content;
            request.Location = location;
            request.Address = address;
            request.ResponsiblePerson = responsiblePerson;

            _databaseRepository.UpdateRequest(request);
            _databaseRepository.SaveChangesInDB();
        }

        public void UpdateRequest(int id, string responsiblePersonId, string topic, string content, string location, string address, Stream fileStream)
        {
            var responsiblePerson = _userManager.FindByIdAsync(responsiblePersonId).Result;

            ////TODO:catch exepction
            var request = GetRequestById(id);

            var link = _ftpRepository.SaveFile(fileStream);

            var httpLink = link.Replace("ftp://", "http://", StringComparison.InvariantCultureIgnoreCase);

            request.Topic = topic;
            request.Content = content;
            request.Location = location;
            request.Address = address;
            request.ResponsiblePerson = responsiblePerson;
            request.Photo = httpLink;


            _databaseRepository.UpdateRequest(request);
            _databaseRepository.SaveChangesInDB();
        }

        public ICollection<Request> GetAllRequest()
        {
            return _databaseRepository.GetAllRequests();
        }

        public ICollection<Request> GetAllUserRequest(string requesterId)
        {
            return GetAllRequest().Where(x => x.RequesterId == requesterId).ToList();
        }

        public ICollection<Request> GetAllRequestIsResponsible(string responsiblePersonId)
        {
            return GetAllRequest().Where(x => x.ResponsiblePersonId == responsiblePersonId).ToList();
        }

        public ICollection<Request> GetAllRequestWithoutResponsible()
        {
            return GetAllRequest().Where(x => x.ResponsiblePersonId == null).ToList();
        }
        public Request GetRequestById(int id)
        {
            return _databaseRepository.GetRequestById(id);
        }

        public void DeleteRequest(int id)
        {
            _databaseRepository.MoveToDeleted(id);
            _databaseRepository.SaveChangesInDB();
        }

        public void UpdateRequest(int id, Guid responsiblePersonId)
        {
            var responsiblePerson = _userManager.FindByIdAsync(responsiblePersonId.ToString()).Result;

            ////TODO:catch exepction
            var request = GetRequestById(id);

            request.ResponsiblePerson = responsiblePerson;

            _databaseRepository.UpdateRequest(request);
            _databaseRepository.SaveChangesInDB();
        }

        public void UpdateRequest(int id, string content, string location, string address, int categoryId)
        {           
            ////TODO:catch exepction
            var request = GetRequestById(id);
            
            request.Content = content;
            request.Location = location;
            request.Address = address;
            request.RequestCategoryId = categoryId;

            _databaseRepository.UpdateRequest(request);
            _databaseRepository.SaveChangesInDB();
        }

        public void UpdateRequest(int id, string content, string location, string address, int categoryId, Stream fileStream)
        {
            ////TODO:catch exepction
            var request = GetRequestById(id);

            var link = _ftpRepository.SaveFile(fileStream);

            var httpLink = link.Replace("ftp://localhost/", _options.ImagesPath, StringComparison.InvariantCultureIgnoreCase);

            request.Content = content;
            request.Location = location;
            request.Address = address;
            request.Photo = httpLink;
            request.RequestCategoryId = categoryId;

            _databaseRepository.UpdateRequest(request);
            _databaseRepository.SaveChangesInDB();
        }

        public void UpdateRequest(int id, int status, string answer)
        {
            ////TODO:catch exepction
            var request = GetRequestById(id);

            request.RequestStatusId = status;
            request.Answer = answer;

            _databaseRepository.UpdateRequest(request);
            _databaseRepository.SaveChangesInDB();
        }       
    }
}
