namespace Projet_API.Models
{
    public class GameConsole
    {
        public int Id { get; set; }
        public required string Nom { get; set; }
        public required string Fabricant { get; set; }
        public required string Type { get; set; }
        public List<Vente> Ventes { get; set; }

        //Constructeur
        public GameConsole(string nom, string fabricant, string type)
        {
            this.Nom = nom;
            this.Fabricant = fabricant;
            this.Type = type;
            Ventes = new List<Vente>();
        }

        public void Add_Vente(Vente vente)
        {
            Ventes.Add(vente);
        }

        public Boolean Delete_Vente(Vente vente)
        {
            Boolean wasInList = Ventes.Remove(vente);
            return wasInList;
        }
    }
}



