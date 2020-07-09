using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace erdus.ng.Repositories
{
    public class MailTemplateResolverRepository : IMailTemplateResolverRepository
    {
        public string GetStatusChangeTemplate()
        {
            return File.ReadAllText(@".\wwwroot\ChangeStatusMessageTemplate.txt");
        }
    }
}
