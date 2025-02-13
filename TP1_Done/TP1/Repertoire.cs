using System;

class Repertoire {
    string Name { get; set; } = "NoName";
    int Nbr_Fichiers { get; set; } = 0;
    Fichier[] Fichiers { get; set; } = new Fichier[30];

    public Repertoire(string name, int nbrFichiers)
    {
        Name = name;
        Nbr_Fichiers = nbrFichiers;
    }

    public void Afficher() {
        Console.WriteLine("Dir name : " + Name + "Its files : ");
        for (int i = 0; i < Nbr_Fichiers; i++) {
            Console.WriteLine(Fichiers[i].Name + "." + Fichiers[i].Extension + " : " + Fichiers[i].Taille);
        }
    }

    public int Rechercher(string fileToFindName) {
        for (int i = 0; i < Nbr_Fichiers; i++) {
            if (Fichiers[i].Name == fileToFindName){
                return i;
            }
        }
        return -1;
    }

    public void Ajouter(Fichier fileToAdd) {
        if (Fichiers != null) {
            if (Nbr_Fichiers == 30){
                Console.WriteLine("Directory is full !");
                return;
            }
            
            Fichiers[Nbr_Fichiers++] = fileToAdd;
        }
    }
    
    public Fichier[] Rechercher() {
        Fichier[] PDFs = new Fichier[Nbr_Fichiers];
        int localIndex = 0;
        for (int i = 0; i < Nbr_Fichiers; i++) {
            if (Fichiers[i].Extension == "pdf"){
                PDFs[localIndex] = Fichiers[i];
                localIndex++;
            }
        }
        return PDFs;
    }

    public void Supprimer(string fileToRemoveName) {
        int fileToRemoveIndex = Rechercher(fileToRemoveName);
        if (fileToRemoveIndex == -1) {
            Console.WriteLine("File does NOT exist !");
            return;
        }

        if (fileToRemoveIndex == Nbr_Fichiers - 1) {
            Fichiers[fileToRemoveIndex] = null;
            Nbr_Fichiers--;
            return;
        }

        for (int j = fileToRemoveIndex; j < Nbr_Fichiers - 1; j++) {
            Fichiers[j] = Fichiers[j + 1];
        }

        Fichiers[Nbr_Fichiers - 1] = null; // Clear the last element or it will be duplicated !
        Nbr_Fichiers--;
    }

    public void Renommer(string oldName, string newName) {
        int fileIndex = Rechercher(oldName);
        if (fileIndex == -1) {
            Console.WriteLine("File doesn't exist !");
            return;
        }
        Fichiers[fileIndex].Name = newName;
    }

    public void Modifier(String fileName, float newSize) {
        int fileIndex = Rechercher(fileName);
        if (fileIndex == -1) {
            Console.WriteLine("File doesn't exist !");
            return;
        }
        Fichiers[fileIndex].Taille = newSize;
    }

    public float getTaille() {
        if (Nbr_Fichiers == 0) {
            Console.WriteLine("No files in this dir");
            return -1;
        }
        if (Fichiers == null) {
            Console.WriteLine("Error in this dir !");
            return -1;
        }

        float dirSizeKO = 0.0f;
        for (var i = 0; i < Nbr_Fichiers; i++) {
            dirSizeKO += Fichiers[i].Taille;
        }
        float dirSizeMO = (float) dirSizeKO / 1000;
        
        return dirSizeMO;
    }
}