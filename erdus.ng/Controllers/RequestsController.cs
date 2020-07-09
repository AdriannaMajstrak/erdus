using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using erdus.ng.Services;
using erdus.ng.Models;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Security.Claims;
using erdus.ng.DTO;
using System.IO;
using System.Net;

namespace erdus.ng.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class RequestsController : GenericController
    {
        private readonly IRequestsService _requestsService;
        private readonly IUserService _userService;
        private readonly ILogger<RequestsController> _logger;
        private readonly IStatusesService _statusesService;
        private readonly ICategoryService _categoryService;
        private readonly ISendMessageService _sendMessageService;

        public RequestsController(IRequestsService requestsService, IUserService userService, ILogger<RequestsController> logger,
                                    IStatusesService statusesService, ICategoryService categoryService, ISendMessageService sendMessageService)
        {
            _requestsService = requestsService;
            _userService = userService;
            _logger = logger;
            _statusesService = statusesService;
            _categoryService = categoryService;
            _sendMessageService = sendMessageService;
        }

        [AllowAnonymous]
        [HttpGet()]
        public ObjectResult GetAllRequests()
        {

            try
            {
                var result = _requestsService.GetAllRequest().Select(x => new RequestDTO()
                {
                    Id = x.Id,
                    Address = x.Address,
                    CreationDate = x.CreationDate,
                    ResponsiblePerson = x.ResponsiblePerson == null ? "brak" : x.ResponsiblePerson.UserName,
                    Topic = x.Topic,
                    Status = x.RequestStatus.Name,
                    CategoryName = x.RequestCategory.Name,
                    CategoryId = x.RequestCategoryId
                }).ToList();

                return Ok(result.OrderByDescending(x => x.CreationDate));

            }
            catch (Exception e)
            {
                _logger.LogError($"Cannot get all requests. Details: {e}");
                return Problem("Nie można pobrać zgłoszeń", statusCode: 500);
            }
        }

        [HttpGet("my")]
        public ObjectResult GetAllUserRequests()
        {
            var currentUserId = User.Identity.Name;

            try
            {
                var result = _requestsService.GetAllUserRequest(currentUserId).Select(x => new RequestDTO()
                {
                    Id = x.Id,
                    Address = x.Address,
                    CreationDate = x.CreationDate,
                    ResponsiblePerson = x.ResponsiblePerson == null ? "brak" : x.ResponsiblePerson.UserName,
                    Topic = x.Topic,
                    Status = x.RequestStatus.Name,
                    CategoryName = x.RequestCategory.Name,
                    CategoryId = x.RequestCategoryId
                }).ToList();

                return Ok(result.OrderByDescending(x => x.CreationDate));

            }
            catch (Exception e)
            {
                _logger.LogError($"Cannot get user requests. Details: {e}");
                return Problem("Nie można pobrać zgłoszeń", statusCode: 500);
            }
        }

        [HttpGet("responsibility")]
        public ObjectResult GetAllResponsiblePersonRequests()
        {
            var currentUserId = User.Identity.Name;

            try
            {
                var result = _requestsService.GetAllRequestIsResponsible(currentUserId).Select(x => new RequestDTO()
                {
                    Id = x.Id,
                    Address = x.Address,
                    CreationDate = x.CreationDate,
                    ResponsiblePerson = x.ResponsiblePerson == null ? "brak" : x.ResponsiblePerson.UserName,
                    HasResponsiblePerson = x.ResponsiblePerson != null,
                    Topic = x.Topic,
                    Status = x.RequestStatus.Name,
                    CategoryName = x.RequestCategory.Name,
                    CategoryId = x.RequestCategoryId
                }).ToList();

                var newRequest = _requestsService.GetAllRequestWithoutResponsible().Select(x => new RequestDTO()
                {
                    Id = x.Id,
                    Address = x.Address,
                    CreationDate = x.CreationDate,
                    ResponsiblePerson = x.ResponsiblePerson == null ? "brak" : x.ResponsiblePerson.UserName,
                    Topic = x.Topic,
                    Status = x.RequestStatus.Name,
                    CategoryName = x.RequestCategory.Name,
                    CategoryId = x.RequestCategoryId
                }).ToList();

                result.AddRange(newRequest);

                return Ok(result.OrderByDescending(x => x.CreationDate));

            }
            catch (Exception e)
            {
                _logger.LogError($"Cannot get responsible person requests. Details: {e}");
                return Problem("Nie można pobrać zgłoszeń", statusCode: 500);
            }
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public ObjectResult GetRequestById(int id)
        {
            try
            {
                var result = _requestsService.GetRequestById(id);

                if (result == null)
                {
                    return NotFound($"Cannot find request with id = {id}");
                }

                Coordinate coordinate = null;

                if (result.Location != null)
                {
                    if (!Coordinate.TryParse(result.Location, out coordinate))
                    {
                        return Problem("Cannot parse cordinates");
                    }
                }

                var request = new RequestDetailsDTO()
                {
                    Id = result.Id,
                    Photo = result.Photo,
                    Requester = result.Requester.UserName,
                    ResponsiblePersonName = result.ResponsiblePerson == null ? "brak" : result.ResponsiblePerson.UserName,
                    Topic = result.Topic,
                    Location = result.Location,
                    Address = result.Address,
                    CreationDate = result.CreationDate,
                    Content = result.Content,
                    StatusName = result.RequestStatus.Name,
                    StatusId = result.RequestStatus.Id,
                    Longitude = coordinate?.LongitudeString,
                    Latitude = coordinate?.LatitudeString,
                    UserPermissions = _userService.GetPermissions(GetUserId(), GetUserRoles(), Guid.Parse(result.RequesterId)),
                    CategoryName = result.RequestCategory.Name,
                    CategoryId = result.RequestCategoryId,
                    Answer = result.Answer
                };

                if (result.ResponsiblePerson != null) request.ResponsiblePersonGuid = Guid.Parse(result.ResponsiblePerson.Id);

                return Ok(request);
            }
            catch (Exception e)
            {
                _logger.LogError($"Cannot get request by id where id is {id}. Details: {e}");
                return Problem("Nie można pobrać zgłoszenia");
            }
        }

        [HttpPost()]
        public ObjectResult Create([FromForm] CreateRequestDTO request)
        {
            try
            {
                int categoryId = Int32.Parse(request.CategoryId);

                if (Request.Form.Files == null || Request.Form.Files.Count == 0 || Request.Form.Files[0].Length == 0)
                {
                    return Problem("Zdjęcie jest wymagane", "", 500);
                }

                if (request.Location == null && request.Address == null)
                {
                    return Problem("Wymagane podanie lokalizacji GPS lub adresu", "", 500);
                }

                if (request.Location != null)
                {
                    Coordinate coordinate;

                    if (!Coordinate.TryParse(request.Location, out coordinate))
                    {
                        return Problem("Błedna lokalizacja GPS", "", 500);
                    }
                }

                if(_categoryService.GetCategoryById(categoryId) == null)
                {
                    return Problem("Błedna kategoria", "", 500);
                }

                using (Stream fs = Request.Form.Files[0].OpenReadStream())
                {
                    var currentUserId = User.Identity.Name;
                    _requestsService.CreateNewRequest(currentUserId, request.Topic, request.Content, request.Location, request.Address, categoryId, fs);
                }
                return Ok("Zgłoszenie zostało stworzone");
            }
            catch (Exception e)
            {
                _logger.LogError($"Cannot create new request. Details: {e}");
                return Problem("Nie można stworzyć nowego zgłoszenia");
            }
        }

        [HttpPut("{id}")]
        public ObjectResult Edit(int id, [FromForm] EditRequestDTO request)
        {
            try
            {
                int categoryId = Int32.Parse(request.CategoryId);

                if (id != request.Id)
                {
                    return Problem("Brak zgłoszenia o tym id", "", 404);
                }

                var originalRequestFromDB = _requestsService.GetRequestById((int)id);

                if (!_userService.GetPermissions(GetUserId(), GetUserRoles(), Guid.Parse(originalRequestFromDB.RequesterId)).CanEdit)
                {
                    return Problem("Zgłoszenie stworzne przez innego użytkownika", "", 401);
                }

                if (originalRequestFromDB.RequestStatus.Id != 1)
                {
                    return Problem("Brak możliwości edycji z powodu zmiany statusu", "", 500);
                }

                Coordinate coordinate = null;

                if (request.Location != null)
                {
                    if (!Coordinate.TryParse(request.Location, out coordinate))
                    {
                        return Problem("Błedna lokalizacja GPS", "", 500);
                    }
                }

                if (_categoryService.GetCategoryById(categoryId) == null)
                {
                    return Problem("Błedna kategoria", "", 500);
                }

                if (Request.Form.Files == null || Request.Form.Files.Count == 0 || Request.Form.Files[0].Length == 0)
                {

                    _requestsService.UpdateRequest(request.Id, request.Content, request.Location, request.Address, categoryId);

                    return Ok(new { messageMessage = "Update request" });

                }
                else
                {

                    using (Stream fs = Request.Form.Files[0].OpenReadStream())
                    {
                        _requestsService.UpdateRequest(request.Id, request.Content, request.Location, request.Address, categoryId, fs);
                    }
                    return Ok("Zapytanie zaktualizowane");

                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Cannot edit request. Details: {e}");
                return Problem("Nie można edytować zgłoszenia");
            }
        }

        [HttpDelete("{id}")]
        public ObjectResult Delete(int id)
        {
            try
            {
                if (_requestsService.GetRequestById(id) == null)
                {
                    return Problem("Brak zgłoszenia o tym id", "", 404);
                }

                if (!_userService.GetPermissions(GetUserId(), GetUserRoles()).CanDelete)
                {
                    return Problem("Tylko administrator moze usuwać zgłoszenia", "", 401);
                }

                _requestsService.DeleteRequest(id);

                return Ok("Zgłoszenie zostało usunięte");
            }
            catch (Exception e)
            {
                _logger.LogError($"Cannot delete request. Details: {e}");
                return Problem("Nie można usunąć zgłoszenia");
            }

        }

        [HttpPut("{id}/status")]
        public ObjectResult StatusEdit(int id, [FromBody] EditRequestStatusDTO editRequestStatus)
        {
            try
            {
                var originalRequestFromDb = _requestsService.GetRequestById(id);

                if (!_userService.GetPermissions(GetUserId(), GetUserRoles(), Guid.Parse(originalRequestFromDb.RequesterId)).CanChangeStatus)
                {
                    return Problem("Brak uprawnień do zmiany statusu", "", (int)HttpStatusCode.Unauthorized);
                }

                if (_statusesService.GetAllStatuses().ContainsKey(editRequestStatus.NewStatusId))
                {
                    _requestsService.UpdateRequest(id, editRequestStatus.NewStatusId, editRequestStatus.Answer);
                    _sendMessageService.ChangeStatusMessage(id);

                    return Ok("Status i komentarz zostały zmienione");
                }
                else
                {
                    return Problem("Nie ma takiego statusu w bazie", "", 404);
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Cannot edit status and answer. Details: {e}");
                return Problem("Nie można edytować statusu i komentarza");
            }
        }

        [HttpPut("{id}/responsibility")]
        public ObjectResult ResponsibilityEdit(int id, [FromBody] EditResponsibilityDTO editResponsibility)
        {
            try
            {
                var originalRequestFromDb = _requestsService.GetRequestById(id);

                if (!_userService.GetPermissions(GetUserId(), GetUserRoles(), Guid.Parse(originalRequestFromDb.RequesterId)).CanChangeResponsiblePerson)
                {
                    return Problem("Brak uprawnień do zmiany osoby odpowiedzialnej", "", (int)HttpStatusCode.Unauthorized);
                }

                if (_userService.PersonCanBeResponsible(editResponsibility.NewUserGuid))
                {
                    _requestsService.UpdateRequest(id, editResponsibility.NewUserGuid);

                    return Ok("Osoba odpowiedzialna została zmieniona");
                }
                else
                {
                    return Problem("Nie ma takiej osoby odpowiedzialnej", "", 404);
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Cannot edit responsibility. Details: {e}");
                return Problem("Nie można edytować osoby odpowiedzialnej");
            }
        }
    }
}