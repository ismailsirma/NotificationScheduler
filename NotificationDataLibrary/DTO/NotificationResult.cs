using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationDataLibrary.DTO
{
	public class NotificationResult
	{
		public Guid CompanyId { get; set; }

		public List<string> Notifications { get; set; }

		public NotificationResult(Guid companyId)
		{
			Notifications = new List<string>();
			CompanyId = companyId;
		}

		public void AddNotif(string notificationDate)
		{
			Notifications.Add(notificationDate);
		}
	}

}
