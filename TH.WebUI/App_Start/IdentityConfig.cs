using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using TH.Model;
using TH.Repositories;

namespace TH.WebUI
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.

    public class THUserManager : UserManager<User>
    {
        public THUserManager(IUserStore<User> store)
            : base(store)
        {
        }

        public static THUserManager Create(IdentityFactoryOptions<THUserManager> options, IOwinContext context)
        {
            var manager = new THUserManager(new UserStore<User>(new THDbContext()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<User>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<User>(dataProtectionProvider.Create("ResetPassword")); // Create()必须传参"ResetPassword"，于ResetPasswordAsync里的实现VerifyUserTokenAsync(userId, "ResetPassword", token)一致。
            }
            return manager;
        }
    }

    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your sms service here to send a text message.
            return Task.FromResult(0);
        }
    }
}