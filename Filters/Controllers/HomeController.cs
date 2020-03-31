using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Filters.Infrastructure;

namespace Filters.Controllers
{
    public class HomeController : Controller
    {
        [CustomAuth(true)]
        public string Index()
        {
            return "This is the Index action on the Home controller";
        }
    }
}