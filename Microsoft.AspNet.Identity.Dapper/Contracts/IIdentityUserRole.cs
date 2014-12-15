using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity.Dapper.Contracts
{
    public interface IIdentityUserRole<TKey>
    {
        // Summary:
        //     RoleId for the role
        TKey RoleId { get; set; }
        //
        // Summary:
        //     UserId for the user that is in the role
        TKey UserId { get; set; }
    }
}
