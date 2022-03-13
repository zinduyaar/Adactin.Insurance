using Adactin.Insurance.Core;
using Adactin.Insurance.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adactin.Insurance.Business
{
    public class PremiumService : IPremiumService
    {
        private readonly IOccupationRatingService _occupationRatingService;
        public PremiumService(IOccupationRatingService occupationRatingService)
        {
            _occupationRatingService = occupationRatingService;
        }
        public double CalculatePremium(DeathPremiumFactors factors)
        {
            var factor = _occupationRatingService.GetRatingFromOccupation(factors.OccupationId).GetFactor();

            return (factors.SumAssured * factor * factors.Age) / 1000 * 12;
        }


    }
}
