using System;
using System.Collections.Generic;

public class Programmeur {
    private static int idCounter = 0;
    public int ID { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public int Bureau { get; set; }
    
    public List<Programmeur> programmeurs = new List<Programmeur>();

    public Programmeur(string nom, string prenom, int bureau) {
        ID = idCounter++;
        Nom = nom;
        Prenom = prenom;
        Bureau = bureau;
    }
    
    public void AfficherUn() {
        Console.WriteLine($"{ID}: {Nom.ToUpper()} {Prenom}, Bureau {Bureau}");
    }
    
    public void AfficherTout() {
        foreach (var p in programmeurs) {
            p.AfficherUn();
        }
    }
    
    public void AjouterProgrammeur(Programmeur programmeur) {
        if (programmeur != null && !programmeurs.Contains(programmeur)) {
            programmeurs.Add(programmeur);
        }
    }
    
    public void SupprimerProgrammeur(Programmeur programmeur) {
        if (programmeur != null) {
            programmeurs.Remove(programmeur);
        }
    }

    public bool ChangerBureau(int newBureau) {
        bool bureauAvailable = true;
        foreach (var p in programmeurs) {
            if (p.Bureau == newBureau) {
                bureauAvailable = false;
            }
        }
        
        if (newBureau > 0 && bureauAvailable == true) {
            Bureau = newBureau;
            return true;
        }
        return false;
    }
}