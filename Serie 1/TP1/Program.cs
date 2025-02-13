using System;

class Program
{
    static void Main(string[] args)
    {
        Repertoire myDirectory = new Repertoire("My Documents", 0);

        Fichier file1 = new Fichier("Report", "pdf", 2500);
        Fichier file2 = new Fichier("Image", "jpg", 1200);
        Fichier file3 = new Fichier("Presentation", "pptx", 3800);
        Fichier file4 = new Fichier("Text", "txt", 50);
        Fichier file5 = new Fichier("AnotherReport", "pdf", 1800);


        myDirectory.Ajouter(file1);
        myDirectory.Ajouter(file2);
        myDirectory.Ajouter(file3);
        myDirectory.Ajouter(file4);
        myDirectory.Ajouter(file5);
        



        myDirectory.Afficher();
        Console.WriteLine($"Index of Image file: {myDirectory.Rechercher("Image")}");

        Fichier[] pdfFiles = myDirectory.Rechercher();
        Console.WriteLine("\nPDF Files:");
        foreach (var file in pdfFiles)
        {
            if (file != null) // Check for nulls as the array might have empty slots
            {
                Console.WriteLine(file.Name + "." + file.Extension);
            }
        }

        myDirectory.Supprimer("Text");
        Console.WriteLine("\nDirectory after deleting Text file:");
        myDirectory.Afficher();

        myDirectory.Renommer("Image", "NewImage");
        Console.WriteLine("\nDirectory after renaming Image to NewImage:");
        myDirectory.Afficher();

        myDirectory.Modifier("NewImage", 1500);
        Console.WriteLine("\nDirectory after modifying NewImage size:");
        myDirectory.Afficher();

        Console.WriteLine($"\nTotal directory size: {myDirectory.getTaille()} MB");
    }
}