using TsBlog.Domain.Entities;
using TsBlog.Repositories;

namespace TsBlog.Services
{
    public class UserService : GenericService<User>, IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public User FindByLoginName(string loginName)
        {
            return _repository.FindByClause(x => x.LoginName == loginName);
        }
    }
}