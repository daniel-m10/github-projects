namespace UserRegistrationSystem.Services
{
    /// <summary>
    /// Represents the result of a login attempt, including success status and error messages.
    /// </summary>
    public class LoginResult
    {
        /// <summary>
        /// Gets a value indicating whether the login attempt was successful.
        /// </summary>
        public required bool IsSuccess { get; init; }

        /// <summary>
        /// Gets a list of error messages associated with the login attempt.
        /// </summary>
        public required IReadOnlyList<string> Errors { get; init; }
    }
}
