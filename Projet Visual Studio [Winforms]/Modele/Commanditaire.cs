namespace Modele
{
    public class Commanditaire : Personne
    {
        private string idCommanditaire;
        public Commanditaire() : base() { }
        public Commanditaire(string idCommanditaire, string prenom, string surnom)
          : base(prenom, surnom)
        {
            this.idCommanditaire = idCommanditaire;
        }
        public string getId()
        {
            return idCommanditaire;
        }
        public override string ToString()
        {
            return "Identifiant : " + idCommanditaire + base.ToString();
        }
    }
}