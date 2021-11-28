using Jose;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Configuration;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using 購物網站MVC_Demo.Security;

namespace 購物網站MVC_Demo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Name;
        }

        protected void Application_OnPostAuthenticateRequest(object sender, EventArgs e)
        {
            HttpRequest httpRequest = HttpContext.Current.Request;
            var secretKey = WebConfigurationManager.AppSettings["secretKey"].ToString();
            var cookieName = WebConfigurationManager.AppSettings["cookieName"].ToString();
            if (httpRequest.Cookies[cookieName] != null)
            {
                JwtObject jwtObject = JWT.Decode<JwtObject>(Convert.ToString((httpRequest.Cookies[cookieName].Value)), Encoding.UTF8.GetBytes(secretKey), JwsAlgorithm.HS512);
                string account = jwtObject.Account;
                string[] roles = jwtObject.Role.ToString().Split(new char[] { ',' });
                List<Claim> claimList = new List<Claim>();
                claimList.Add(new Claim(ClaimTypes.Name, account));
                claimList.Add(new Claim(ClaimTypes.NameIdentifier, account));
                foreach (string role in roles)
                    claimList.Add(new Claim(ClaimTypes.Role, role));
                claimList.Add(new Claim(@"https://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "My Identity", @"http://www.w3.org/2001/XMLSchema#string"));
                var identity = new ClaimsIdentity(claimList.ToArray(), cookieName);
                HttpContext.Current.User = new GenericPrincipal(identity, roles);
                Thread.CurrentPrincipal = HttpContext.Current.User;
                AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Name;
            }
        }
    }
}
