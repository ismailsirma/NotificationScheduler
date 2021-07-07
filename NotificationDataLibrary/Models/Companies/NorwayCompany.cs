using System;
using System.Collections.Generic;
using NotificationDataLibrary.Enums;
using NotificationDataLibrary.Models;

namespace NotificationDataLibrary.Models.Companies
{
	public class NorwayCompany : Company
	{
		public NorwayCompany()
		{
			Market = Market.Norway;
			SentOnDays = new int[4] { 1, 5, 10, 20 };
		}

		public override List<Notification> addNotification()
		{
			for (int i = 1; i <= SentOnDays.Length; i++)
			{
				Notification notif = new Notification
				{
					CompanyID = ID,
					//SendingDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + SentOnDays[i - 1])
					SendingDate = DateTime.Now.Date.AddDays(SentOnDays[i - 1])
				};
				NotificationSchedule.Add(notif);
			}
			return NotificationSchedule;
		}
	}
}
