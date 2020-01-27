using Finance.Business.Interface.Services;
using Finance.Business.Managers;
using Finance.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Finance
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


        }


        protected void Session_Start()
        {
            //Set Current User in session
            if (Request.IsAuthenticated)
            {

                ApplicationManager.SetupUser(HttpContext.Current.User.Identity.Name);

                //if(currentUser==null)
                //{
                //    Server.ClearError();
                //    Response.Clear();
                //    Response.Redirect("~/Login/index");
                //}
                

                //if (currentUser != null && !ApplicationManager.CurrentUser.IsActif)
                //    throw new HttpException(401, "Ce compte utilisateur a été désactivé.");

            }

        }


    }
}
