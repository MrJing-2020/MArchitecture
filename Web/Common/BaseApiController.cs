using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Common
{
    using MArc.Common;
    using MArc.IService;
    using MArc.Models;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Mvc;

    public class BaseApiController : ApiController
    {
        protected IServiceBase ServiceBase
        {
            get
            {
                return ServiceContext.Current.ServiceBase;
            }
        }
        protected IServiceAccount ServiceAccount
        {
            get
            {
                return ServiceContext.Current.ServiceAccount;
            }
        }
        protected IServiceIdentity ServiceIdentity
        {
            get
            {
                return ServiceContext.Current.ServiceIdentity;
            }
        }
        protected AppUser LoginUser
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

        protected HttpResponseMessage Response<T>(T data)
        {
            return Request.CreateResponse<T>(HttpStatusCode.OK, data);
        }
        protected HttpResponseMessage Response<T>(HttpStatusCode statusCode, T data)
        {
            return Request.CreateResponse<T>(statusCode, data);
        }
        protected HttpResponseMessage Response<T>(T data,Uri url)
        {
            var response = Request.CreateResponse<T>(HttpStatusCode.OK, data);
            response.Headers.Location = url;
            return response;
        }
    }
}