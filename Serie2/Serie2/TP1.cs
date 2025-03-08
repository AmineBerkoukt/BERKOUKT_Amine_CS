using System;
using System.Collections.Generic;

namespace GestionEntreprise {
    public class Employee {
        public string Nom { get; set; }
        public double Salaire { get; set; }
        public string Poste { get; set; }
        public DateTime DateEmbauche { get; set; }

        public Employee(string nom, double salaire, string poste, DateTime dateEmbauche) {
            Nom = nom;
            Salaire = salaire;
            Poste = poste;
            DateEmbauche = dateEmbauche;
        }

        public override string ToString() {
            return $"Nom: {Nom}, Salaire: {Salaire:C}, Poste: {Poste}, Date d'embauche: {DateEmbauche.ToShortDateString()}";
        }
    }

    // Classe GestionEmployes
    public class GestionEmployes {
        private List<Employee> employees = new List<Employee>();

        public void AjouterEmploye(Employee employe) {
            employees.Add(employe);
            Console.WriteLine($"Employé ajouté : {employe.Nom}");
        }

        public void SupprimerEmploye(string nom) {
            var employe = employees.FirstOrDefault(e => e.Nom.Equals(nom, StringComparison.OrdinalIgnoreCase));
            if (employe != null) {
                employees.Remove(employe);
                Console.WriteLine($"Employé supprimé : {nom}");
            } else {
                Console.WriteLine("Employé non trouvé.");
            }
        }

        public double CalculerSalaireTotal() {
            return employees.Sum(e => e.Salaire);
        }

        public double CalculerSalaireMoyen() {
            if (employees.Count == 0) return 0;
            return employees.Average(e => e.Salaire);
        }

        public List<Employee> ObtenirListeEmployes() {
            return employees;
        }
    }

    // Singleton Directeur
    public sealed class Directeur {
        private static readonly Directeur instance = new Directeur();
        private GestionEmployes gestionEmployes;

        private Directeur() { }

        public static Directeur Instance {
            get {
                return instance;
            }
        }

        public void SetGestionEmployes(GestionEmployes gestion) {
            this.gestionEmployes = gestion;
        }

        public double ObtenirSalaireTotal() {
            return gestionEmployes?.CalculerSalaireTotal() ?? 0;
        }

        public double ObtenirSalaireMoyen() {
            return gestionEmployes?.CalculerSalaireMoyen() ?? 0;
        }

        public List<Employee> ObtenirListeEmployes() {
            return gestionEmployes?.ObtenirListeEmployes() ?? new List<Employee>();
        }
    }

    // Programme principal du test :
    /*
    public class Program {
        public static void Main(string[] args) {
            // Création de la gestion des employés
            GestionEmployes gestionEmployes = new GestionEmployes();

            gestionEmployes.AjouterEmploye(new Employee("Alice Dupont", 5000, "Développeur", new DateTime(2020, 1, 15)));
            gestionEmployes.AjouterEmploye(new Employee("Bob Martin", 6000, "Chef de projet", new DateTime(2019, 5, 10)));
            gestionEmployes.AjouterEmploye(new Employee("Charlie Brown", 4500, "Testeur", new DateTime(2021, 3, 20)));

            // Création du directeur (Singleton)
            Directeur directeur = Directeur.Instance;
            directeur.SetGestionEmployes(gestionEmployes);

            // Affichage des informations de l'entreprise via le directeur
            Console.WriteLine("\n=== Informations de l'entreprise ===");
            Console.WriteLine($"Salaire total de l'entreprise : {directeur.ObtenirSalaireTotal():C}");
            Console.WriteLine($"Salaire moyen des employés : {directeur.ObtenirSalaireMoyen():C}");

            Console.WriteLine("\n=== Liste des employés ===");
            foreach (var employe in directeur.ObtenirListeEmployes()) {
                Console.WriteLine(employe);
            }

            // Suppression d'un employé
            gestionEmployes.SupprimerEmploye("Bob Martin");

            // Mise à jour des informations après suppression
            Console.WriteLine("\n=== Informations mises à jour ===");
            Console.WriteLine($"Salaire total de l'entreprise : {directeur.ObtenirSalaireTotal():C}");
            Console.WriteLine($"Salaire moyen des employés : {directeur.ObtenirSalaireMoyen():C}");
        }
    }
    */
}