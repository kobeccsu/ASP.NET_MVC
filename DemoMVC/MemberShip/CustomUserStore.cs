using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data.Entity;
using DemoMVC.LocalDbContext;

namespace DemoMVC.MemberShip
{
    public class CustomUserStore : IUserStore<CustomUser, string>, IUserLockoutStore<CustomUser, string>
        , IUserPasswordStore<CustomUser, string>, IUserTwoFactorStore<CustomUser, string>
    {
        DbContext _dbContext;
        public CustomUserStore(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task CreateAsync(CustomUser user)
        {
            return Task.Run(()=> {
                _dbContext.Set<Login_User>().Add(new Login_User() { Username = user.UserName, Password = user.PasswordHash });
                _dbContext.SaveChanges();
            });
        }

        public Task DeleteAsync(CustomUser user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<CustomUser> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<CustomUser> FindByNameAsync(string userName)
        {
            var user = _dbContext.Set<Login_User>().Where(m => m.Username == userName).FirstOrDefault();
            
            return Task.FromResult<CustomUser>(user != null ? new CustomUser() { UserName = user.Username } : null);
        }

        public Task<int> GetAccessFailedCountAsync(CustomUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetLockoutEnabledAsync(CustomUser user)
        {
            throw new NotImplementedException();
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(CustomUser user)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPasswordHashAsync(CustomUser user)
        {
            var u = _dbContext.Set<Login_User>().Where(m => m.Username == user.UserName).FirstOrDefault();
            return Task.FromResult<string>(u.Password);
        }

        public Task<bool> GetTwoFactorEnabledAsync(CustomUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(CustomUser user)
        {
            throw new NotImplementedException();
        }

        public Task<int> IncrementAccessFailedCountAsync(CustomUser user)
        {
            throw new NotImplementedException();
        }

        public Task ResetAccessFailedCountAsync(CustomUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEnabledAsync(CustomUser user, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEndDateAsync(CustomUser user, DateTimeOffset lockoutEnd)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(CustomUser user, string passwordHash)
        {
            user.PasswordHash = passwordHash;
            return Task.FromResult(0);
        }

        public Task SetTwoFactorEnabledAsync(CustomUser user, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CustomUser user)
        {
            throw new NotImplementedException();
        }
    }
}