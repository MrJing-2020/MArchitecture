using MArc.Entity;
using MArc.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MArc.Repository
{
    public class RepositoryAccount : RepositoryBase, IRepositoryAccount
    {
        private static AccountDBContext context = new AccountDBContext();
        public RepositoryAccount()
            : base(context)
        { 
        }
    }
}
