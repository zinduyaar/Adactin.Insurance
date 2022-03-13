using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adactin.Insurance.Domain.OccupationRating
{
    public class LightManualRating : IOccupationRating
    {
        public double GetFactor()
        {
            return 1.5;
        }
    }
}
