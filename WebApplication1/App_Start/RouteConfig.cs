using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");



            routes.MapRoute(
                name: "Employee Edit",
                url: "Employee/Edit/{id}",
                defaults: new { controller = "Employee", action = "Edit" }
            );

            routes.MapRoute(
              name: "Employee Delete",
              url: "Employee/Delete/{id}",
              defaults: new { controller = "Employee", action = "Delete" }
            );

            routes.MapRoute(
              name: "Employee Detail",
              url: "Employee/Details/{id}",
              defaults: new { controller = "Employee", action = "Details" }
            );

            routes.MapRoute(
              name: "All Project",
              url: "Project/AllProjects",
              defaults: new { controller = "Project", action = "AllProjects" }
            );

            routes.MapRoute(
               name: "AddEmployeesToProj",
               url: "Project/{id}/AddEmployeesToProj",
               defaults: new { controller = "Project", action = "AddEmployeesToProj" }
               );

            routes.MapRoute(
               name: "AddEmployeesToProj_post",
               url: "Project/{id}/AddEmployeesToProj_post",
               defaults: new { controller = "Project", action = "AddEmployeesToProj_post" }
               );

            
            routes.MapRoute(
               name: "RemoveEmployeeFromProj",
               url: "Project/{id}/RemoveEmployeeFromProj/{empId}",
               defaults: new { controller = "Project", action = "RemoveEmployeeFromProj" }
               );

            routes.MapRoute(
              name: "Project Details",
              url: "Project/Details/{id}",
              defaults: new { controller = "Project", action = "Details" }
            );


            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
