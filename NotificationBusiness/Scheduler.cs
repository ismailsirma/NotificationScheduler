using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NotificationDataLibrary.Data;
using NotificationDataLibrary.DTO;
using NotificationDataLibrary.Models;

namespace NotificationBusiness
{
	public class Scheduler
	{
		private readonly NotifContext _context;

		public Scheduler(NotifContext context)
		{
			_context = context;
		}

		public NotificationResult Create(Company company)
		{
			Company comp = _context.Companies.Find(new object[1] { company.ID });
			if (comp != null)
			{
				NotificationResult notifs = new NotificationResult(company.ID);
				company.NotificationSchedule = ((IQueryable<Notification>)_context.Notifications).Where((Notification a) => a.CompanyID == company.ID).ToList();
				foreach (Notification item2 in company.NotificationSchedule)
				{
					notifs.AddNotif(item2.SendingDate.ToString("dd/MM/yyyy"));
				}
				return notifs;
			}
			_context.Companies.Add(company);
			_context.SaveChanges();
			List<Notification> listOfNotifications = company.addNotification();
			NotificationResult result = new NotificationResult(company.ID);
			if (listOfNotifications != null)
			{
				foreach (Notification item in listOfNotifications)
				{
					_context.Notifications.Add(item);
					result.AddNotif(item.SendingDate.ToString("dd/MM/yyyy"));
				}
				_context.SaveChanges();
			}
			return result;
		}
	}
}
