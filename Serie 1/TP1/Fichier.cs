using System;

class Fichier {
    public string Name { get; set; } = "NoName";
    public string Extension { get; set; } = "NoExtension";
    public float Taille { get; set; } = 0.0f;

    public Fichier(string name, string extension, float taille) {
        Name = name; Extension = extension; Taille = taille;
    }
}