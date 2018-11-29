using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mvc5App.Domain.Entities;

namespace Mvc5App.Domain.Repository
{
    public class OrderRepository : IOrderRepository
    {
        AppDbContext appDbContext;

        public OrderRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public Task<IEnumerable<Order>> Orders
        {
            get
            {
                return Task.FromResult<IEnumerable<Order>>(appDbContext.Orders.Include("Manager"));
            }
        }

        public Task<Order> GetOrder(int orderId)
        {
            return Task.FromResult<Order>(appDbContext.Orders.Include("Manager").First(o => o.OrderId == orderId));
        }

        public void SaveOrder(Order order)
        {
            if (order.OrderId == 0)
            {
                appDbContext.Orders.Add(order);
            }
            else
            {
                Order dbEntry = appDbContext.Orders.Find(order.OrderId);

                if (dbEntry != null)
                {
                    dbEntry.Number = order.Number;
                    dbEntry.Date = order.Date;
                    dbEntry.Shipping = order.Shipping;
                    dbEntry.Manager = order.Manager;
                    dbEntry.Annotation = order.Annotation;
                }
            }

            appDbContext.SaveChanges();
        }
    }
}
