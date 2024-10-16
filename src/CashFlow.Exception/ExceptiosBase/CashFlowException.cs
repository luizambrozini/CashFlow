namespace CashFlow.Exception.ExceptiosBase
{
    public abstract class CashFlowException : SystemException
    {
        protected CashFlowException(string message) : base(message) { }
    }
}