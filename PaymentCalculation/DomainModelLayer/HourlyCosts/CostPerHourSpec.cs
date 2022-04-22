using PaymentCalculation.Helpers.Specification;
using System;
using System.Linq.Expressions;

namespace PaymentCalculation.DomainModelLayer.HourlyCosts
{
    public class CostPerHourSpec : SpecificationBase<CostPerHour>
    {

        public string Day { get; set; }
        public int InitialHour { get; set; }
        public int FinalHour { get; set; }

        public CostPerHourSpec(string day, int initialHour, int finalHour)
        {
            this.Day = day;
            this.InitialHour = initialHour;
            this.FinalHour = finalHour;
        }

        public override Expression<Func<CostPerHour, bool>> SpecExpression
        {
            get
            {
                return cost => cost.Day == this.Day && cost.FinalHour >= this.FinalHour && cost.InitialHour <= this.InitialHour ;
            }
        }

    }
}
