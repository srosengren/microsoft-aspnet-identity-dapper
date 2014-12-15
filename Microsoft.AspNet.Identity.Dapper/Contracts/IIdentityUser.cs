using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity.Dapper.Contracts
{
    public interface IIdentityUser<TKey, TLogin, TRole, TClaim> : IUser<TKey>
        where TLogin : IIdentityUserLogin<TKey>
        where TRole : IIdentityUserRole<TKey>
        where TClaim : IIdentityUserClaim<TKey>
    {
    }
}
