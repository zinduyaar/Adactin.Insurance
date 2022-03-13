namespace Adactin.Insurance.API.DTO
{
    public class CalculatePremiumRequestDTO
    {
        public string? FullName { get; set; }
        public int Age { get; set; }
        public int OccupationId { get; set; }
        public double DeathSumAssured { get; set; }

    }
}
