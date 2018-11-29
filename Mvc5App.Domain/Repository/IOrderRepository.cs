using Mvc5App.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mvc5App.Domain.Repository
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> Orders { get; }
        void SaveOrder(Order order);
        Task<Order> GetOrder(int orderId);
    }
}
