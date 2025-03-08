using System;
using System.Collections.Generic;

namespace ENSA.HR {
    public class Enseignant : Personnel {
        private Dictionary<string, Groupe> _groupes = new Dictionary<string, Groupe>();
        public string Grade { get; set; }
        public int VolumeHoraire { get; set; }
        public double PrimesDeplacement { get; set; }
        public int HeuresSupplementaires { get; set; }

        public Enseignant(string code, string nom, string prenom, string bureau, string grade, int volumeHoraire)
            : base(code, nom, prenom, bureau) {
            Grade = grade;
            VolumeHoraire = volumeHoraire;
        }

        public Groupe this[string nomGroupe] {
            get => _groupes[nomGroupe];
            set => _groupes[nomGroupe] = value;
        }

        public void AjouterGroupe(string nomGroupe) {
            if (!_groupes.ContainsKey(nomGroupe))
                _groupes.Add(nomGroupe, new Groupe(nomGroupe));
        }

        public Dictionary<string, Groupe> GetGroupes() => new Dictionary<string, Groupe>(_groupes);

        public override double CalculerSalaire() {
            double taux = Grade switch {
                "PA" => 300,
                "PH" => 350,
                "PES" => 400,
                _ => throw new InvalidOperationException("Invalid grade")
            };
            return (VolumeHoraire * taux) + PrimesDeplacement + (HeuresSupplementaires * taux);
        }

        public void AjouterEtudiant(string nomGroupe, Etudiant etudiant) {
            if (_groupes.ContainsKey(nomGroupe)) {
                _groupes[nomGroupe].AjouterEtudiant(etudiant);
            }
            else {
                Console.WriteLine($"Erreur: Le groupe {nomGroupe} n'existe pas!");
            }
        }
    }
}