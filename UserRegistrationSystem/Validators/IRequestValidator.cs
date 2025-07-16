using UserRegistrationSystem.Dto;
using UserRegistrationSystem.Models;
using UserRegistrationSystem.Services;

namespace UserRegistrationSystem.Validators
{
    /// <summary>
    /// Defines a contract for validating user registration requests.
    /// </summary>
    public interface IRequestValidator
    {
        /// <summary>
        /// Validates the specified user registration request against existing users.
        /// </summary>
        /// <param name="request">The registration request to validate.</param>
        /// <param name="existingUsers">A collection of users to check for conflicts or duplicates.</param>
        /// <returns>
        /// A <see cref="Notification"/> containing any validation errors found during the process.
        /// </returns>
        Notification Validate(RegisterUserRequest request, IEnumerable<User> existingUsers);
    }
}
