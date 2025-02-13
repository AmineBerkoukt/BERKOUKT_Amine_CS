using System;
using System.Collections.Generic;

class Program {
    static void Main() {
        Programmeur p1 = new Programmeur("Amine", "Bk", 101);
        Programmeur p2 = new Programmeur("Lamia", "Rk", 102);

        p1.AfficherUn();
        p2.AfficherUn();

        p1.AjouterProgrammeur(p2);
        p1.AfficherTout();

        bool changed = p2.ChangerBureau(103);
        Console.WriteLine($"Bureau changed result : {changed}");
        p2.AfficherUn();

        ConsoCafe c1 = new ConsoCafe(1, p1, 5);
        ConsoCafe c2 = new ConsoCafe(1, p2, 7);

        c1.consoCafe.Add(c1);
        c1.consoCafe.Add(c2);
        
        c1.AfficherTotalConso();
    }
}