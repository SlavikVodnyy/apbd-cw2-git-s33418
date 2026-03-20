namespace APBD_TASK2.Services
{
    public record OperationResult(bool Success, string Message)
    {
        public static OperationResult Ok(string message) => new(true, message);
        public static OperationResult Fail(string message) => new(false, message);
    }
}
