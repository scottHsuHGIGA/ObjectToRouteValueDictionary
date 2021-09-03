using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ObjectToRouteValueDictionary.Controllers
{
    public class HomeController : Controller
    {
        public class TestModel
        {
            public string Astring { get; set; }
            public string Bstring { get; set; }
            public string Cstring { get; set; }
        }

        public ActionResult Index()
        {
            var model = new TestModel()
            {
                Astring = "這是A",
                Bstring = "這是B",
                Cstring = "這是C"
            };
            ViewData["TestModel"] = model;
            ViewData["ActionName"] = "Index";
            return View();
        }

        public ActionResult Test(TestModel model)
        {
            ViewData["TestModel"] = model;
            ViewData["ActionName"] = "Test";
            return View("Index");
        }

    }
}