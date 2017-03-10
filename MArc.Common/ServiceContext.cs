using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MArc.Common
{
    using MArc.Cache;
    using MArc.IService;
    using MArc.ServiceProvider;
    public class ServiceContext
    {
        public static ServiceContext Current
        {
            get
            {
                return CacheHelper.Get<ServiceContext>("ServiceContext", () => new ServiceContext());
            }
        }

        public IServiceBase ServiceBase
        {
            get
            {
                return ServiceHelper.GetService<IServiceBase>();
            }
        }

        public IServiceAccount ServiceAccount
        {
            get
            {
                return ServiceHelper.GetService<IServiceAccount>();
            }
        }
    }
}
