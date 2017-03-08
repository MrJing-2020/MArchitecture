using MArc.Cache;
using MArc.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MArc.ServiceProvider
{
    public static class ServiceHelper
    {
        public static T GetService<T>()
        {
            T service = Instance<T>.Create;
            return service;
        }
    }
}
