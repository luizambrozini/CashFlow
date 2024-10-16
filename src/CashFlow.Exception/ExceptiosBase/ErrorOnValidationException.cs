namespace CashFlow.Exception.ExceptiosBase
{

    public class ErrorOnValidationException : CashFlowException
    {
        public List<string> Errors { get; set; } = [];
        public ErrorOnValidationException(List<string> errorMesages) : base(string.Empty)
        {
            Errors = errorMesages;
        }
    }
}
