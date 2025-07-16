namespace UserRegistrationSystem.Dto
{
    /// <summary>
    /// Represents a request to register a new user.
    /// </summary>
    /// <param name="Name">The name of the user.</param>
    /// <param name="Email">The email address of the user.</param>
    /// <param name="Password">The password for the user account.</param>
    public record RegisterUserRequest(string Name, string Email, string Password);
}
