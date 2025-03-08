namespace ENSA.HR {
    public abstract class Personnel : Person {
        public string Bureau { get; set; }

        protected Personnel(string code, string nom, string prenom, string bureau)
            : base(code, nom, prenom) {
            Bureau = bureau;
        }

        public abstract double CalculerSalaire();
    }
}