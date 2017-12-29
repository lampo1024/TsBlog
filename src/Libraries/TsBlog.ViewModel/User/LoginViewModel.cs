using System.ComponentModel.DataAnnotations;

namespace TsBlog.ViewModel.User
{
    /// <summary>
    /// 用户登录视图实体
    /// </summary>
    public class LoginViewModel
    {
        [Required(ErrorMessage = "请输入用户")]
        [Display(Name = "用户名")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "请输入密码")]
        [Display(Name = "密码")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}