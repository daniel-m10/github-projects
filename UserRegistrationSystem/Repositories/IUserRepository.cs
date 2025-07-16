using UserRegistrationSystem.Models;

namespace UserRegistrationSystem.Repositories
{
    /// <summary>
    /// Defines methods for user data access operations.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Retrieves all users from the data store.
        /// </summary>
        /// <returns>An enumerable collection of <see cref="User"/> objects.</returns>
        IEnumerable<User> GetAll();

        /// <summary>
        /// Saves a user to the data store.
        /// </summary>
        /// <param name="user">The <see cref="User"/> object to save.</param>
        void Save(User user);
    }
}
