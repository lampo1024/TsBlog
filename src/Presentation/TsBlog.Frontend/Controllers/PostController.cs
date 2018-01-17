using System.Web.Mvc;
using TsBlog.AutoMapperConfig;
using TsBlog.Services;

namespace TsBlog.Frontend.Controllers
{
    public class PostController : Controller
    {
        /// <summary>
        /// 文章服务接口
        /// </summary>
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        /// <summary>
        /// 文章详情
        /// </summary>
        /// <param name="id">文章ID</param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            var post = _postService.FindById(id);
            var model = post.ToModel();
            return View(model);
        }
    }
}