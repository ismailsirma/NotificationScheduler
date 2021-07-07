using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotificationDataLibrary.Models
{
	public class Notification
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }

		public Guid CompanyID { get; set; }

		public DateTime SendingDate { get; set; }
	}

}
