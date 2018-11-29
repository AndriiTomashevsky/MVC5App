using Mvc5App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc5App.WebUI.Models
{
    public class OrdersViewModel
    {
        public IEnumerable<Order> Orders { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrrentManager { get; set; }
    }
}