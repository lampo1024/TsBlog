using TsBlog.Domain.Entities;
using TsBlog.Repositories;

namespace TsBlog.Services
{
    public interface IPostService : IDependency, IService<Post>
    {

    }
}