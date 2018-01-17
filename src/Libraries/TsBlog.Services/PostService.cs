using System.Collections.Generic;
using TsBlog.Domain.Entities;
using TsBlog.Repositories;

namespace TsBlog.Services
{
    public class PostService : GenericService<Post>, IPostService
    {
        private readonly IPostRepository _repository;
        public PostService(IPostRepository repository) : base(repository)
        {
            _repository = repository;
        }


        #region Implementation of IPostService

        /// <summary>
        /// 查询首页文章列表
        /// </summary>
        /// <param name="limit">要查询的记录数</param>
        /// <returns></returns>
        public IEnumerable<Post> FindHomePagePosts(int limit = 20)
        {
            return _repository.FindHomePagePosts(limit);
        }

        #endregion
    }
}