using Serie4Console.Models;
using Serie4Console.Services;
using System;

namespace Serie4Console
{
    class Program
    {
        static void Main()
        {
            EleveService eleveService = new EleveService();
            AbsenceService absenceService = new AbsenceService();

            // Add students
            var student1 = new Eleve { Nom = "Doe", Prenom = "John", Groupe = "Group A" };
            var student2 = new Eleve { Nom = "Smith", Prenom = "Jane", Groupe = "Group B" };
            eleveService.AddEleve(student1);
            eleveService.AddEleve(student2);

            // Display all students
            Console.WriteLine("All Students:");
            var students = eleveService.GetAllEleves();
            foreach (var student in students)
            {
                Console.WriteLine($"{student.ID}: {student.Nom} {student.Prenom} - {student.Groupe}");
            }

            // Add absences
            absenceService.AddAbsence(new Absence { EleveID = student1.ID, NumSemaine = 1, NbrAbsences = 3 });
            absenceService.AddAbsence(new Absence { EleveID = student1.ID, NumSemaine = 2, NbrAbsences = 2 });
            absenceService.AddAbsence(new Absence { EleveID = student2.ID, NumSemaine = 1, NbrAbsences = 1 });

            // Get total absences
            Console.WriteLine($"\nTotal Absences for {student1.Nom}: {absenceService.GetTotalAbsences(student1.ID)}");
            Console.WriteLine($"Total Absences for {student2.Nom}: {absenceService.GetTotalAbsences(student2.ID)}");

            // Get absences by week
            Console.WriteLine($"\nWeekly Absences for {student1.Nom}, Week 1: {absenceService.GetAbsencesByWeek(student1.ID, 1)}");
            Console.WriteLine($"Weekly Absences for {student1.Nom}, Week 2: {absenceService.GetAbsencesByWeek(student1.ID, 2)}");
            Console.WriteLine($"Weekly Absences for {student2.Nom}, Week 1: {absenceService.GetAbsencesByWeek(student2.ID, 1)}");
        }
    }
}