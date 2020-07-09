using erdus.ng.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erdus.ng.Services
{
    public interface ISendMessageService
    {
        void ChangeStatusMessage(int requestId);
    }
}
