using Microsoft.AspNet.Identity.Dapper.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity.Dapper.Models
{
    public class IdentityUserRole<TKey> : IIdentityUserRole<TKey>
    {
        public TKey RoleId { get; set; }

        public TKey UserId { get; set; }
    }
}
