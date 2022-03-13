using Adactin.Insurance.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adactin.Insurance.Core
{
    public interface IPremiumService
    {
        double CalculatePremium(DeathPremiumFactors factors);
    }
}
