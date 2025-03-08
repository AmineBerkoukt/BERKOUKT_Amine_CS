using System;
namespace ENSA.HR
{
    public interface IRessourcesHumaines
    {
        void AfficherEnseignants();
        int RechercherEns(string code);
        void AjouterEtudiant(string codeEnseignant, string nomGroupe, Etudiant etudiant);
        void AjouterGroupe(string codeEnseignant, string nomGroupe);
        void AfficherGrp(string codeEnseignant, string nomGroupe);
        void AfficherEtd(Etudiant etudiant);
        void AfficherEns(string codeEnseignant);
    }
}