using SqlSugar;
using System.Collections.Generic;
using TsBlog.Domain.Entities;

namespace TsBlog.Repositories
{
    /// <summary>
    /// POST表的数据库操作类
    /// </summary>
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        #region Implementation of IPostRepository

        /// <summary>
        /// 查询首页文章列表
        /// </summary>
        /// <param name="limit">要查询的记录数</param>
        /// <returns></returns>
        public IEnumerable<Post> FindHomePagePosts(int limit = 20)
        {
            using (var db = DbFactory.GetSqlSugarClient())
            {
                var list = db.Queryable<Post>().OrderBy(x => x.Id, OrderByType.Desc).Take(limit).ToList();
                return list;
            }
        }
    }
    #endregion
}