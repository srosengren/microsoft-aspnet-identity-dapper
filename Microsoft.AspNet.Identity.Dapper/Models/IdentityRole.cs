using Microsoft.AspNet.Identity.Dapper.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity.Dapper.Models
{
    public class IdentityRole<TKey,TUserRole> : IIdentityRole<TKey,TUserRole>
        where TUserRole : IIdentityUserRole<TKey>
    {
        public ICollection<TUserRole> Users { get; set; }

        public TKey Id { get; set; }

        public string Name { get; set; }
    }
}
