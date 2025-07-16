using UserRegistrationSystem.Models;

namespace UserRegistrationSystem.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        void Save(User user);
    }
}
