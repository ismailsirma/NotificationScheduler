using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotificationBusiness;
using NotificationDataLibrary.Data;
using NotificationDataLibrary.DTO;
using NotificationDataLibrary.Enums;
using NotificationDataLibrary.Models.Companies;
using System;

namespace TestNotificationScheduler
{
    [TestClass]
    public class CreateCompanyTest1
    {
        Scheduler scheduler;
        NotifContext context;

        DenmarkCompany denmark1;
        DenmarkCompany denmark2;

        [TestInitialize]
        public void setupInit()
        {
            DbContextOptions<NotifContext> options;
            var builder = new DbContextOptionsBuilder<NotifContext>();
            builder.UseSqlServer("Server=.;Database=NotificationScheduler;Trusted_Connection=True;MultipleActiveResultSets=true");

            context = new NotifContext(builder.Options);
            scheduler = new Scheduler(context);
        }

        [TestMethod]
        public void Denmark_Test_1()
        {
            denmark1 = new DenmarkCompany
            {
                ID = Guid.NewGuid(),
                CompanyName = "Company Denmark1",
                CompanyNumber = "0123456789",
                CompanyType = CompanyType.small,
                Market = Market.Denmark
            };

            NotificationResult result = scheduler.Create(denmark1);

            context.Remove(denmark1);
            context.SaveChanges();

            Assert.AreEqual(result.Notifications[0],DateTime.Now.Date.AddDays(1).ToString("dd/MM/yyyy"));
            

        }

        [TestMethod]
        public void Denmark_Test_2()
        {
            denmark2 = new DenmarkCompany
            {
                ID = Guid.NewGuid(),
                CompanyName = "Company Denmark2",
                CompanyNumber = "0123456790",
                CompanyType = CompanyType.medium,
                Market = Market.Denmark
            };

            NotificationResult result = scheduler.Create(denmark2);

            context.Remove(denmark2);
            context.SaveChanges();

            Assert.AreNotEqual(result.Notifications[1], DateTime.Now.Date.AddDays(4).ToString("dd/MM/yyyy"));
        }

        [TestMethod]
        public void Norway_Test_1()
        {
        }

        [TestMethod]
        public void Norway_Test_2()
        {
        }

        [TestMethod]
        public void Sweden_Test_1()
        {
        }

        [TestMethod]
        public void Sweden_Test_2()
        {
        }

        [TestMethod]
        public void Sweden_Test_3()
        {
        }

        [TestMethod]
        public void Finland_Test_1()
        {
        }

        [TestMethod]
        public void Finland_Test_2()
        {
        }

        [TestMethod]
        public void Finland_Test_3()
        {
        }

    }
}
