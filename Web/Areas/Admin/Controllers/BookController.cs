using MArc.IService;
using MArc.Models;
using MArc.ServiceProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Admin.Controllers
{
    public class BookController : Controller
    {
        private IServiceBase serviceBase;
        public BookController()
        {
            serviceBase = ServiceHelper.GetService<IServiceAccount>();
        }
        public ActionResult Index()
        {
            var book = serviceBase.FindObject<Book>(m => m.Id == 1);
            return View(book);
        }
	}
}