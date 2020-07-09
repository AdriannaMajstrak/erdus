using erdus.ng.Data;
using erdus.ng.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erdus.ng.Services
{
    public class StatusesService : IStatusesService
    {
        private readonly IDatabaseRepository _databaseRepository;

        public StatusesService(IDatabaseRepository databaseRepository)
        {
            _databaseRepository = databaseRepository;
        }

        public Dictionary<int, string> GetAllStatuses()
        {
            return _databaseRepository.GetAllStatuses();
        }

        public Status GetStatusById(int id)
        {
            return _databaseRepository.GetStatusById(id);
        }
    }
}
