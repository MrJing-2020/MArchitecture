using MArc.IService;
using MArc.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Common;

namespace Web.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        //
        // GET: /Admin/User/
        public ActionResult Index()
        {
            //User user = serviceBase.FindObject<User>(m => m.Id == 1);
            //SqlParameter parameter = new SqlParameter("@Id", 1);
            //User user = ServiceBase.FindAllByProc<User>("ProcTest", parameter).FirstOrDefault();
            AppUser user = ServiceIdentity.FindUser().FirstOrDefault();

            return View(user);
        }
	}
}