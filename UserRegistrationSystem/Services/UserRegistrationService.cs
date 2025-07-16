using UserRegistrationSystem.Dto;
using UserRegistrationSystem.Models;
using UserRegistrationSystem.Repositories;
using UserRegistrationSystem.Validators;

namespace UserRegistrationSystem.Services
{
    public class UserRegistrationService(IRequestValidator validator, IUserRepository userRepository)
    {
        private readonly IRequestValidator _validator = validator;
        private readonly IUserRepository _userRepository = userRepository;

        public RegistrationResult Register(RegisterUserRequest request)
        {
            var existingUsers = _userRepository.GetAll();
            var validation = _validator.Validate(request, existingUsers);

            if (validation.HasErrors)
            {
                return new RegistrationResult
                {
                    IsSuccess = false,
                    Errors = validation.Errors
                };
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);
            var user = new User(Name: request.Name, Email: request.Email, PasswordHash: hashedPassword);
            _userRepository.Save(user);

            return new RegistrationResult
            {
                IsSuccess = true,
                Errors = []
            };
        }
    }
}
