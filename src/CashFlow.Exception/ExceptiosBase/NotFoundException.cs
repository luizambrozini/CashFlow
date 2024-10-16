using System.Net;

namespace CashFlow.Exception.ExceptiosBase
{
    public class NotFoundException : CashFlowException
    {
        public override int StatusCode => (int)HttpStatusCode.NotFound;
        public NotFoundException(string errorMessage) : base(errorMessage) { }

        public override List<string> GetErrors()
        {
            return [Message];
        }
    }
}
