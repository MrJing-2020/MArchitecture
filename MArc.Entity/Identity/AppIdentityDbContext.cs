using MArc.Config;
using MArc.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace MArc.Entity
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        private static string connString = CachedConfigContext.Current.DaoConfig.MArc_Base;
        public AppIdentityDbContext()
            : base(connString)
        {
            //System.Data.Entity.Database.SetInitializer<AppIdentityDbContext>(new MigrateDatabaseToLatestVersion<AppIdentityDbContext, ConfigurationIdentity>());
            Database.SetInitializer<AppIdentityDbContext>(null);
        }
        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            //防止生产复数表名
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public static AppIdentityDbContext Create()
        {
            return new AppIdentityDbContext();
        }

        #region 映射的数据库表
        public DbSet<RefreshToken> RefreshToken { get; set; } 
        #endregion
    }
}
