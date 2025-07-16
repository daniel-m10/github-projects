using UserRegistrationSystem.Dto;
using UserRegistrationSystem.Repositories;
using UserRegistrationSystem.Services;
using UserRegistrationSystem.Validators;

namespace UserRegistrationSystem.Tests.Services
{
    [TestFixture]
    public class UserRegistrationTests
    {
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

            // Assert
            Assert.That(result.IsSuccess, Is.False);
            Assert.That(result.Errors, Contains.Item("Name cannot be empty."));
        }

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

            // Assert
            Assert.That(result.IsSuccess, Is.False);
            Assert.That(result.Errors, Contains.Item("Email cannot be empty."));
        }

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

            // Assert
            Assert.That(result.IsSuccess, Is.False);
            Assert.That(result.Errors, Contains.Item("Password must be at least 8 characters."));
        }

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

            Assert.That(result1.IsSuccess, Is.True);
            Assert.That(result1.Errors, Is.Empty);

            Assert.That(result2.IsSuccess, Is.False);
            Assert.That(result2.Errors, Contains.Item("Email already exists."));
        }
    }
}
