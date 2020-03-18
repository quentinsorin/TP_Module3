using ProjetLinq.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            InitialiserDatas();

            //Affichage de la liste des prénoms des auteurs donc le nom commence par "G"
            var prenomsAuteursParG = ListeAuteurs.Where(a => a.Nom.ToUpper().StartsWith("G")).Select(a => a.Prenom);
            StringBuilder affichageAuteur = new StringBuilder();
            affichageAuteur.Append("Affichage des prénoms des auteurs dont le nom commence par G :");
            affichageAuteur.Append("\n");
            foreach(var prenom in prenomsAuteursParG)
            {
                affichageAuteur.Append("- ");
                affichageAuteur.Append(prenom);
                affichageAuteur.Append("\n");
            }
            Console.WriteLine(affichageAuteur.ToString());

            //Afficher l'auteur ayant écrit le plus de livres
            var auteurAvecLePlusDeLivresEcrits = ListeLivres.GroupBy(l => l.Auteur).OrderByDescending(t => t.Count()).FirstOrDefault().Key;
            StringBuilder affichageAuteurAvecLePlusDeLivresEcrits = new StringBuilder();
            affichageAuteurAvecLePlusDeLivresEcrits.Append("Affichage de l'auteur ayant écrit le plus de livres :");
            affichageAuteurAvecLePlusDeLivresEcrits.Append("\n");
            affichageAuteurAvecLePlusDeLivresEcrits.Append($"- {auteurAvecLePlusDeLivresEcrits.Nom} {auteurAvecLePlusDeLivresEcrits.Prenom}");
            affichageAuteurAvecLePlusDeLivresEcrits.Append("\n");
            Console.WriteLine(affichageAuteurAvecLePlusDeLivresEcrits.ToString());

            //Afficher le nombre moyen de pages par livre par auteur
            var nbPagesMoyenParLivreParAuteur = ListeLivres.GroupBy(l => l.Auteur);
            StringBuilder affichageNbPagesMoyensParLivreParAuteur = new StringBuilder();
            affichageNbPagesMoyensParLivreParAuteur.Append("Affichage du nombre moyen de pages par livre par auteur :");
            affichageNbPagesMoyensParLivreParAuteur.Append("\n");
            foreach(var item in nbPagesMoyenParLivreParAuteur)
            {
                affichageNbPagesMoyensParLivreParAuteur.Append($"- {item.Key.Prenom} {item.Key.Nom} nb moyen de pages={item.Average(l => l.NbPages)}");
                affichageNbPagesMoyensParLivreParAuteur.Append("\n");
            }
            Console.WriteLine(affichageNbPagesMoyensParLivreParAuteur.ToString());

            //Afficher le titre du livre avec le plus de pages
            var titreLivreAvecLePlusDePages = ListeLivres.OrderByDescending(l => l.NbPages).First();
            StringBuilder affichageTitreLivreAvecLePlusDePages = new StringBuilder();
            affichageTitreLivreAvecLePlusDePages.Append("Affichage du titre du livre ayant le plus de pages :");
            affichageTitreLivreAvecLePlusDePages.Append("\n");
            affichageTitreLivreAvecLePlusDePages.Append($"- {titreLivreAvecLePlusDePages.Titre}");
            affichageTitreLivreAvecLePlusDePages.Append("\n");
            Console.WriteLine(affichageTitreLivreAvecLePlusDePages.ToString());

            //Afficher combien ont gagné les auteurs en moyenne (moyenne des factures) 
            var moyenneGainAuteurs = ListeAuteurs.Average(a => a.Factures.Sum(f => f.Montant));
            StringBuilder affichageMoyenneGainAuteurs = new StringBuilder();
            affichageMoyenneGainAuteurs.Append("Affichage de la moyenne des gains des auteurs :");
            affichageMoyenneGainAuteurs.Append("\n");
            affichageMoyenneGainAuteurs.Append("- " + moyenneGainAuteurs);
            affichageMoyenneGainAuteurs.Append("\n");
            Console.WriteLine(affichageMoyenneGainAuteurs.ToString());

            //Afficher les auteurs et la liste de leurs livres 
            var livresparAuteurs = ListeLivres.GroupBy(l => l.Auteur);
            StringBuilder affichageAuteursEtListeLivres = new StringBuilder();
            affichageAuteursEtListeLivres.Append("Affichage des auteurs et la liste de leurs livres :");
            affichageAuteursEtListeLivres.Append("\n");
            foreach (var livres in livresparAuteurs)
            {
                affichageAuteursEtListeLivres.Append($"- Auteur : {livres.Key.Prenom} {livres.Key.Nom} ");
                affichageAuteursEtListeLivres.Append("\n");

                foreach (var livre in livres)
                {
                    affichageAuteursEtListeLivres.Append($" - {livre.Titre}");
                    affichageAuteursEtListeLivres.Append("\n");
                }
                affichageAuteursEtListeLivres.Append("\n");
            }
            affichageAuteursEtListeLivres.Append("\n");
            Console.WriteLine(affichageAuteursEtListeLivres.ToString());

            //Afficher les titres de tous les livres triés par ordre alphabétique 
            var livresTriesAlphabetique = ListeLivres.OrderBy(t => t.Titre).ToList();
            StringBuilder affichageLivreParOrdreAlphabétique = new StringBuilder();
            affichageLivreParOrdreAlphabétique.Append("Affichage des titres de tous les livres triés par ordre alphabétique :");
            affichageLivreParOrdreAlphabétique.Append("\n");
            foreach(var livreTrie in livresTriesAlphabetique)
            {
                affichageLivreParOrdreAlphabétique.Append($"- {livreTrie.Titre}");
                affichageLivreParOrdreAlphabétique.Append("\n");
            }
            affichageLivreParOrdreAlphabétique.Append("\n");
            Console.WriteLine(affichageLivreParOrdreAlphabétique.ToString());

            //Afficher la liste des livres dont le nombre de pages est supérieur à la moyenne 
            StringBuilder affichageListeLivre = new StringBuilder();
            affichageListeLivre.Append("Affichage de la liste des livres dont le nombre de page est supérieur à la moyenne :");
            affichageListeLivre.Append("\n");
            var moyennePages = ListeLivres.Average(l => l.NbPages);
            var livresPagesSuperieuresMoyenne = ListeLivres.Where(l => l.NbPages > moyennePages);
            foreach (var livre in livresPagesSuperieuresMoyenne)
            {
                affichageListeLivre.Append($"- {livre.Titre}");
                affichageListeLivre.Append("\n");
            }
            affichageListeLivre.Append("\n");
            Console.WriteLine(affichageListeLivre.ToString());

            //Afficher l'auteur ayant écrit le moins de livres 
            var auteurMoinsDeLivres = ListeAuteurs.OrderBy(a => ListeLivres.Count(l => l.Auteur == a)).FirstOrDefault();
            StringBuilder affichageAuteurAvecLeMoinsDeLivresEcrits = new StringBuilder();
            affichageAuteurAvecLeMoinsDeLivresEcrits.Append("Affichage de l'auteur ayant écrit le moins de livres :");
            affichageAuteurAvecLeMoinsDeLivresEcrits.Append("\n");
            affichageAuteurAvecLeMoinsDeLivresEcrits.Append($"{auteurMoinsDeLivres.Prenom} {auteurMoinsDeLivres.Nom}");
            Console.WriteLine(affichageAuteurAvecLeMoinsDeLivresEcrits.ToString());

            Console.ReadKey();
        }

        private static readonly List<Auteur> ListeAuteurs = new List<Auteur>();
        private static readonly List<Livre> ListeLivres = new List<Livre>();

        private static void InitialiserDatas()
        {
            ListeAuteurs.Add(new Auteur("GROUSSARD", "Thierry"));
            ListeAuteurs.Add(new Auteur("GABILLAUD", "Jérôme"));
            ListeAuteurs.Add(new Auteur("HUGON", "Jérôme"));
            ListeAuteurs.Add(new Auteur("ALESSANDRI", "Olivier"));
            ListeAuteurs.Add(new Auteur("de QUAJOUX", "Benoit"));
            ListeLivres.Add(new Livre(1, "C# 4", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 533));
            ListeLivres.Add(new Livre(2, "VB.NET", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 539));
            ListeLivres.Add(new Livre(3, "SQL Server 2008", "SQL, Transact SQL", ListeAuteurs.ElementAt(1), 311));
            ListeLivres.Add(new Livre(4, "ASP.NET 4.0 et C#", "Sous visual studio 2010", ListeAuteurs.ElementAt(3), 544));
            ListeLivres.Add(new Livre(5, "C# 4", "Développez des applications windows avec visual studio 2010", ListeAuteurs.ElementAt(2), 452));
            ListeLivres.Add(new Livre(6, "Java 7", "les fondamentaux du langage", ListeAuteurs.ElementAt(0), 416));
            ListeLivres.Add(new Livre(7, "SQL et Algèbre relationnelle", "Notions de base", ListeAuteurs.ElementAt(1), 216));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3500, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3200, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(1).addFacture(new Facture(4000, ListeAuteurs.ElementAt(1)));
            ListeAuteurs.ElementAt(2).addFacture(new Facture(4200, ListeAuteurs.ElementAt(2)));
            ListeAuteurs.ElementAt(3).addFacture(new Facture(3700, ListeAuteurs.ElementAt(3)));
        }

    }
}
