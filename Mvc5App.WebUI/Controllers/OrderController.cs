using Mvc5App.Domain.Entities;
using Mvc5App.Domain.Repository;
using Mvc5App.WebUI.Infrastructure;
using Mvc5App.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Mvc5App.WebUI.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        IOrderRepository orderRepository;
        IManagerRepository managerRepository;
        public int pageSize = 4;

        public OrderController(IOrderRepository orderRepository, IManagerRepository managerRepository)
        {
            this.orderRepository = orderRepository;
            this.managerRepository = managerRepository;
        }

        // GET: Order
        public async Task<ActionResult> Index(string manager, int page = 1)
        {
            OrdersViewModel ordersViewModel = new OrdersViewModel()
            {
                Orders = (await orderRepository.Orders)
                .Where(o => String.IsNullOrEmpty(manager) || o.Manager.Name == manager)
                .OrderBy(o => o.OrderId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = String.IsNullOrEmpty(manager) ? (await orderRepository.Orders).Count()
                    : (await orderRepository.Orders).Where(o => o.Manager.Name == manager).Count()
                },
                CurrrentManager = String.IsNullOrEmpty(manager) ? null : manager
            };

            return View(ordersViewModel);
        }

        [ChildActionOnly]
        public async Task<PartialViewResult> Modal(int orderId, string modalId)
        {
            ViewBag.Managers = managerRepository.Managers;
            ViewBag.ModalId = modalId;

            return PartialView(orderId == 0 ? new Order() : await orderRepository.GetOrder(orderId));
        }

        [HttpPost]
        public ActionResult UpdateOrder(Order order)
        {
            orderRepository.SaveOrder(order);
            TempData.Add("Message", $"Order №{order.Number} has been saved");

            return RedirectToAction(nameof(Index));
        }

        public ActionResult SeedDatabase()
        {
            SeedData.Populate();

            return RedirectToAction(nameof(Index));
        }
    }
}