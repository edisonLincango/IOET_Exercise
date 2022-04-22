namespace PaymentCalculation.ConsoleAPP.Models
{
    public sealed class Response<TReturn> : Response
    {
        public TReturn Object { get; set; }
    }
}
