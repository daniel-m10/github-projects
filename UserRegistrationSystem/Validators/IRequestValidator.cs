using UserRegistrationSystem.Dto;
using UserRegistrationSystem.Models;
using UserRegistrationSystem.Services;

namespace UserRegistrationSystem.Validators
{
    public interface IRequestValidator
    {
        Notification Validate(RegisterUserRequest request, IEnumerable<User> existingUsers);
    }
}
