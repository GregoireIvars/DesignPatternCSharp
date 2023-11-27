using System;
using System.Collections.Generic;

namespace myBuilder
{
  
    public class BonDeCommande
    {
        public string Details { get; set; }
    }

    public class DemandeImmatriculation
    {
        public string Details { get; set; }
    }

    public interface IConstructeurLiasseVehicule
    {
        void ConstruitBonDeCommande();
        void ConstruitDemandeImmatriculation();
        List<object> GetLiasse();
    }

    public class ConstructeurLiasseVehiculePdf : IConstructeurLiasseVehicule
    {
        private List<object> liasse = new List<object>();

        public void ConstruitBonDeCommande()
        {
            liasse.Add(new BonDeCommande());
        }

        public void ConstruitDemandeImmatriculation()
        {
            liasse.Add(new DemandeImmatriculation());
        }

        public List<object> GetLiasse()
        {
            return liasse;
        }
    }

    public class ConstructeurLiasseVehiculeHtml : IConstructeurLiasseVehicule
    {
        private List<object> liasse = new List<object>();

        public void ConstruitBonDeCommande()
        {
            liasse.Add(new BonDeCommande());
        }

        public void ConstruitDemandeImmatriculation()
        {
            liasse.Add(new DemandeImmatriculation());
        }

        public List<object> GetLiasse()
        {
            return liasse;
        }
    }

 
    public class Vendeur
    {
        public void Construit(IConstructeurLiasseVehicule constructeur)
        {
            constructeur.ConstruitBonDeCommande();
            constructeur.ConstruitDemandeImmatriculation();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Vendeur vendeur = new Vendeur();
            string choix;

            do
            {
                Console.WriteLine("Choisissez le format de la liasse (PDF / HTML) ou 'exit' pour quitter : ");
                choix = Console.ReadLine().ToLower();

                if (choix == "pdf")
                {
                    IConstructeurLiasseVehicule constructeurPdf = new ConstructeurLiasseVehiculePdf();
                    vendeur.Construit(constructeurPdf);
                    List<object> liassePdf = constructeurPdf.GetLiasse();
                    Console.WriteLine("Liasse PDF créée avec succès.");
                }
                else if (choix == "html")
                {
                    IConstructeurLiasseVehicule constructeurHtml = new ConstructeurLiasseVehiculeHtml();
                    vendeur.Construit(constructeurHtml);
                    List<object> liasseHtml = constructeurHtml.GetLiasse();
                    Console.WriteLine("Liasse HTML créée avec succès.");
                }
                else if (choix != "exit")
                {
                    Console.WriteLine("Format non valide. Veuillez choisir PDF ou HTML.");
                }

            } while (choix != "exit");

            Console.WriteLine("Programme terminé.");
            Console.ReadKey();
        }
    }
}