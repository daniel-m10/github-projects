using System.Text.Json;
using UserRegistrationSystem.Models;

namespace UserRegistrationSystem.Repositories
{
    public class JsonUserRepository : IUserRepository
    {
        private const string FilePath = "users.json";

        public IEnumerable<User> GetAll()
        {
            if (!File.Exists(FilePath))
            {
                return [];
            }

            var content = File.ReadAllText(FilePath);

            return JsonSerializer.Deserialize<List<User>>(content) ?? [];
        }

        public void Save(User user)
        {
            var users = GetAll().ToList();
            users.Add(user);
            var json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }
    }
}
