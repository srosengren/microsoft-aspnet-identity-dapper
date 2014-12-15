using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity.Dapper.Contracts
{
    public interface IIdentityRole<TKey, TUserRole> : IRole<TKey> where TUserRole : IIdentityUserRole<TKey>
    {
        //
        // Summary:
        //     Navigation property for users in the role
        ICollection<TUserRole> Users { get; }
    }
}
