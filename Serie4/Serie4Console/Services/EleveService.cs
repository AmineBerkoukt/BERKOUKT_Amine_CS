using Serie4Console.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using Serie4Console.Data;

namespace Serie4Console.Services {
    public class EleveService {
        public void AddEleve(Eleve eleve) {
            using (var conn = Database.GetConnection()) {
                conn.Open();
                string query = "INSERT INTO Eleves (Nom, Prenom, Groupe) VALUES (@Nom, @Prenom, @Groupe)";
                using (var cmd = new MySqlCommand(query, conn)) {
                    cmd.Parameters.AddWithValue("@Nom", eleve.Nom);
                    cmd.Parameters.AddWithValue("@Prenom", eleve.Prenom);
                    cmd.Parameters.AddWithValue("@Groupe", eleve.Groupe);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Eleve> GetAllEleves() {
            List<Eleve> eleves = new List<Eleve>();
            using (var conn = Database.GetConnection()) {
                conn.Open();
                string query = "SELECT * FROM Eleves";
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader()) {
                    while (reader.Read()) {
                        eleves.Add(new Eleve {
                            ID = reader.GetInt32("ID"),
                            Nom = reader.GetString("Nom"),
                            Prenom = reader.GetString("Prenom"),
                            Groupe = reader.GetString("Groupe")
                        });
                    }
                }
            }

            return eleves;
        }
    }
}