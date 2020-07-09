using erdus.ng.Data;
using erdus.ng.Models;
using erdus.ng.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace erdus.ng.Services
{
    public class SendMessageService : ISendMessageService
    {
        private readonly ISendMessageRepository _sendMail;
        private readonly IMailTemplateResolverRepository _mailTemplateResolverRepository;
        private readonly IRequestsService _requestsService;

        public SendMessageService(ISendMessageRepository sendMail, IMailTemplateResolverRepository mailTemplateResolverRepository, IRequestsService requestsService)
        {
            _sendMail = sendMail;
            _mailTemplateResolverRepository = mailTemplateResolverRepository;
            _requestsService = requestsService;
        }

        public void ChangeStatusMessage(int requestId)
        {
            var request = _requestsService.GetRequestById(requestId);

            var sender = "notificaton@erdus.com.pl";
            var recipient = request.Requester.Email;
            var content = string.Format(_mailTemplateResolverRepository.GetStatusChangeTemplate(), recipient, request.Topic, request.RequestStatus.Name, request.Answer);

            Task.Run(() =>
            {
                _sendMail.SendMessage(sender, new[] { recipient }, "Zmiana statusu Zgłoś usterkę w Twoim mieście", content);
            });
        }
    }
}
