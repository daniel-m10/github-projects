namespace UserRegistrationSystem.Services
{
    public class RegistrationResult
    {
        public required bool IsSuccess { get; init; }
        public required IReadOnlyList<string> Errors { get; init; }
    }
}
