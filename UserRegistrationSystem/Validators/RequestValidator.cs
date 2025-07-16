using UserRegistrationSystem.Dto;
using UserRegistrationSystem.Models;
using UserRegistrationSystem.Services;

namespace UserRegistrationSystem.Validators
{
    /// <summary>
    /// Provides validation logic for user registration requests.
    /// </summary>
    public class RequestValidator : IRequestValidator
    {
        /// <summary>
        /// Validates the specified <see cref="RegisterUserRequest"/> against business rules and existing users.
        /// </summary>
        /// <param name="request">The registration request to validate.</param>
        /// <param name="existingUsers">A collection of existing users to check for duplicates.</param>
        /// <returns>
        /// A <see cref="Notification"/> containing any validation errors found.
        /// </returns>
        public Notification Validate(RegisterUserRequest request, IEnumerable<User> existingUsers)
        {
            var notification = new Notification();

            if (string.IsNullOrWhiteSpace(request.Name))
            {
                notification.AddError("Name cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(request.Email))
            {
                notification.AddError("Email cannot be empty.");
            }
            else if (existingUsers.Select(u => u.Email).Contains(request.Email))
            {
                notification.AddError("Email already exists.");
            }

            if (request.Password.Length < 8)
            {
                notification.AddError("Password must be at least 8 characters.");
            }

            return notification;
        }
    }
}
