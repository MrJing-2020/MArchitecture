using MArc.IService;
using MArc.Models;
using MArc.ServiceProvider;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private IServiceBase serviceBase;
        public UserController()
        {
            serviceBase = ServiceHelper.GetService<IServiceBase>();
        }
        //
        // GET: /Admin/User/
        public ActionResult Index()
        {
            //User user = serviceBase.FindObject<User>(m => m.Id == 1);
            SqlParameter parameter = new SqlParameter("@Id", 1);
            User user = serviceBase.FindAllByProc<User>("ProcTest",parameter).FirstOrDefault();

            return View(user);
        }
	}
}