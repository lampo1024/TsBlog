using DunxPay.Services;
using System.Web.Mvc;

namespace TsBlog.Frontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService _postService;
        public HomeController(IPostService postService)
        {
            _postService = postService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Post()
        {
            //var postRepository = new PostRepository();
            //var post = postRepository.FindById(1);
            //return View(post);

            var post = _postService.FindById(1);
            return View(post);
        }
    }
}