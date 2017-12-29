using TsBlog.Domain.Entities;

namespace TsBlog.Services
{
    public interface IUserService : IService<User>
    {
        User FindByLoginName(string loginName);
    }
}