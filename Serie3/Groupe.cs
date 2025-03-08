using System.Collections.Generic;

namespace ENSA.HR
{
    public class Groupe
    {
        private string _nom;
        private List<Etudiant> _etudiants = new List<Etudiant>();

        public Groupe(string nom) => _nom = nom;

        public string Nom => _nom;
        public List<Etudiant> Etudiants => new List<Etudiant>(_etudiants);

        public void AjouterEtudiant(Etudiant etudiant) => _etudiants.Add(etudiant);
    }
}