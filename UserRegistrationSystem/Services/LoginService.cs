using UserRegistrationSystem.Dto;
using UserRegistrationSystem.Repositories;
using UserRegistrationSystem.Validators;

namespace UserRegistrationSystem.Services
{
    /// <summary>
    /// Provides login functionality for users, including validation and result reporting.
    /// </summary>
    public class LoginService(IUserRepository repository, ILoginRequestValidator requestValidator)
    {
        /// <summary>
        /// The user repository used to access user data.
        /// </summary>
        public readonly IUserRepository _repository = repository;

        /// <summary>
        /// The validator used to validate login requests.
        /// </summary>
        public readonly ILoginRequestValidator _requestValidator = requestValidator;

        /// <summary>
        /// Attempts to log in a user with the specified login request.
        /// </summary>
        /// <param name="request">The login request containing user credentials.</param>
        /// <returns>
        /// A <see cref="LoginResult"/> indicating whether the login was successful and any associated errors.
        /// </returns>
        public LoginResult Login(LoginRequest request)
        {
            var existingUsers = _repository.GetAll();
            var validationResult = _requestValidator.Validate(request, existingUsers);

            if (validationResult.HasErrors)
            {
                return new LoginResult
                {
                    IsSuccess = false,
                    Errors = validationResult.Errors
                };
            }

            return new LoginResult
            {
                IsSuccess = true,
                Errors = []
            };
        }
    }
}
