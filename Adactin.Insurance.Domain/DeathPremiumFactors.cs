using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adactin.Insurance.Domain
{
    public class DeathPremiumFactors
    {
        public int Age { get; set; }
        public double SumAssured { get; set; }
        public int OccupationId { get; set; }
    }
}
