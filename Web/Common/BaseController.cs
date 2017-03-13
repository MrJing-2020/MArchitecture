using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Common
{
    using MArc.Common;
    using MArc.IService;
    using System.Web.Mvc;

    public class BaseController:Controller
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
    }
}