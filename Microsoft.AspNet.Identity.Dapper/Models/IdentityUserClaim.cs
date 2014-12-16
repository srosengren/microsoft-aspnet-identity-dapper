using Microsoft.AspNet.Identity.Dapper.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity.Dapper.Models
{
    public class IdentityUserClaim<TKey> : IIdentityUserClaim<TKey>
    {
        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }

        public int Id { get; set; }

        public TKey UserId { get; set; }
    }
}
