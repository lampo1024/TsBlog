using System;
using System.Web.Mvc;
using TsBlog.Core.Security;
using TsBlog.Domain.Entities;
using TsBlog.Services;
using TsBlog.ViewModel.User;

namespace TsBlog.Frontend.Controllers
{
    /// <summary>
    /// 用户中心控制器
    /// </summary>
    public class AccountController : Controller
    {
        /// <summary>
        /// 用户服务接口
        /// </summary>
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// 登录页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 提交登录请求
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken, AllowAnonymous]
        public ActionResult Login(LoginViewModel model)
        {
            //如果视图模型中的属性没有验证通过，则返回到登录页面，要求用户重新填写
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //根据用户登录名查询指定用户实体
            var user = _userService.FindByLoginName(model.UserName.Trim());

            //如果用户不存在，则携带错误消息并返回登录页面
            if (user == null)
            {
                ModelState.AddModelError("error_message", "用户不存在");
                return View(model);
            }

            //如果密码不匹配，则携带错误消息并返回登录页面
            if (user.Password != Encryptor.Md5Hash(model.Password.Trim()))
            {
                ModelState.AddModelError("error_message", "密码错误,请重新登录");
                return View(model);
            }

            //将用户实体保存到Session中
            Session["user_account"] = user;
            //跳转到首页
            return RedirectToAction("index", "home");
        }

        /// <summary>
        /// 注册页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// 提交注册请求
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken, AllowAnonymous]
        public ActionResult Register(RegisterViewModel model)
        {
            //如果视图模型中的属性没有验证通过，则返回到注册页面，要求用户重新填写
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //创建一个用户实体
            var user = new User
            {
                LoginName = model.UserName,
                Password = Encryptor.Md5Hash(model.Password.Trim()),
                CreatedOn = DateTime.Now
                //由于是示例教程，所以其他字段不作填充了
            };
            //将用户实体对象写入数据库中
            var ret = _userService.Insert(user);

            if (ret <= 0)
            {
                //如果注册失败,则携带错误消息并返回注册页面
                ModelState.AddModelError("error_message", "注册失败");
                return View(model);

            }
            //如果注册成功,则跳转到登录页面
            return RedirectToAction("login");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("index", "home");
        }
    }
}