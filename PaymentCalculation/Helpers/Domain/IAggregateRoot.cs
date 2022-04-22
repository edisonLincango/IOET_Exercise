using System;

namespace PaymentCalculation.Helpers.Domain
{
    public interface IAggregateRoot
    {
        Guid Id { get; }
    }
}
