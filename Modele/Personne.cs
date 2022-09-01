using System;
namespace Modele{
	public abstract class Personne{
		private string prenom;
		public string Prenom{
			set{prenom = value;} 
			get => prenom;
		}
		private string surnom;
		public string Surnom{
			set{surnom = value;} 
			get => surnom;
		}
		public Personne(){}
		public Personne(string prenom, string surnom){
			this.prenom = prenom;
			this.surnom = surnom;
		} 
		public override string ToString(){
			return "Nom : " + surnom + 
			       ", prénom : " + prenom;
		}
	}
}
		