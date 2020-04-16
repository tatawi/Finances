using Finance.Business.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Finance.Attributes
{
    public class ApplicationAuthorizeAttribute : AuthorizeAttribute
    {
        public ApplicationAuthorizeAttribute()
        {

        }

        public override void OnAuthorization(AuthorizationContext authorizationContext)
        {
            var user = ApplicationManager.CurrentUser;
            if (user == null)
            {
                authorizationContext.Result = new RedirectResult("~/Login/Authent");
                base.OnAuthorization(authorizationContext);
                return;
            }

            if (this.AuthorizeCore(authorizationContext.HttpContext))
            {
                base.OnAuthorization(authorizationContext);
            }
            else
            {
                authorizationContext.Result = new RedirectResult("~/Login/Authent");
            }

        }

    }
}