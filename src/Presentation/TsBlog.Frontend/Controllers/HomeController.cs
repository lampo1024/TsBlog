using System.Web.Mvc;
using TsBlog.Repositories;

namespace TsBlog.Frontend.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Post()
        {
            var postRepository = new PostRepository();
            var post = postRepository.FindById(1);
            return View(post);
        }
    }
}