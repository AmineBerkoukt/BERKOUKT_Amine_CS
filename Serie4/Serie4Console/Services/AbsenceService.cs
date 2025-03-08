using Serie4Console.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using Serie4Console.Data;

namespace Serie4Console.Services
{
    public class AbsenceService
    {
        public void AddAbsence(Absence absence)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Absences (Num_semaine, ID, Nbr_absences) VALUES (@NumSemaine, @EleveID, @NbrAbsences) " +
                               "ON DUPLICATE KEY UPDATE Nbr_absences = Nbr_absences + @NbrAbsences";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NumSemaine", absence.NumSemaine);
                    cmd.Parameters.AddWithValue("@EleveID", absence.EleveID);
                    cmd.Parameters.AddWithValue("@NbrAbsences", absence.NbrAbsences);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public int GetAbsencesByWeek(int eleveID, int week)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT Nbr_absences FROM Absences WHERE Num_semaine = @Week AND ID = @EleveID";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Week", week);
                    cmd.Parameters.AddWithValue("@EleveID", eleveID);
                    var result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
        }

        public int GetTotalAbsences(int eleveID)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT SUM(Nbr_absences) FROM Absences WHERE ID = @EleveID";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EleveID", eleveID);
                    var result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
        }
    }
}
