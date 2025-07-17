using UserRegistrationSystem.Dto;
using UserRegistrationSystem.Services;
using UserRegistrationSystem.Tests.Services.Fakes;
using UserRegistrationSystem.Validators;

namespace UserRegistrationSystem.Tests.Services
{
    /// <summary>
    /// Contains unit tests for the <see cref="LoginService"/> class.
    /// </summary>
    [TestFixture]
    public class LoginServiceTests
    {
        /// <summary>
        /// Tests that login fails when the email is empty.
        /// </summary>
        [Test]
        public void Login_ShouldFail_WhenEmailIsEmpty()
        {
            // Arrange
            var request = new LoginRequest("", "somepassword");
            var service = new LoginService(new FakeUsers(), new LoginRequestValidator());

            // Act
            var result = service.Login(request);

            using (Assert.EnterMultipleScope())
            {
                // Assert
                Assert.That(result.IsSuccess, Is.False);
                Assert.That(result.Errors, Contains.Item("Email cannot be empty."));
            }
        }

        /// <summary>
        /// Tests that login fails when the password is empty.
        /// </summary>
        [Test]
        public void Login_ShouldFail_WhenPasswordIsEmpty()
        {
            var request = new LoginRequest("test@example.com", "");
            var service = new LoginService(new FakeUsers(), new LoginRequestValidator());

            var result = service.Login(request);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result.IsSuccess, Is.False);
                Assert.That(result.Errors, Contains.Item("Password cannot be empty."));
            }
        }

        /// <summary>
        /// Tests that login fails when the user is not found.
        /// </summary>
        [Test]
        public void Login_ShouldFail_WhenUserNotFound()
        {
            var request = new LoginRequest("notfound@example.com", "validpass");
            var service = new LoginService(new FakeUsers(), new LoginRequestValidator());

            var result = service.Login(request);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result.IsSuccess, Is.False);
                Assert.That(result.Errors, Contains.Item("User not found."));
            }
        }

        /// <summary>
        /// Tests that login fails when the password is incorrect.
        /// </summary>
        [Test]
        public void Login_ShouldFail_WhenPasswordIsIncorrect()
        {
            var request = new LoginRequest("userfound@example.test", "wrongpassword");
            var service = new LoginService(new FakeUsers(), new LoginRequestValidator());

            var result = service.Login(request);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(result.IsSuccess, Is.False);
                Assert.That(result.Errors, Contains.Item("Invalid password."));
            }
        }
    }
}
