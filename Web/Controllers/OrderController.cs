using MArc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Web.Common;
using Web.Models;

namespace Web.Controllers
{
    [Authorize]
    public class OrderController : BaseApiController
    {
        public IEnumerable<Order> Get()
        {
            List<Order> list = new List<Order>();
            list.Add(new Order { orderID = 1, customerName = "Mr靖", shipperCity = "北京" });
            list.Add(new Order { orderID = 1, customerName = "周杰伦", shipperCity = "北京" });
            return list;
        }

        public AppUser GetUser(int id)
        {
            return LoginUser;
        }
    }
}
