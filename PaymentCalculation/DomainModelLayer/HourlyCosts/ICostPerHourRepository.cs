using PaymentCalculation.Helpers.Repository;
using System.Collections.Generic;

namespace PaymentCalculation.DomainModelLayer.HourlyCosts
{
    public interface ICostPerHourRepository : IRepository<CostPerHour>
    {
        IEnumerable<CostPerHourReadModel> GetCostPerHour();
    }
}
