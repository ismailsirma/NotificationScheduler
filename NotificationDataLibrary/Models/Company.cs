using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NotificationDataLibrary.Enums;
using NotificationDataLibrary.Models;

namespace NotificationDataLibrary.Models
{
	public abstract class Company
	{
		public int[] SentOnDays;

		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public Guid ID { get; set; }

		public string CompanyName { get; set; }

		[RegularExpression("^\\d{10}$")]
		[StringLength(10)]
		[Required]
		public string CompanyNumber { get; set; }

		public CompanyType CompanyType { get; set; }

		public Market Market { get; set; }

		public List<Notification> NotificationSchedule { get; set; }

		public Company()
		{
			NotificationSchedule = new List<Notification>();
		}

		public Company(string companyName, string companyNumber, CompanyType companyType, Market market)
		{
			CompanyName = companyName;
			CompanyNumber = companyNumber;
			CompanyType = companyType;
			Market = market;
		}

		public abstract List<Notification> addNotification();
	}
}
