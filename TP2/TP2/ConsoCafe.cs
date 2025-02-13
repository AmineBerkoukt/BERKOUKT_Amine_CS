using System;

public class ConsoCafe {
    public int NoSemaine { get; set; }
    public Programmeur Programmeur { get; set; }
    public int NbTasses { get; set; } = 0;
    
    public List<ConsoCafe> consoCafe = new List<ConsoCafe>();


    public ConsoCafe(int noSemaine, Programmeur programmeur, int nbTasses) {
        NoSemaine = noSemaine;
        Programmeur = programmeur;
        NbTasses = nbTasses;
    }

    public void AfficherTotalConso() {
        int totalTasses = 0;
        foreach (var c in consoCafe) {
            totalTasses += c.NbTasses;
        }

        Console.WriteLine("Le nombre total des tasses est : " + totalTasses);
    }
    
    
}