using System.Net;

namespace CashFlow.Exception.ExceptiosBase
{

    public class ErrorOnValidationException : CashFlowException
    {
        private readonly List<string> _errors;
        public override int StatusCode => (int)HttpStatusCode.BadRequest;
        public ErrorOnValidationException(List<string> errorMesages) : base(string.Empty)
        {
            _errors = errorMesages;
        }

        public override List<string> GetErrors()
        {
            return _errors;
        }
    }
}
