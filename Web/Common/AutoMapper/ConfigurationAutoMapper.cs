using AutoMapper;
using MArc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Common
{
    /// <summary>
    /// AutoMapper配置类
    /// </summary>
    public class ConfigurationAutoMapper
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<AppUser, UserViewModel>();
            });

        }
    }
}