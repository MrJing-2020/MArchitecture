﻿using MArc.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using MArc.Models;
using System.Linq.Expressions;
using Microsoft.AspNet.Identity;

namespace MArc.Repository
{
    public class RepositoryIdentity
    {
        private AppUserManager UserManager
        {
            get { return HttpContext.Current.GetOwinContext().GetUserManager<AppUserManager>(); }
        }
        private AppRoleManager RoleManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().GetUserManager<AppRoleManager>();
            }
        }
        #region AppUser增删查改

        #region AppUser查询
        public IQueryable<AppUser> FindUser()
        {
            return UserManager.Users;
        }
        public IQueryable<AppUser> FindUser(Expression<Func<AppUser, bool>> conditions = null)
        {
            return UserManager.Users.Where(conditions);
        }
        public async Task<AppUser> FindByNameAndPas(string userName, string password)
        {
            return await UserManager.FindAsync(userName, userName);
        }
        public async Task<AppUser> FindUserById(string userId)
        {
            return await UserManager.FindByIdAsync(userId);
        }
        public async Task<AppUser> FindUserByEmail(string email)
        {
            return await UserManager.FindByEmailAsync(email);
        }
        public async Task<AppUser> FindUserByName(string userName)
        {
            return await UserManager.FindByNameAsync(userName);
        }
        #endregion

        public async Task<bool> CreateUser(AppUser user, string password)
        {
            IdentityResult result = await UserManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> CreateUser(AppUser user)
        {
            IdentityResult result = await UserManager.CreateAsync(user);
            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateUser(AppUser user)
        {
            IdentityResult result = await UserManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteUser(AppUser user)
        {
            IdentityResult result = await UserManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }  
        #endregion

        #region AppRole增删查改

        #region AppRole查询
        public IQueryable<AppRole> FindRole()
        {
            return RoleManager.Roles;
        }
        public IQueryable<AppRole> FindRole(Expression<Func<AppRole, bool>> conditions = null)
        {
            return RoleManager.Roles.Where(conditions);
        }
        public async Task<AppRole> FindRoleById(string roleId)
        {
            return await RoleManager.FindByIdAsync(roleId);
        }
        public async Task<AppRole> FindRoleByName(string roleName)
        {
            return await RoleManager.FindByNameAsync(roleName);
        }
        public async Task<bool> RoleExists(string roleName)
        {
            return await RoleManager.RoleExistsAsync(roleName);
        }
        #endregion

        public async Task<bool> CreateRole(AppRole role)
        {
            IdentityResult result = await RoleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateRole(AppRole role)
        {
            IdentityResult result = await RoleManager.UpdateAsync(role);
            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteRole(AppRole role)
        {
            IdentityResult result = await RoleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        public async Task<IQueryable<AppUser>> FindUserInToRole(string roleId)
        {
            AppRole role = await RoleManager.FindByIdAsync(roleId);
            string[] memberIDs = role.Users.Select(x => x.UserId).ToArray();
            return UserManager.Users.Where(x => memberIDs.Any(y => y == x.Id));
        }

        public async Task<IQueryable<AppUser>> FindUserNotInToRole(string roleId)
        {
            AppRole role = await RoleManager.FindByIdAsync(roleId);
            string[] memberIDs = role.Users.Select(x => x.UserId).ToArray();
            IQueryable<AppUser> members = UserManager.Users.Where(x => memberIDs.Any(y => y == x.Id));
            IQueryable<AppUser> nonMembers = UserManager.Users.Except(members);
            return nonMembers;
        }
    }
}