using System.Collections.Generic;
using TsBlog.Domain.Entities;

namespace TsBlog.Services
{
    public interface IPostService : IService<Post>
    {
        /// <summary>
        /// 查询首页文章列表
        /// </summary>
        /// <param name="limit">要查询的记录数</param>
        /// <returns></returns>
        IEnumerable<Post> FindHomePagePosts(int limit = 20);
    }
}