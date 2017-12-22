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
    }
}