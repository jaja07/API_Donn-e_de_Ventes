using System.ComponentModel.DataAnnotations;

namespace Projet3_API.Models
{
    public class Vente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "L'année de vente est requise.")]
        public int Annee { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Le nombre de ventes doit être supérieur ou égal à zéro.")]
        public int Nbr_vente { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Le revenu doit être supérieur ou égal à zéro.")]
        public double Revenu { get; set; }

        [Required(ErrorMessage = "Le pays de vente est requis.")]
        public required string Pays { get; set; }
        
        public int? ConsoleId { get; set; }

       

    }
}
