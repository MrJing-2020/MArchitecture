using MArc.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Web.Common;

namespace Web.Areas.Admin.Controllers
{
    /// <summary>
    /// 用户管理
    /// </summary>
    public class UserManagerController : BaseApiController
    {
        [HttpGet]
        public List<AppUser> GetAllUsers()
        {
            var list = ServiceIdentity.FindUser().ToList();
            return list;
        }
        [HttpGet]
        public async Task<AppUser> GetUserDetail(string id)
        {
            var user = await ServiceIdentity.FindUserById(id);
            return user;
        }
        [HttpPost]
        public async Task<HttpResponseMessage> SubUserData(UserViewModel model)
        {
            if (string.IsNullOrEmpty(model.Id))
            {
                var user = new AppUser { UserName = model.Name, Email = model.Email };
                //传入Password并转换成PasswordHash
                bool result = await ServiceIdentity.CreateUser(user, model.Password);
                if (result == true)
                {
                    return Response(user, new Uri("GetAllUsers"));
                }
                else
                {
                    return Response(HttpStatusCode.InternalServerError, "服务器错误");
                }
            }
            else
            {
                AppUser user = await ServiceIdentity.FindUserById(model.Id);
                if (user != null)
                {
                    bool result = await ServiceIdentity.UpdateUser(user);
                    if (result == true)
                    {
                        user.PasswordHash = ServiceIdentity.GetHashPassword(model.Password);
                        user.Email = model.Email;
                        return Response(user, new Uri("GetAllUsers"));
                    }
                    else
                    {
                        return Response(HttpStatusCode.InternalServerError, "服务器错误");
                    }
                }
                else
                {
                    return Response(HttpStatusCode.InternalServerError, "服务器错误");
                }
            }
        }
    }
}