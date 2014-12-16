using Microsoft.AspNet.Identity.Dapper.Contracts;
using Microsoft.AspNet.Identity.Dapper.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace Microsoft.AspNet.Identity.Dapper
{

    public class UserStore<TUser> : UserStore<TUser, int>
        where TUser : class, IIdentityUser<int, IdentityUserLogin<int>, IdentityUserRole<int>, IdentityUserClaim<int>>
    {
        public UserStore(string connectionString)
            : base(connectionString)
        {

        }
    }

    public class UserStore<TUser, TKey> : UserStore<TUser, IdentityRole<TKey, IdentityUserRole<TKey>>, TKey, IdentityUserLogin<TKey>, IdentityUserRole<TKey>, IdentityUserClaim<TKey>>
        where TUser : class, IIdentityUser<TKey, IdentityUserLogin<TKey>, IdentityUserRole<TKey>, IdentityUserClaim<TKey>>
        where TKey : System.IEquatable<TKey>
    {
        public UserStore(string connectionString) : base(connectionString)
        {

        }
    }

    public class UserStore<TUser, TRole, TUserKey, TUserLogin, TUserRole, TUserClaim> :
        IUserLoginStore<TUser, TUserKey>,
        IUserClaimStore<TUser, TUserKey>,
        IUserRoleStore<TUser, TUserKey>,
        IUserPasswordStore<TUser, TUserKey>,
        IUserSecurityStampStore<TUser, TUserKey>,
        IQueryableUserStore<TUser, TUserKey>,
        IUserEmailStore<TUser, TUserKey>,
        IUserPhoneNumberStore<TUser, TUserKey>,
        IUserTwoFactorStore<TUser, TUserKey>,
        IUserLockoutStore<TUser, TUserKey>,
        IUserStore<TUser, TUserKey>,
        IDisposable
        where TUser : class, IIdentityUser<TUserKey, TUserLogin, TUserRole, TUserClaim>
        where TRole : class,IIdentityRole<TUserKey, TUserRole>
        where TUserKey : System.IEquatable<TUserKey>
        where TUserLogin : IIdentityUserLogin<TUserKey>, new()
        where TUserRole : IIdentityUserRole<TUserKey>, new()
        where TUserClaim : IIdentityUserClaim<TUserKey>, new()
    {
        public string ConnectionString { get; private set; }

        public UserStore(string connectionString)
        {
            ConnectionString = connectionString;
        }

        private SqlConnection connection;

        public SqlConnection Connection
        {
            get { return connection ?? (connection = new SqlConnection(ConnectionString)); }
            set { connection = value; }
        }


        public Task AddLoginAsync(TUser user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task<TUser> FindAsync(UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public Task RemoveLoginAsync(TUser user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public Task<TUser> FindByIdAsync(TUserKey userId)
        {
            return findAsync(new IdentityUserQuery<TUserKey> { UserId = userId });
        }

        public Task<TUser> FindByNameAsync(string userName)
        {
            return findAsync(new IdentityUserQuery<TUserKey> { UserName = userName });
        }

        public Task UpdateAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task AddClaimAsync(TUser user, System.Security.Claims.Claim claim)
        {
            throw new NotImplementedException();
        }

        public Task<IList<System.Security.Claims.Claim>> GetClaimsAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public Task RemoveClaimAsync(TUser user, System.Security.Claims.Claim claim)
        {
            throw new NotImplementedException();
        }

        public Task AddToRoleAsync(TUser user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<IList<string>> GetRolesAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(TUser user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromRoleAsync(TUser user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPasswordHashAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(TUser user, string passwordHash)
        {
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            user.PasswordHash = passwordHash;
            return Task.FromResult(0);
        }

        public Task<string> GetSecurityStampAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetSecurityStampAsync(TUser user, string stamp)
        {
            ThrowIfDisposed();
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            user.SecurityStamp = stamp;
            return Task.FromResult(0);
        }

        public IQueryable<TUser> Users
        {
            get { throw new NotImplementedException(); }
        }

        private Task<TUser> findAsync(IdentityUserQuery<TUserKey> query)
        {
            TUser user;
            using(Connection)
            {
                using (var result = Connection.QueryMultiple("GetUser", query, commandType: CommandType.StoredProcedure))
                {
                    user = result.Read<TUser>().FirstOrDefault();
                    if (user != null)
                    {
                        user.Roles = result.Read<TUserRole>().ToList();
                        user.Logins = result.Read<TUserLogin>().ToList();
                        user.Claims = result.Read<TUserClaim>().ToList();
                    }
                }
            }
            return Task.FromResult(user);
        }

        public Task<TUser> FindByEmailAsync(string email)
        {
            return findAsync(new IdentityUserQuery<TUserKey> { Email = email });
        }

        public Task<string> GetEmailAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetEmailConfirmedAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailAsync(TUser user, string email)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(TUser user, bool confirmed)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPhoneNumberAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetPhoneNumberConfirmedAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetPhoneNumberAsync(TUser user, string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public Task SetPhoneNumberConfirmedAsync(TUser user, bool confirmed)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetTwoFactorEnabledAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetTwoFactorEnabledAsync(TUser user, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetAccessFailedCountAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetLockoutEnabledAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public Task<int> IncrementAccessFailedCountAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public Task ResetAccessFailedCountAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEnabledAsync(TUser user, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEndDateAsync(TUser user, DateTimeOffset lockoutEnd)
        {
            throw new NotImplementedException();
        }

        private void ThrowIfDisposed()
        {
        }
    }
}