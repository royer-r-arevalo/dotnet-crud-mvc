using System.ComponentModel.DataAnnotations;

namespace CRUD_MVC.Models
{
   public class PlayerViewModel
   {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
        [Required]
        public string? CurrentTeam { get; set; }

        public int? GoldenBoots { get; set; }
    }
}
