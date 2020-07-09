using erdus.ng.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;

namespace erdus.ng.Services
{
    public interface IRequestsService
    {
        void CreateNewRequest(string userId, string topic, string content, string location, string address, int categoryId, Stream fileStream);

        ICollection<Request> GetAllRequest();

        ICollection<Request> GetAllUserRequest(string userId);

        ICollection<Request> GetAllRequestIsResponsible(string responsiblePersonId);

        ICollection<Request> GetAllRequestWithoutResponsible();

        Request GetRequestById(int id);

        void UpdateRequest(int id, string content, string location, string address, int categoryId);

        void UpdateRequest(int id, string content, string location, string address, int categoryId, Stream fileStream);

        void UpdateRequest(int id, string responsiblePersonId, string topic, string content, string location, string address);

        void UpdateRequest(int id, string responsiblePersonId, string topic, string content, string location, string address, Stream fileStream);

        void UpdateRequest(int id, Guid responsiblePersonId);

        void UpdateRequest(int id, int status, string answer);

        void DeleteRequest(int id);

    }
}