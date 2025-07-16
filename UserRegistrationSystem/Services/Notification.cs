namespace UserRegistrationSystem.Services
{
    /// <summary>
    /// Represents a notification mechanism for collecting error messages during operations.
    /// </summary>
    public class Notification
    {
        /// <summary>
        /// Stores the list of error messages.
        /// </summary>
        private readonly List<string> _errors = [];

        /// <summary>
        /// Gets a read-only list of error messages.
        /// </summary>
        public IReadOnlyList<string> Errors => _errors;

        /// <summary>
        /// Gets a value indicating whether any errors have been recorded.
        /// </summary>
        public bool HasErrors => _errors.Count != 0;

        /// <summary>
        /// Adds an error message to the notification.
        /// </summary>
        /// <param name="message">The error message to add.</param>
        public void AddError(string message) => _errors.Add(message);
    }
}
