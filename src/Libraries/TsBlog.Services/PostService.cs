using System.Collections.Generic;
using TsBlog.Domain.Entities;
using TsBlog.Repositories;

namespace TsBlog.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public bool Delete(Post entity)
        {
            return _postRepository.Delete(entity);
        }

        public bool DeleteById(object id)
        {
            return _postRepository.DeleteById(id);
        }

        public bool DeleteByIds(object[] ids)
        {
            return _postRepository.DeleteByIds(ids);
        }

        public IEnumerable<Post> FindAll()
        {
            return _postRepository.FindAll();
        }

        public Post FindById(int id)
        {
            return _postRepository.FindById(id);
        }

        public int Insert(Post entity)
        {
            return _postRepository.Insert(entity);
        }

        public bool Update(Post entity)
        {
            return _postRepository.Update(entity);
        }
    }
}
