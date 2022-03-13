using Adactin.Insurance.Domain.OccupationRating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adactin.Insurance.Core
{
    public interface IOccupationRatingService
    {
        IOccupationRating GetRatingFromOccupation(int occupationId);
    }
}
