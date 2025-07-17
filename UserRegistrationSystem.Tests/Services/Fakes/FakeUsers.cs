using UserRegistrationSystem.Models;
using UserRegistrationSystem.Repositories;

namespace UserRegistrationSystem.Tests.Services.Fakes
{
    /// <summary>
    /// A fake implementation of <see cref="IUserRepository"/> for unit testing purposes.
    /// Stores users in memory.
    /// </summary>
    public class FakeUsers : IUserRepository
    {
        /// <summary>
        /// The hashed password used for the default test user.
        /// </summary>
        private static readonly string _hashedPassword = BCrypt.Net.BCrypt.HashPassword("correctpassword");

        /// <summary>
        /// The in-memory list of users.
        /// </summary>
        public readonly List<User> _users = [
            new User(Name: "Test User", Email: "userfound@example.test", PasswordHash: _hashedPassword)
        ];

        /// <summary>
        /// Retrieves all users from the in-memory store.
        /// </summary>
        /// <returns>An enumerable collection of <see cref="User"/> objects.</returns>
        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        /// <summary>
        /// Adds a user to the in-memory store.
        /// </summary>
        /// <param name="user">The <see cref="User"/> object to add.</param>
        public void Save(User user)
        {
            _users.Add(user);
        }
    }
}
