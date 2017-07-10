using System.Web.Mvc; 
using TMSLibrary.Factory;
using TMSLibrary.Class; 

namespace TMSAdmin.Controllers
{
    public class LocationController : Controller
    {
       //----- Get Location List -----
        public JsonResult List()
        {
            //----------------- Search All -------------
            TMSFactory UserFactory = new UserFactory();
            Client client = new Client(UserFactory);
            Location location = new Location();
            //IEnumerable<Location> listQuery = location.GetListAll(); 
            var listQuery = location.GetListByQuery(30);

            return this.Json(listQuery, JsonRequestBehavior.AllowGet);
        }



        public ActionResult Test1()
        {  
            return View();
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Index Page";

            return View();
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