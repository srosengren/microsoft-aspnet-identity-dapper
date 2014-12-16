using Microsoft.AspNet.Identity.Dapper.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity.Dapper.Models
{
    public class IdentityUserLogin<TKey> : IIdentityUserLogin<TKey>
    {
        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }

        public TKey UserId { get; set; }
    }
}
