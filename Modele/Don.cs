using System;
namespace Modele{
	public class Don{
		private string idDon;
		private string dateDuDon;
		public string DateDuDon{
			set{
				if(value != null && value.Trim().Length != 0)
					dateDuDon = value;
			}
			get => dateDuDon;
		}
		private string idDonateur;
		private double montantDuDon;
		public double MontantDuDon{
			set{
				if(value > 0)
					montantDuDon = value;
			}
			get => montantDuDon;
		}
		public Don(){}
		public Don(string idDon, string dateDuDon, string idDonateur, double montantDuDon){
			this.idDon = idDon;
			this.dateDuDon = dateDuDon;
			this.montantDuDon = montantDuDon;
			this.idDonateur = idDonateur;	
		}

		public override string ToString(){
			return "Identifiant : " + idDon + 
			       ", Date : " + dateDuDon + 
				   ", Identifiant du donateur : " + idDonateur + 
				   ", Montant " + montantDuDon;
		}

	}
}