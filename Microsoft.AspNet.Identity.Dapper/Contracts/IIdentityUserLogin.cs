using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity.Dapper.Contracts
{
    public interface IIdentityUserLogin<TKey>
    {
        // Summary:
        //     The login provider for the login (i.e. facebook, google)
        string LoginProvider { get; set; }
        //
        // Summary:
        //     Key representing the login for the provider
        string ProviderKey { get; set; }
        //
        // Summary:
        //     User Id for the user who owns this login
        TKey UserId { get; set; }
    }
}
