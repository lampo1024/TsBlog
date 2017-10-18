using System.Web.Mvc;
using TsBlog.Repositories;

namespace TsBlog.Frontend.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var post = new PostRepository().Read();
            return View(post);
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