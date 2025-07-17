using UserRegistrationSystem.Dto;
using UserRegistrationSystem.Models;
using UserRegistrationSystem.Services;

namespace UserRegistrationSystem.Validators
{
    /// <summary>
    /// Defines a contract for validating login requests against existing users.
    /// </summary>
    public interface ILoginRequestValidator
    {
        /// <summary>
        /// Validates the specified login request using the provided collection of existing users.
        /// </summary>
        /// <param name="request">The login request to validate.</param>
        /// <param name="existingUsers">A collection of users to validate against.</param>
        /// <returns>
        /// A <see cref="Notification"/> containing any validation errors found during the process.
        /// </returns>
        Notification Validate(LoginRequest request, IEnumerable<User> existingUsers);
    }
}
