using MArc.IRepository;
using MArc.IService;
using MArc.ServiceProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MArc.Service
{
    public class ServiceAccount : ServiceBase, IServiceAccount
    {
        private static IRepositoryAccount repositoryAccount = ServiceHelper.GetService<IRepositoryAccount>();
        public ServiceAccount()
            : base(repositoryAccount)
        {
        }
    }
}
