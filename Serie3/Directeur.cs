using System;

namespace ENSA.HR {
    public sealed class Directeur : Personnel {
        private static Directeur instance;
        public double SalaireBase { get; set; }
        public double PrimesDeplacement { get; set; }

        private Directeur(string code, string nom, string prenom, string bureau)
            : base(code, nom, prenom, bureau) {
        }

        public static Directeur GetInstance(string code, string nom, string prenom, string bureau) {
            if (instance == null) {
                instance = new Directeur(code, nom, prenom, bureau);
            }
            else {
                Console.WriteLine("Erreur : Un seul directeur existe deja !");
            }

            return instance;
        }

        public override double CalculerSalaire() {
            return SalaireBase + PrimesDeplacement;
        }
    }
}