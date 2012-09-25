using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AWT2Demo.Web.Infrastructure
{
    // Källkoden ärligt stulen från: http://stackoverflow.com/questions/10064631/mvc-3-access-for-specific-user-only
    public class AuthorizeUserAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isAuthorized = base.AuthorizeCore(httpContext);
            if (!isAuthorized)
            {
                // the user is either not authenticated or 
                // not in roles => no need to continue any further 
                return false;
            }

            // get the currently logged on user 
            var username = httpContext.User.Identity.Name;

            // get the id of the article that he is trying to manipulate 
            // from the route data (this assumes that the id is passed as a route 
            // data parameter: /foo/edit/123). If this is not the case and you  
            // are using query string parameters you could fetch the id using the Request 
            var id = httpContext.Request.RequestContext.RouteData.Values["id"] as string;

            // Now that we have the current user and the id of the article he 
            // is trying to manipualte all that's left is go ahead and look in  
            // our database to see if this user is the owner of the article 
            return MethodForDeterminingThatTheUserIsAuthorized(username, id);
        } 

        private bool MethodForDeterminingThatTheUserIsAuthorized(string username, string id)
        {
            // Här skulle man kunna tänka sig en mer avancerad logik som beror på värden
            // i databasen eller liknande.
            if (1.ToString() == id)
                return true;
            return false;
        }
    }
}