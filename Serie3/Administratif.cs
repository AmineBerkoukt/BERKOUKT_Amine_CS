namespace ENSA.HR {
    public class Administratif : Personnel {
        public double SalaireFixe { get; set; }

        public Administratif(string code, string nom, string prenom, string bureau, double salaireFixe)
            : base(code, nom, prenom, bureau) {
            SalaireFixe = salaireFixe;
        }

        public override double CalculerSalaire() {
            return SalaireFixe;
        }
    }
}