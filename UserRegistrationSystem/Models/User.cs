namespace UserRegistrationSystem.Models
{
    /// <summary>
    /// Represents a user in the registration system.
    /// </summary>
    /// <param name="Name">The user's full name.</param>
    /// <param name="Email">The user's email address.</param>
    /// <param name="PasswordHash">The hashed password of the user.</param>
    public record User(string Name, string Email, string PasswordHash);
}
