using System;
using System.Collections.Generic;
using System.Linq;

namespace GestionBibliothèque {
    public abstract class Document {
        private static int compteur = 0; 
        public int NumeroEnregistrement { get; private set; }
        public string Titre { get; set; }

        protected Document(string titre) {
            this.NumeroEnregistrement = ++compteur; // Auto-increment
            this.Titre = titre;
        }

        public abstract string Description();

        public override string ToString() {
            return $"ID: {NumeroEnregistrement} , {Titre}";
        }
    }

    public class Livre : Document {
        public string Auteur { get; set; }
        public int NombrePages { get; set; }

        public Livre(string titre, string auteur, int nombrePages) : base(titre) {
            Auteur = auteur;
            NombrePages = nombrePages;
        }

        public override string Description() {
            return $"Livre : {base.ToString()}, Auteur: {Auteur}, Pages: {NombrePages}";
        }
    }

    public class Dictionnaire : Document {
        public string Langue { get; set; }
        public int NombreDefinitions { get; set; }

        public Dictionnaire(string titre, string langue, int nombreDefinitions) : base(titre) {
            Langue = langue;
            NombreDefinitions = nombreDefinitions;
        }

        public override string Description() {
            return $"Dictio : {base.ToString()}, Langue: {Langue}, Définitions: {NombreDefinitions}";
        }
    }

    public class Biblio {
        private List<Document> documents = new List<Document>();

        public void AjouterDocument(Document document) {
            documents.Add(document);
            Console.WriteLine($"Document ajouté : {document}");
        }

        public int CalculerNombreLivres() {
            return documents.OfType<Livre>().Count();
        }

        public void AfficherDictionnaires() {
            Console.WriteLine("\n*** Liste des dictionnaires ***");
            foreach (var dictionnaire in documents.OfType<Dictionnaire>()) {
                Console.WriteLine(dictionnaire.Description());
            }
        }

        public void TousLesAuteurs() {
            Console.WriteLine("\n*** Numéros avec auteurs ***");
            foreach (var document in documents) {
                if (document is Livre livre) {
                    Console.WriteLine($"ID: {livre.NumeroEnregistrement}, Auteur: {livre.Auteur}");
                } else {
                    Console.WriteLine($"ID: {document.NumeroEnregistrement}, Auteur: Non applicable");
                }
            }
        }

        public void ToutesLesDescriptions() {
            Console.WriteLine("\n=== Descriptions de tous document ===");
            foreach (var document in documents) {
                Console.WriteLine(document.Description());
            }
        }
    }

    public class Program {
        public static void Main(string[] args) {
            Biblio biblio = new Biblio();

            biblio.AjouterDocument(new Livre("Livre1", "Amine BK", 96));
            biblio.AjouterDocument(new Dictionnaire("Traduction", "Français", 500));
            biblio.AjouterDocument(new Livre("Hitler", "Amine BK", 328));
            biblio.AjouterDocument(new Dictionnaire("Eng-Ar", "Arabe", 420));

            Console.WriteLine($"\nNombre total de livres : {biblio.CalculerNombreLivres()}");

            biblio.AfficherDictionnaires();

            biblio.TousLesAuteurs();

            biblio.ToutesLesDescriptions();
        }
    }
}