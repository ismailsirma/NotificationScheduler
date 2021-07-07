using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NotificationDataLibrary.Data;
using NotificationDataLibrary.Enums;
using NotificationDataLibrary.Models;
using NotificationDataLibrary.Models.Companies;

namespace NotificationDataLibrary.Data
{
	public static class DbInitializer
	{
		public static void Initialize(NotifContext context)
		{
			context.Database.EnsureCreated();
			if (!((IQueryable<Company>)context.Companies).Any())
			{
				Company[] companies = new Company[1]
				{
				new DenmarkCompany
				{
					ID = Guid.Parse("aad7a630-af1c-4952-9cb4-44b8b847853b"),
					CompanyName = "Company Denmark1",
					CompanyNumber = "0123456789",
					CompanyType = CompanyType.small,
					Market = Market.Denmark
				}
				};
				Company[] array = companies;
				foreach (Company c in array)
				{
					context.Companies.Add(c);
				}
				context.SaveChanges();
			}
		}
	}

}
