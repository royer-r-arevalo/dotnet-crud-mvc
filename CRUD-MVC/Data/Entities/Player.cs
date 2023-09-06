namespace CRUD_MVC.Data.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? CurrentTeam { get; set; }
        public int GoldenBoots { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
