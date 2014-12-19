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
        new TKey Id { get; set; }

        int AccessFailedCount { get; set; }
        //
        // Summary:
        //     Navigation property for user claims
        ICollection<TClaim> Claims { get; set; }
        //
        // Summary:
        //     Email
        string Email { get; set; }
        //
        // Summary:
        //     True if the email is confirmed, default is false
        bool EmailConfirmed { get; set; }
        //
        // Summary:
        //     Is lockout enabled for this user
        bool LockoutEnabled { get; set; }
        //
        // Summary:
        //     DateTime in UTC when lockout ends, any time in the past is considered not
        //     locked out.
        DateTime? LockoutEndDateUtc { get; set; }
        //
        // Summary:
        //     Navigation property for user logins
        ICollection<TLogin> Logins { get; set; }
        //
        // Summary:
        //     The salted/hashed form of the user password
        string PasswordHash { get; set; }
        //
        // Summary:
        //     PhoneNumber for the user
        string PhoneNumber { get; set; }
        //
        // Summary:
        //     True if the phone number is confirmed, default is false
        bool PhoneNumberConfirmed { get; set; }
        //
        // Summary:
        //     Navigation property for user roles
        ICollection<TRole> Roles { get; set; }
        //
        // Summary:
        //     A random value that should change whenever a users credentials have changed
        //     (password changed, login removed)
        string SecurityStamp { get; set; }
        //
        // Summary:
        //     Is two factor enabled for the user
        bool TwoFactorEnabled { get; set; }
    }
}
