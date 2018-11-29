using Mvc5App.Domain.Entities;
using Mvc5App.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc5App.WebUI.Infrastructure
{
    public class SeedData
    {
        static Random random = new Random();

        public static void Populate()
        {
            IList<Manager> managers = new List<Manager>() {
                new Manager(){ ManagerId=1, Name="Ivanov"},
                new Manager(){ ManagerId=2, Name="Petrov"},
                new Manager(){ ManagerId=3, Name="Sidorov"},
            };

            IList<Order> orders = new List<Order>();

            for (int i = 1; i <= 10; i++)
            {
                orders.Add(new Order() { OrderId = i, Number = i.ToString(), Date = GetDate(), ManagerId = random.Next(1, 4) });
            }

            using (AppDbContext appDbContext = new AppDbContext())
            {
                foreach (var item in managers)
                {
                    appDbContext.Managers.Add(item);
                }

                appDbContext.Orders.AddRange(orders);

                appDbContext.SaveChanges();
            }
        }

        private static DateTime GetDate()
        {
            DateTime start = new DateTime(2018, 1, 1);
            int range = (DateTime.Today - start).Days;

            return start.AddDays(random.Next(range));
        }

    }
}