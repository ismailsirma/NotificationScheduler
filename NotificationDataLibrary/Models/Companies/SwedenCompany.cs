using System;
using System.Collections.Generic;
using NotificationDataLibrary.Enums;
using NotificationDataLibrary.Models;

namespace NotificationDataLibrary.Models.Companies
{
	public class SwedenCompany : Company
	{
		public SwedenCompany()
		{
			Market = Market.Sweden;
			SentOnDays = new int[4] { 1, 7, 14, 28 };
		}

		public override List<Notification> addNotification()
		{
			if (CompanyType == CompanyType.large)
			{
				return NotificationSchedule;
			}
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
