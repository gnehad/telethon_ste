using System;
using System.Collections.Generic;
namespace Modele{
	public class GestionnaireSTE{
	  private List<Donateur> donateurs;
	  private List<Commanditaire> commanditaires;
	  static private List<Don> lesDons = new List<Don>();
	  private List<Prix> lesPrix;

      //Dictionnaire qui assure le lien entre un donateur et le prix qu'il a gagn�
	  private Dictionary<string, string> prixGagnes;
	  public GestionnaireSTE()
        {
			donateurs = new List<Donateur>();
			commanditaires = new List<Commanditaire>();	
			lesPrix = new List<Prix>();
			prixGagnes = new Dictionary<string, string>();

        }
	  public List<Donateur> getDonateurs() { return donateurs; }
	  public List<Commanditaire> getCommanditaires() { return commanditaires; }
	  public List<Don> getDons() { return lesDons; }
	  public List<Prix> getPrix() { return lesPrix; }
	  public Dictionary<string, string> getPrixGagnes() { return prixGagnes; }
		public void ajouterDonateur(string idDonateur, string prenom, string surnom, string courriel, string telephone, char typeDeCarte, string numeroDeCarte, string dateExpiration)
        {

			Donateur donateur = new Donateur(idDonateur, prenom, surnom, courriel, telephone, typeDeCarte, numeroDeCarte, dateExpiration);
			donateurs.Add(donateur);
		}
	  public void ajouterCommanditaire(string idCommanditaire, string prenom, string surnom)
        {
			Commanditaire commanditaire = new Commanditaire(idCommanditaire, prenom, surnom);
			commanditaires.Add(commanditaire);
        }
	  public void ajouterPrix(string idPrix, string description, double valeur, int qnteOriginale, int qnteDisponible, string idCommanditaire)
        {
			Prix prix = new Prix(idPrix, description, valeur, qnteOriginale, qnteDisponible, idCommanditaire);
			lesPrix.Add(prix);

        }
	  public void ajouterDon(string idDon, string dateDuDon, string idDonateur, double montantDuDon)
        {

			Don don = new Don(idDon, dateDuDon, idDonateur, montantDuDon);
			lesDons.Add(don);

        }
		public string afficherDonateurs()
        {
			string sortie = "";
			foreach (Donateur donateur in donateurs)
				sortie += donateur.ToString();
			return sortie;
        }
		public string afficherPrix()
		{
			string sortie = "";
			foreach (Prix prix in lesPrix)
				sortie += prix.ToString();
			return sortie;
		}

		public string afficherCommanditaires()
		{
			string sortie = "";
			foreach (Commanditaire commanditaire in commanditaires)
				sortie += commanditaire.ToString();
			return sortie;
		}
		public string afficherDons()
		{
			string sortie = "";
			foreach (Don don in lesDons)
				sortie += don.ToString();
			return sortie;
		}
		/*
		 * Cette m�thode effectue l'attribution d'un prix pour un donateur selon la valeur du 
		 * don qu'il a effectu�. 
		 * La m�thode attribue un seul prix au donateur peu importe le montant de son don 
		 */
		public string attribuerPrix(double montant)
        {
			string prix = ""; //chaine vide pour indiquer que le donateur n'a pas gnagn� de prix
			if(montant > 50)
            {
				prix = "Prix gagn� : \n";
				//On d�termine d'abord les points correspondant au montant donn� par le donateur
				int nbPoints = ((int)montant / 500) * 5;
				int reste = (int)montant % 500;
				if (reste >= 50 && reste <= 199)
					nbPoints += 1;
				else if (reste >= 200 && reste <= 349)
					nbPoints += 2;
				else if (reste >= 350 && reste <= 499)
					nbPoints += 3;
				//On d�termine le prix gagn� pour le donateur
				if (nbPoints >= 20)
                {
					prix = "T�l�viseur";
				}	
				else if (nbPoints >= 15 && nbPoints < 20)
                {
					prix = "BBQ";
				}
				else if (nbPoints >= 10 && nbPoints < 15)
                {
					prix = "Repas pour deux";
				}
					
				else if (nbPoints >= 1)
                {
					prix = "Calendrier";
				}
			}
			//On met � jour la quantit� disponible pour le prix si le donateur en a gagn� un
			if(!prix.Equals(""))
				updateQuantitePrix(prix);
			return prix;
		}
		/*
		 * M�thode qui recherche un donateur dans la liste des donateurs. Elle renvoie true si 
		 * le donateur figure d�j� dans la liste, false sinon
		 */
		public bool trouverDonateur(string surnom, string prenom)
        {
			bool trouve = false;
			for (int i = 0; i < donateurs.Count; i++)
			{
				if (donateurs[i].Surnom.ToUpper().Equals(surnom.ToUpper()) && donateurs[i].Prenom.ToUpper().Equals(prenom.ToUpper()))
					trouve = true;
			}
			return trouve;
        }
		/*M�thode renvoyant le nombre de donateurs dans la liste. Ce nombre servia pour la
		 * g�n�ration de l'identfiant du nouveau donateur
		*/
		public int getCountDonateurs()
        {
			return donateurs.Count;
        }
		/*M�thode renvoyant le nombre de dons dans la liste. Ce nombre servia pour la
	    * g�n�ration de l'identfiant du nouveau don
	    */
		public int getCountDons()
        {
			return lesDons.Count;
        }
		/*M�thode renvoyant le nombre de commanditaires dans la liste. Ce nombre servia pour la
	    * g�n�ration de l'identfiant du nouveau commanditaire
	    */
		public int getCountCommanditaires()
        {
			return commanditaires.Count;
        }

		/*M�thode renvoyant le nombre de prix dans la liste. Ce nombre servia pour la
	    * g�n�ration de l'identfiant du nouveau prix
	    */
		public int getCountPrix()
        {
			return lesPrix.Count;
        }

		/*M�thode pour calculer le total des dons. Ce total va �tre utilis� mettre
		 * � jour la barre de progression pour l'avancement de la collecte.
		 */
		public static double calculerTotalDons()
        {
			double total = 0.0;
			foreach (Don don in lesDons)
				total += don.MontantDuDon;
			return total;
        }
		/* M�thode pour mettre � jour la quantit� disponible pour un prix. Elle est 
		 * automatiquement appel� � chaque fois qu'un donateur gagne un prix
		 */
		public void updateQuantitePrix(string prix)
        {
			foreach (Prix p in lesPrix)
			{
				if (p.Description.Equals(prix))
					p.QnteDisponible--;
			}
		}
	}
}