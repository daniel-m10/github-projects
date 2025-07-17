using UserRegistrationSystem.Dto;
using UserRegistrationSystem.Models;
using UserRegistrationSystem.Services;

namespace UserRegistrationSystem.Validators
{
    /// <summary>
    /// Provides validation logic for login requests.
    /// </summary>
    public class LoginRequestValidator : ILoginRequestValidator
    {
        /// <summary>
        /// Validates the specified login request against the provided list of existing users.
        /// </summary>
        /// <param name="request">The login request containing email and password.</param>
        /// <param name="existingUsers">A collection of existing users to validate against.</param>
        /// <returns>
        /// A <see cref="Notification"/> containing any validation errors encountered.
        /// </returns>
        public Notification Validate(LoginRequest request, IEnumerable<User> existingUsers)
        {
            var result = new Notification();

            if (string.IsNullOrWhiteSpace(request.Email))
                result.AddError("Email cannot be empty.");

            if (string.IsNullOrWhiteSpace(request.Password))
                result.AddError("Password cannot be empty.");

            var user = existingUsers.FirstOrDefault(u => u.Email == request.Email);

            if (user == null)
            {
                result.AddError("User not found.");
            }
            else if (!IsValidHashedPassword(request.Password, user.PasswordHash))
            {
                result.AddError("Invalid password.");
            }
            return result;
        }

        /// <summary>
        /// Verifies whether the provided password matches the hashed password.
        /// </summary>
        /// <param name="password">The plain text password to verify.</param>
        /// <param name="hashedPassword">The hashed password to compare against.</param>
        /// <returns>
        /// <c>true</c> if the password matches the hash; otherwise, <c>false</c>.
        /// </returns>
        private static bool IsValidHashedPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
