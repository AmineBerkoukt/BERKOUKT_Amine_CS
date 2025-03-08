using System;
using ENSA.HR;

class Program {
    static void Main() {
        var directeur = Directeur.GetInstance("DIR1", "BK", "Amine", "Bureau_B1");
        directeur.SalaireBase = 40000;
        directeur.PrimesDeplacement = 3000;

        var ens1 = new Enseignant("PROF1", "CK", "Hvss4m", "Burea_B2", "GD1", 20);
        ens1.PrimesDeplacement = 2000;
        ens1.HeuresSupplementaires = 10;

        var admin1 = new Administratif("AD1", "RK", "Lamia", "Bureau_B3", 8000);

        var rh = new RessourcesHumaines();
        rh.AjouterPersonnel(directeur);
        rh.AjouterPersonnel(ens1);
        rh.AjouterPersonnel(admin1);


        //Test groupes & étudiants
        rh.AjouterGroupe("PROF1", "Gp1");
        rh.AjouterGroupe("PROF1", "Gp2");

        rh.AjouterEtudiant("PROF1", "Gp1", new Etudiant("Etd1", "Said", "JAADI", "AP2", 16.5));
        rh.AjouterEtudiant("PROF1", "Gp1", new Etudiant("Etd2", "Mohamed", "BOURKADI", "AP3", 18.0));
        rh.AjouterEtudiant("PROF1", "Gp2", new Etudiant("Etd3", "Lmahjoub", "BOURKABI", "GINF5", 17.2));

        // Test features
        Console.WriteLine("=== Tout profs ===");
        rh.AfficherEnseignants();

        Console.WriteLine("\n=== Details prof ===");
        rh.AfficherEns("ENS001");

        Console.WriteLine("\n=== Details Grp ===");
        rh.AfficherGrp("ENS001", "Groupe1");

        Console.WriteLine("\n=== Flous $$$ ===");
        Console.WriteLine($"Lmodir: {directeur.CalculerSalaire():C}");
        Console.WriteLine($"Prof: {ens1.CalculerSalaire():C}");
        Console.WriteLine($"Admin: {admin1.CalculerSalaire():C}");
    }
}