using System;
namespace Modele{
	public class Donateur : Personne{
		private string idDonateur;
		private string courriel;
		public string Courriel
		{
			set{
				if(value != null && value.Trim().Length != 0)
					courriel = value;
			}
			get => courriel;
		}
		private string telephone;
		public string Telephone{
			set{
				if(value != null && value.Trim().Length != 0)
					telephone = value;
			}
			get => telephone;
		}
		private char typeDeCarte;
		public char TypeDeCarte{
			set{
				if(value == 'M' || value == 'C')
					typeDeCarte = value;
			}
			get => typeDeCarte;
		}
		private string numeroDeCarte;
		public string NumeroDeCarte{
			set{
				if(value != null && value.Trim().Length != 0)
					numeroDeCarte = value;
			}
			get => numeroDeCarte;
		}
		private string dateExpiration;
		public string DateExpiration{
			set{
				if(value != null && value.Trim().Length != 0)
					dateExpiration = value;
			}
			get => dateExpiration;
		}
		public Donateur(string idDontaur, string prenom, string surnom, string courriel, string telephone, char typeDeCarte, string numeroDeCarte, string dateExpiration) 
		  : base(prenom, surnom){
			  this.idDonateur = idDontaur;
			  this.courriel = courriel;
			  this.telephone = telephone;
			  this.typeDeCarte = typeDeCarte;
			  this.numeroDeCarte = numeroDeCarte;
			  this.dateExpiration = dateExpiration;
		  }
		
		public override string ToString(){
			return "Identifiant : " + idDonateur + ", " + base.ToString();
		}
		public string getId()
        {
			return idDonateur;
        }
	}
}