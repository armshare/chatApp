using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ChatApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                name: "Login",
                url: "login",
                defaults: new { controller = "Login", action = "Index" }
            );

            routes.MapRoute(
            name: "ChatRoom",
            url: "chat",
            defaults: new { controller = "Chat", action = "Index"}
           );

            routes.MapRoute(
                name: "UserTyping",
                url: "chat/typing",
                defaults: new { controller = "Chat", action = "Typing"}
                );
        }
    }
}
