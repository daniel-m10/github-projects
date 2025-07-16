using System.Text.Json;
using UserRegistrationSystem.Models;

namespace UserRegistrationSystem.Repositories
{
    /// <summary>
    /// Provides user data access operations using a JSON file as the data store.
    /// </summary>
    public class JsonUserRepository : IUserRepository
    {
        /// <summary>
        /// The file path where user data is stored in JSON format.
        /// </summary>
        private const string FilePath = "users.json";

        /// <summary>
        /// Retrieves all users from the JSON file.
        /// </summary>
        /// <returns>
        /// An enumerable collection of <see cref="User"/> objects.
        /// Returns an empty collection if the file does not exist or is empty.
        /// </returns>
        public IEnumerable<User> GetAll()
        {
            if (!File.Exists(FilePath))
            {
                return [];
            }

            var content = File.ReadAllText(FilePath);

            return JsonSerializer.Deserialize<List<User>>(content) ?? [];
        }

        /// <summary>
        /// Saves a user to the JSON file.
        /// </summary>
        /// <param name="user">The <see cref="User"/> object to save.</param>
        public void Save(User user)
        {
            var users = GetAll().ToList();
            users.Add(user);
            var json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }
    }
}
