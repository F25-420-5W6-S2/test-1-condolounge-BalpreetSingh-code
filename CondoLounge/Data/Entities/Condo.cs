namespace CondoLounge.Data.Entities
{
    public class Condo
    {
        public int Id { get; set; }
        public string CondoNumber { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int BuildingId { get; set; }
        public Building? Building { get; set; };
        public ICollection<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
    }
}
