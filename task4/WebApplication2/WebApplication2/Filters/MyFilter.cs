using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Controllers;
using WebApplication2.Data;

namespace WebApplication2.Filters
{
    public class MyFilter : ActionFilterAttribute
    {
        private AppDbContext appDbContext;
        public String RedirectController { get; set; }
        public String RedirectAction { get; set; }
        public MyFilter(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }


        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {

            foreach (var c in filterContext.HttpContext.Request.Cookies)
            {

                if (c.Key.Equals("user"))
                {
                    User user = appDbContext.Users.FirstOrDefault(u => u.Name == c.Value);
                    if (user == null || user.IsBlock == true)
                    {

                        if(filterContext.Controller is HomeController)
                        {
                            var controller = (HomeController)filterContext.Controller;
                            var x = filterContext.Result = controller.RedirectToAction("login", "home");
                        }
                      



                    }
                }

            }
        }



    }
}
