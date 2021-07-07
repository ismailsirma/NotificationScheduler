using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NotificationBusiness;
using NotificationDataLibrary.Data;
using NotificationDataLibrary.DTO;
using NotificationDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationScheduler.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class NotificationSchedulerController : ControllerBase
    {
        private readonly NotifContext _context;

        private readonly ILogger<NotificationSchedulerController> _logger;

        private readonly Scheduler _scheduler;

        public NotificationSchedulerController(ILogger<NotificationSchedulerController> logger, NotifContext context, Scheduler scheduler) 
        {
            _logger = logger;
            _context = context;
            _scheduler = scheduler;
        }

        [HttpPost]
        public NotificationResult CreateSchedule(Company company)
        {
            return _scheduler.Create(company);
        }
    }
}
