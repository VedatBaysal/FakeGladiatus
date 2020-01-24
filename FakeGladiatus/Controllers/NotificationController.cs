using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using FakeGladiatus.Application.Entities;
using FakeGladiatus.Application.Services.Interfaaces;
using FakeGladiatus.Shared.Models.Notification;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FakeGladiatus.Controllers
{
    [Route("api/[controller]")]
    public class NotificationController : Controller
    {
        private readonly IMapper _mapper;
        private readonly INotificationService _notificationService;
        public NotificationController(INotificationService notificationService,IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }
        [HttpGet("notifications")]
        public IActionResult GetNotifications()
        {
            if (HttpContext.User.Identity is ClaimsIdentity claimsIdentity)
            {
                var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
                IEnumerable<Notification> n =_notificationService.GetNotification(Convert.ToInt32(userId));
                return Ok(_mapper.Map<IEnumerable<NotificationReadModel>>(n));
            }
            return BadRequest();
        }
    }
}
