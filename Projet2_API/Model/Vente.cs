namespace Projet2_API.Model
{
    public class Vente
    {
        public int Id { get; set; }
        public required int Annee { get; set; }
        public int Nbr_vente { get; set; }
        public double Revenu { get; set; }
        public required string Pays { get; set; }
        public GameConsole Console { get; set; }
        //public required int ConsoleId { get; set; }
    }
}
