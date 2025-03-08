using System;
using System.Collections.Generic;
using ENSA.HR;


public class RessourcesHumaines : IRessourcesHumaines {
    private List<Personnel> toutesRH = new List<Personnel>();

    public void AjouterPersonnel(Personnel personnel) => toutesRH.Add(personnel);

    public void AfficherEnseignants() {
        foreach (var p in toutesRH) {
            if (p is Enseignant ens) {
                Console.WriteLine($"Enseignant: {ens.Nom} {ens.Prenom} ({ens.Code})");
                foreach (var g in ens.GetGroupes()) {
                    Console.WriteLine($"- Groupe {g.Key} ({g.Value.Etudiants.Count} étudiants)");
                }
            }
        }
    }

    public int RechercherEns(string code) {
        for (int i = 0; i < toutesRH.Count; i++)
            if (toutesRH[i] is Enseignant ens && ens.Code == code)
                return i; //Retourne l'indice de l'ens
        return -1;
    }

    public void AjouterEtudiant(string codeEnseignant, string nomGroupe, Etudiant etudiant) {
        var ens = toutesRH.Find(p => p is Enseignant e && e.Code == codeEnseignant) as Enseignant;
        ens?.AjouterEtudiant(nomGroupe, etudiant);
    }

    public void AjouterGroupe(string codeEnseignant, string nomGroupe) {
        var ens = toutesRH.Find(p => p is Enseignant e && e.Code == codeEnseignant) as Enseignant;
        ens?.AjouterGroupe(nomGroupe);
    }

    public void AfficherGrp(string codeEnseignant, string nomGroupe) {
        var ens = toutesRH.Find(p => p is Enseignant e && e.Code == codeEnseignant) as Enseignant;
        if (ens != null && ens.GetGroupes().TryGetValue(nomGroupe, out Groupe groupe)) {
            Console.WriteLine($"Groupe {nomGroupe}:");
            groupe.Etudiants.ForEach(e => AfficherEtd(e));
        }
    }

    public void AfficherEtd(Etudiant etudiant) =>
        Console.WriteLine($"- {etudiant.Nom} {etudiant.Prenom} ({etudiant.Niveau}, Moy: {etudiant.MoyenneAnnuelle})");

    public void AfficherEns(string codeEnseignant) {
        var ens = toutesRH.Find(p => p is Enseignant e && e.Code == codeEnseignant) as Enseignant;
        if (ens != null) {
            Console.WriteLine($"Enseignant {ens.Nom} {ens.Prenom}:");
            Console.WriteLine($"Grade: {ens.Grade}, Salaire: {ens.CalculerSalaire():C}");
            foreach (var g in ens.GetGroupes())
                Console.WriteLine($"- Groupe {g.Key}: {g.Value.Etudiants.Count} étudiants");
        }
    }
}