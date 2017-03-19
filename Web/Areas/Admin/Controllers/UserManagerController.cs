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
        public HttpResponseMessage GetAllUsers()
        {
            var list = ServiceBase.FindBy<UserViewModel>("select Id, Email,PhoneNumber,UserName from AspNetUsers");
            if (list != null)
            {
                return Response(list);
            }
            else
            {
                return Response(HttpStatusCode.NotFound, "未找到任何信息");
            }
        }
        [HttpGet]
        public async Task<HttpResponseMessage> GetUserDetail(string id)
        {
            var AppUser = await ServiceIdentity.FindUserById(id);
            var user = Map<AppUser,UserViewModel>(AppUser);
            if (user != null)
            {
                return Response(user);
            }
            else
            {
                return Response(HttpStatusCode.NotFound, "未找到任何信息");
            }
        }
        [HttpPost]
        public async Task<HttpResponseMessage> SubUserData(UserViewModel model)
        {
            if (string.IsNullOrEmpty(model.Id))
            {
                var user = new AppUser { UserName = model.UserName, Email = model.Email };
                //传入Password并转换成PasswordHash
                bool result = await ServiceIdentity.CreateUser(user, model.Password);
                if (result == true)
                {
                    return Response(user, new Uri("/UserManager/GetAllUsers"));
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