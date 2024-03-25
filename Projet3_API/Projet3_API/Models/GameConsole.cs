using System.ComponentModel.DataAnnotations;

namespace Projet3_API.Models
{
    public class GameConsole
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom de la console est requis.")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le fabricant de la console est requis.")]
        public required string Fabricant { get; set; }

        [Required(ErrorMessage = "Le type de la console est requis.")]
        public required string Type { get; set; }
        
    }
}
