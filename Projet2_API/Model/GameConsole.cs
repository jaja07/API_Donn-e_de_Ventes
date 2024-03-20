namespace Projet2_API.Model
{
    public class GameConsole
    {
        public int Id { get; set; }
        public required string Nom { get; set; }
        public required string Fabricant { get; set; }
        public required string Type { get; set; }
        //public ICollection<Vente> Ventes { get; set; }
    }
}
