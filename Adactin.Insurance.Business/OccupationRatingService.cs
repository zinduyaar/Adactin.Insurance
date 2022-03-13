using Adactin.Insurance.Core;
using Adactin.Insurance.Domain.OccupationRating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adactin.Insurance.Business
{
    public class OccupationRatingService : IOccupationRatingService
    {
        public IOccupationRating GetRatingFromOccupation(int occupationId)
        {
            return GetOccupationRating(occupationId);
        }

        #region Private Methods

        private List<(int, string)> GetOccupationRatingMappings()
        {
            return new List<(int, string)>
            {
                (1, "LightManual"),
                (2, "Professional"),
                (3, "WhiteCollar"),
                (4, "HeavyManual"),
                (5, "HeavyManual"),
                (6, "LightManual"),
            };
        }

        private IOccupationRating GetOccupationRating(int occupationId)
        {
            IOccupationRating occupationRating;
            var occupationRatingMappings = GetOccupationRatingMappings();
            var rating = occupationRatingMappings.FirstOrDefault(r => r.Item1 == occupationId).Item2;

            switch (rating)
            {
                case "LightManual":
                    occupationRating = new LightManualRating();
                    break;
                case "Professional":
                    occupationRating = new ProfessionalRating();
                    break;
                case "WhiteCollar":
                    occupationRating = new WhiteCollarRating();
                    break;
                case "HeavyManual":
                    occupationRating = new HeavyManualRating();
                    break;
                default:
                    occupationRating = new DefaultRating();
                    break;
            }

            return occupationRating;
        }
        #endregion
    }
}
