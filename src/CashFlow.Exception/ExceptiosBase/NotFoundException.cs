namespace CashFlow.Exception.ExceptiosBase
{
    public class NotFoundException : CashFlowException
    {
        public string Error { get; set; } = string.Empty;

        public NotFoundException(string errorMessage)
        {
            Error = errorMessage;
        }
    }
}
