namespace UserRegistrationSystem.Dto
{
    /// <summary>
    /// Represents a login request containing user credentials.
    /// </summary>
    /// <param name="Email">The email address of the user attempting to log in.</param>
    /// <param name="Password">The password of the user attempting to log in.</param>
    public record LoginRequest(string Email, string Password);
}
