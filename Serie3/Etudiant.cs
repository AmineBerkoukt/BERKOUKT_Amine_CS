namespace ENSA.HR
{
    public class Etudiant : Person
    {
        public string Niveau { get; set; }
        public double MoyenneAnnuelle { get; set; }

        public Etudiant(string code, string nom, string prenom, string niveau, double moyenne)
            : base(code, nom, prenom)
        {
            Niveau = niveau;
            MoyenneAnnuelle = moyenne;
        }
    }
}