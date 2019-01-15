using XBC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace XBC.MVC.WebApp.Security
{
    public class CustomPrincipal : IPrincipal
    {
        private AccountViewModel Account;

        public CustomPrincipal(AccountViewModel account)
        {
            this.Account = account;
            this.Identity = new GenericIdentity(account.username);
        }

        public IIdentity Identity { get; set; }

        public bool IsInRole(string role)
        {
            var roles = role.Split(new char[] { ',' });
            return roles.Any(r => this.Account.Roles.Contains(r));
        }
    }
}