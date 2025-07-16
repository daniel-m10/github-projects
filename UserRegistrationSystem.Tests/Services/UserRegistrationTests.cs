using UserRegistrationSystem.Dto;
using UserRegistrationSystem.Repositories;
using UserRegistrationSystem.Services;
using UserRegistrationSystem.Validators;

namespace UserRegistrationSystem.Tests.Services
{
    /// <summary>
    /// Contains unit tests for the <see cref="UserRegistrationService"/> class, verifying user registration scenarios and validation rules.
    /// </summary>
    [TestFixture]
    public class UserRegistrationTests
    {
        /// <summary>
        /// Cleans up the test environment by deleting the user data file before each test run.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            if (File.Exists("users.json"))
            {
                File.Delete("users.json");
            }
        }

        /// <summary>
        /// Verifies that registration fails when the user's name is empty.
        /// </summary>
        [Test]
        public void RegisterUser_ShouldFail_WhenNameIsEmpt()
        {
            // Arrange
            var repository = new JsonUserRepository();
            var validator = new RequestValidator();
            var service = new UserRegistrationService(validator, repository);
            var request = new RegisterUserRequest(Name: "", Email: "test@example.com", Password: "securepassword");

            // Act
            var result = service.Register(request);

            using (Assert.EnterMultipleScope())
            {
                // Assert
                Assert.That(result.IsSuccess, Is.False);
                Assert.That(result.Errors, Contains.Item("Name cannot be empty."));
            }
        }

        /// <summary>
        /// Verifies that registration fails when the user's email is empty.
        /// </summary>
        [Test]
        public void RegisterUser_ShouldFail_WhenEmailIsEmpty()
        {
            // Arrange
            var repository = new JsonUserRepository();
            var validator = new RequestValidator();
            var service = new UserRegistrationService(validator, repository);
            var request = new RegisterUserRequest(Name: "Test User", Email: "", Password: "securepassword");

            // Act
            var result = service.Register(request);

            using (Assert.EnterMultipleScope())
            {
                // Assert
                Assert.That(result.IsSuccess, Is.False);
                Assert.That(result.Errors, Contains.Item("Email cannot be empty."));
            }
        }

        /// <summary>
        /// Verifies that registration fails when the user's password is shorter than the minimum required length.
        /// </summary>
        [Test]
        public void RegisterUser_ShouldFail_WhenPasswordIsTooShort()
        {
            // Arrange
            var repository = new JsonUserRepository();
            var validator = new RequestValidator();
            var service = new UserRegistrationService(validator, repository);
            var request = new RegisterUserRequest(Name: "Test User", Email: "test@example.com", Password: "1234567");

            // Act
            var result = service.Register(request);

            using (Assert.EnterMultipleScope())
            {
                // Assert
                Assert.That(result.IsSuccess, Is.False);
                Assert.That(result.Errors, Contains.Item("Password must be at least 8 characters."));
            }
        }

        /// <summary>
        /// Verifies that registration fails when the user's email already exists in the system.
        /// </summary>
        [Test]
        public void RegisterUser_ShouldFail_WhenEmailAlreadyExists()
        {
            var repository = new JsonUserRepository();
            var validator = new RequestValidator();
            var service = new UserRegistrationService(validator, repository);

            var request1 = new RegisterUserRequest("John", "john@example.com", "securepassword");
            var request2 = new RegisterUserRequest("Jane", "john@example.com", "anothersecurepassword");

            var result1 = service.Register(request1);
            var result2 = service.Register(request2);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result1.IsSuccess, Is.True);
                Assert.That(result1.Errors, Is.Empty);

                Assert.That(result2.IsSuccess, Is.False);
                Assert.That(result2.Errors, Contains.Item("Email already exists."));
            }
        }
    }
}
