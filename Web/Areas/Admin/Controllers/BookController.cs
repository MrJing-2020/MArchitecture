using MArc.IService;
using MArc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Common;

namespace Web.Areas.Admin.Controllers
{
    public class BookController : BaseController
    {
        private IServiceBase serviceBase;
        public BookController()
        {
            serviceBase = this.ServiceAccount;
        }
        public ActionResult Index()
        {
            var book = serviceBase.FindObject<Book>(m => m.Id == 1);
            return View(book);
        }
	}
}