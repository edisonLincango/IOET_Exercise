using PaymentCalculation.DomainModelLayer.HourlyCosts;
using PaymentCalculation.Helpers.Specification;
using System;
using System.Collections.Generic;

namespace PaymentCalculation.InfrastructureLayer
{
    public sealed class CostPerHourRepository : ICostPerHourRepository
    {
        readonly MemoryRepository<CostPerHour> memRepository;

        public CostPerHourRepository(MemoryRepository<CostPerHour> memRepository)
        {
            this.memRepository = memRepository;           

            this.memRepository.Add(new CostPerHour() { Day = "MO", InitialHour = 1, FinalHour = 9, Cost = 25 });
            this.memRepository.Add(new CostPerHour() { Day = "MO", InitialHour = 9, FinalHour = 18, Cost = 15 });
            this.memRepository.Add(new CostPerHour() { Day = "MO", InitialHour = 18, FinalHour = 24, Cost = 20 });

            this.memRepository.Add(new CostPerHour() { Day = "TU", InitialHour = 1, FinalHour = 9, Cost = 25 });
            this.memRepository.Add(new CostPerHour() { Day = "TU", InitialHour = 9, FinalHour = 18, Cost = 15 });
            this.memRepository.Add(new CostPerHour() { Day = "TU", InitialHour = 18, FinalHour = 24, Cost = 20 });

            this.memRepository.Add(new CostPerHour() { Day = "WE", InitialHour = 1, FinalHour = 9, Cost = 25 });
            this.memRepository.Add(new CostPerHour() { Day = "WE", InitialHour = 9, FinalHour = 18, Cost = 15 });
            this.memRepository.Add(new CostPerHour() { Day = "WE", InitialHour = 18, FinalHour = 24, Cost = 20 });

            this.memRepository.Add(new CostPerHour() { Day = "TH", InitialHour = 1, FinalHour = 9, Cost = 25 });
            this.memRepository.Add(new CostPerHour() { Day = "TH", InitialHour = 9, FinalHour = 18, Cost = 15 });
            this.memRepository.Add(new CostPerHour() { Day = "TH", InitialHour = 18, FinalHour = 24, Cost = 20 });

            this.memRepository.Add(new CostPerHour() { Day = "FR", InitialHour = 1, FinalHour = 9, Cost = 25 });
            this.memRepository.Add(new CostPerHour() { Day = "FR", InitialHour = 9, FinalHour = 18, Cost = 15 });
            this.memRepository.Add(new CostPerHour() { Day = "FR", InitialHour = 18, FinalHour = 24, Cost = 20 });

            this.memRepository.Add(new CostPerHour() { Day = "SA", InitialHour = 1, FinalHour = 9, Cost = 30 });
            this.memRepository.Add(new CostPerHour() { Day = "SA", InitialHour = 9, FinalHour = 18, Cost = 20 });
            this.memRepository.Add(new CostPerHour() { Day = "SA", InitialHour = 18, FinalHour = 24, Cost = 25 });

            this.memRepository.Add(new CostPerHour() { Day = "SU", InitialHour = 1, FinalHour = 9, Cost = 30 });
            this.memRepository.Add(new CostPerHour() { Day = "SU", InitialHour = 9, FinalHour = 18, Cost = 20 });
            this.memRepository.Add(new CostPerHour() { Day = "SU", InitialHour = 18, FinalHour = 24, Cost = 25 });

        }

        public CostPerHour FindById(Guid id)
        {
            return this.memRepository.FindById(id);
        }

        public CostPerHour FindOne(ISpecification<CostPerHour> spec)
        {
            return this.memRepository.FindOne(spec);
        }

        public IEnumerable<CostPerHour> Find(ISpecification<CostPerHour> spec)
        {
            return this.memRepository.Find(spec);
        }

        public void Add(CostPerHour entity)
        {
            this.memRepository.Add(entity);
        }

        public void Remove(CostPerHour entity)
        {
            this.memRepository.Remove(entity);
        }

        public IEnumerable<CostPerHourReadModel> GetCostPerHour()
        {
            throw new NotImplementedException();
        }
    }

}
