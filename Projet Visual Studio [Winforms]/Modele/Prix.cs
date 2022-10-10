using System;
namespace Modele{
	public class Prix{
		private string idPrix;
		private string description;
		public string Description{
			set{
				if(value != null && value.Trim().Length != 0)
					description = value;
			}
			get => description;
		}
		private double valeur;
		public double Valeur{
			set{
				if(value > 0)
					valeur = value;
			}
			get => valeur;
		}
		private int qnteOriginale;
		public int QnteOriginale{
			set{
				if(value > 0)
					qnteOriginale = value;
			}
			get => qnteOriginale;
		}
		private int qnteDisponible;
		public int QnteDisponible{
			set{
				if(value > 0)
					qnteDisponible = value;
			}
			get => qnteDisponible;
		}
		private string idCommanditaire;
		public override string ToString(){
			return "Identifiant : " + idPrix + 
			       ", Description : " + description + 
				   ", Valeur : " + valeur + 
				   ", Quantité originale : " + qnteOriginale + 
				   ", Quantité disponible : " + qnteDisponible + 
				   ", Identifiant du commanditaire : " + idCommanditaire;
		}
		public Prix(string idPrix, string description, double valeur, int qnteOriginale, int qnteDisponible, string idCommanditaire)
        {
			this.idPrix = idPrix;
			this.description = description;
			this.valeur = valeur;
			this.idCommanditaire =	idCommanditaire;
			this.qnteOriginale = qnteOriginale;
			this.qnteDisponible=qnteDisponible;
        }
		public void deduire(int quantite){
			qnteDisponible = qnteOriginale - quantite;
		}
		public string getId()
        {
			return idPrix;
        }
		public string getIdCommanditaire()
        {
			return idCommanditaire;
        }
	}
}