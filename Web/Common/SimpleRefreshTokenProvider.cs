using MArc.Entity;
using MArc.Models;
using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.Owin;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MArc.IService;
using MArc.Common;
using MArc.Utility;

namespace Web.Common
{
    public class SimpleRefreshTokenProvider : IAuthenticationTokenProvider
    {
        private IServiceIdentity serviceIdentity
        {
            get
            {
                return ServiceContext.Current.ServiceIdentity;
            }
        }
        public async Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            var refreshTokenId = Guid.NewGuid().ToString("n");
            using (AppUserManager manager = HttpContext.Current.GetOwinContext().GetUserManager<AppUserManager>())
            {
                var token = new RefreshToken()
                {
                    Id = refreshTokenId.GetHash(),
                    Subject = context.Ticket.Identity.Name,
                    IssuedUtc = DateTime.UtcNow,
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(30)
                };

                context.Ticket.Properties.IssuedUtc = token.IssuedUtc;
                context.Ticket.Properties.ExpiresUtc = token.ExpiresUtc;

                token.ProtectedTicket = context.SerializeTicket();

                var result = await serviceIdentity.AddRefreshToken(token);

                if (result)
                {
                    context.SetToken(refreshTokenId);
                }

            }
        }

        public async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            string hashedTokenId = context.Token.GetHash();
            var refreshToken = await serviceIdentity.FindRefreshToken(hashedTokenId);

            if (refreshToken != null)
            {
                //Get protectedTicket from refreshToken class
                context.DeserializeTicket(refreshToken.ProtectedTicket);
                var result = await serviceIdentity.RemoveRefreshToken(hashedTokenId);
            }
        }

        public void Create(AuthenticationTokenCreateContext context)
        {
            throw new NotImplementedException();
        }

        public void Receive(AuthenticationTokenReceiveContext context)
        {
            throw new NotImplementedException();
        }

    }
}