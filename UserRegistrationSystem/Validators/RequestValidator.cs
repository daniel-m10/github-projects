using UserRegistrationSystem.Dto;
using UserRegistrationSystem.Models;
using UserRegistrationSystem.Services;

namespace UserRegistrationSystem.Validators
{
    public class RequestValidator : IRequestValidator
    {
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
