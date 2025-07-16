namespace UserRegistrationSystem.Services
{
    /// <summary>
    /// Represents the result of a user registration attempt.
    /// </summary>
    public class RegistrationResult
    {
        /// <summary>
        /// Gets a value indicating whether the registration was successful.
        /// </summary>
        public required bool IsSuccess { get; init; }

        /// <summary>
        /// Gets a list of error messages encountered during registration.
        /// </summary>
        public required IReadOnlyList<string> Errors { get; init; }
    }
}
