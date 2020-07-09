using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erdus.ng.Models
{
    public class SmtpSettings
    {
        public string SmtpServer { get; set; }
        public string SmtpPort { get; set; }
        public string SmtpUser { get; set; }
        public string SmtpPassword { get; set; }
    }
}
