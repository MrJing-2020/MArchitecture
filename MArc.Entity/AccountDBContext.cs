using MArc.Config;
using MArc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MArc.Entity
{
    public class AccountDBContext : DbContextBase
    {
        private static string connString = CachedConfigContext.Current.DaoConfig.MArc_Account;
        public AccountDBContext() 
            :base(connString)
        {
        }

        public DbSet<Book> book { get; set; } 
    }
}
