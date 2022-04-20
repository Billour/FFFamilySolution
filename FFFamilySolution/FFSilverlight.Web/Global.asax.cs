using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.ServiceModel.Activation;
using System.Web.Routing;
using Microsoft.ServiceModel.Http;
using FFSilverlight.Web.Common;
using FFF.Entity.Family;
using FFSilverlight.Web.RestServices;
using FFSilverlight.Web.RestServices.Authentication;


namespace FFSilverlight.Web
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
             //var configuration = new RestfulConfigurationManager();
            //RouteTable.Routes.AddServiceRoute<FamilyUserResource>("family", configuration);
            //Add Security 
            //RouteTable.Routes.AddServiceRoute<LoginAuthenticateService>("service/authentication", configuration);
            //RouteTable.Routes.Add(new ServiceRoute("service/authentication", new WebRestfulServiceFactory(), typeof(LoginAuthenticateService)));
            RouteTable.Routes.Add(new ServiceRoute("service/authentication", new WebServiceHostFactory(), typeof(LoginAuthenticateService)));
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}