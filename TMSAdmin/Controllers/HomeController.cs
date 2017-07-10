using System.Web.Mvc; 
using TMSLibrary.Factory;
using TMSLibrary.Class;
using System.Collections.Generic;
using Amazon.DynamoDBv2.DocumentModel;

namespace TMSAdmin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
            //return View("/NgLocation");
        } 
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}