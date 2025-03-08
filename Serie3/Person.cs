namespace ENSA.HR {
    public abstract class Person {
        public string Code { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        protected Person(string code, string nom, string prenom) {
            Code = code;
            Nom = nom;
            Prenom = prenom;
        }
    }
}