using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Common
{
    using MArc.Common;
    using MArc.IService;
    using MArc.Models;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Mvc;

    public class BaseApiController : ApiController
    {
        public IServiceBase ServiceBase
        {
            get
            {
                return ServiceContext.Current.ServiceBase;
            }
        }
        public IServiceAccount ServiceAccount
        {
            get
            {
                return ServiceContext.Current.ServiceAccount;
            }
        }
        public IServiceIdentity ServiceIdentity
        {
            get
            {
                return ServiceContext.Current.ServiceIdentity;
            }
        }
        public AppUser LoginUser
        {
            get
            {
                string userName = User.Identity.Name;
                AppUser user = null;
                //开启新线程执行async方法，防止线程锁死(使用async await可不必如此，这里想让它以同步方式执行)
                Task.Run<AppUser>(() => ServiceIdentity.FindLoginUserByName(User.Identity.Name))
                .ContinueWith(m => { m.Wait(); user = m.Result; })
                .Wait();
                return user;
            }
        }
    }
}