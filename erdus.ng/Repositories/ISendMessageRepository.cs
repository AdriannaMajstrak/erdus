using erdus.ng.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erdus.ng.Repositories
{
    public interface ISendMessageRepository
    {
        void SendMessage(string sender, string[] recipents, string topic, string content);
    }
}
