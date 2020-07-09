using erdus.ng.Data;
using System.Collections.Generic;

namespace erdus.ng.Services
{
    public interface IStatusesService
    {
        Dictionary<int, string> GetAllStatuses();
        Status GetStatusById(int id);
    }


}