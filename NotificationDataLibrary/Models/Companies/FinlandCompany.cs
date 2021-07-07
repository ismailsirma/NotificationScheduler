using System;
using System.Collections.Generic;
using NotificationDataLibrary.Enums;
using NotificationDataLibrary.Models;

namespace NotificationDataLibrary.Models.Companies
{
	public class FinlandCompany : Company
	{
		public FinlandCompany()
		{
			Market = Market.Finland;
			SentOnDays = new int[5] { 1, 5, 10, 15, 20 };
		}

		public override List<Notification> addNotification()
		{
			if (CompanyType == CompanyType.large)
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
			}
			return NotificationSchedule;
		}
	}
}
