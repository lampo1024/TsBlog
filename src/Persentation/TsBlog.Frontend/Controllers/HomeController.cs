using Microsoft.AspNetCore.Mvc;
using TsBlog.Repository;

namespace TsBlog.Frontend.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var post = new PostRepository().Read();
            return View(post);
        }
    }
}