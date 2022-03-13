using Adactin.Insurance.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adactin.Insurance.Core
{
    public interface IPremiumFacade
    {
        double CalculatePremium(int age, int occupationId, double deathSumAssured);
    }

    public class PremiumFacade : IPremiumFacade
    {
        private readonly IPremiumService _premiumService;
        public PremiumFacade(IPremiumService premiumService)
        {
            _premiumService = premiumService;
        }
        public double CalculatePremium(int age, int occupationId, double deathSumAssured)
        {
            var factors = new DeathPremiumFactors
            {
                Age = age,
                OccupationId = occupationId,
                SumAssured = deathSumAssured
            };
            return _premiumService.CalculatePremium(factors);
        }
    }
}
