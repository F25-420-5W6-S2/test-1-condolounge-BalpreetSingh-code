namespace CondoLounge.Data.Entities
{
    public class Building
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Address { get; set; }

        public ICollection <Condo> Condos { get; set; } = new List<Condo>();

    }
}
