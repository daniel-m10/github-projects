using UserRegistrationSystem.Dto;
using UserRegistrationSystem.Models;
using UserRegistrationSystem.Repositories;
using UserRegistrationSystem.Validators;

namespace UserRegistrationSystem.Services
{
    /// <summary>
    /// Provides user registration functionality, including validation and persistence.
    /// </summary>
    public class UserRegistrationService(IRequestValidator validator, IUserRepository userRepository)
    {
        private readonly IRequestValidator _validator = validator;
        private readonly IUserRepository _userRepository = userRepository;

        /// <summary>
        /// Registers a new user after validating the request and ensuring uniqueness.
        /// </summary>
        /// <param name="request">The registration request containing user details.</param>
        /// <returns>
        /// A <see cref="RegistrationResult"/> indicating success or failure, and any validation errors.
        /// </returns>
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
