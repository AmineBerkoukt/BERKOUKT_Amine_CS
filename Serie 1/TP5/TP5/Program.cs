using System;
using TP5;

public class Program {
    public static void Main(string[] args) {
        while (true) {
            Console.Clear();
            Console.WriteLine("===================================");
            Console.WriteLine("Bienvenue dans le système bancaire !");
            Console.WriteLine("===================================");
            Console.WriteLine("1) Créer un nouveau compte");
            Console.WriteLine("2) Rechercher un compte existant");
            Console.WriteLine("3) Supprimer un compte");
            Console.WriteLine("4) Effectuer une opération sur un compte");
            Console.WriteLine("5) Afficher la liste de tous les comptes");
            Console.WriteLine("6) Quitter l'application");
            Console.WriteLine("===================================");
            Console.Write("Veuillez sélectionner une option valide (1-6) : ");

            string input = Console.ReadLine();
            Console.WriteLine();

            switch (input) {
                case "1":
                    Console.WriteLine("Vous avez choisi de créer un nouveau compte.");
                    BankAccount.CreateAccount();
                    WaitForUserInput();
                    break;

                case "2":
                    Console.WriteLine("Vous avez choisi de rechercher un compte existant.");
                    Console.Write("Entrez le numéro du compte : ");
                    if (int.TryParse(Console.ReadLine(), out int searchAccountNumber)) {
                        BankAccount foundAccount = new BankAccount(0, "", "", 0).FindAccount(searchAccountNumber);
                        if (foundAccount != null) {
                            Console.WriteLine(
                                $"Compte trouvé : {foundAccount.AccountFirstName} {foundAccount.AccountLastName}, Solde : {foundAccount.AccountBalance}");
                        } else {
                            Console.WriteLine("Compte non trouvé.");
                        }
                    } else {
                        Console.WriteLine("Numéro de compte invalide. Veuillez entrer un nombre valide.");
                    }
                    WaitForUserInput();
                    break;

                case "3":
                    Console.WriteLine("Vous avez choisi de supprimer un compte.");
                    Console.Write("Entrez le numéro du compte à supprimer : ");
                    if (int.TryParse(Console.ReadLine(), out int deleteAccountNumber)) {
                        BankAccount accountToDelete = new BankAccount(0, "", "", 0).FindAccount(deleteAccountNumber);
                        if (accountToDelete != null) {
                            BankAccount.BankAccounts.Remove(accountToDelete);
                            Console.WriteLine("Compte supprimé avec succès.");
                        } else {
                            Console.WriteLine("Compte non trouvé.");
                        }
                    } else {
                        Console.WriteLine("Numéro de compte invalide. Veuillez entrer un nombre valide.");
                    }
                    WaitForUserInput();
                    break;

                case "4":
                    Console.WriteLine("Vous avez choisi d'effectuer une opération sur un compte.");
                    Console.Write("Entrez le numéro du compte : ");
                    if (int.TryParse(Console.ReadLine(), out int operationAccountNumber)) {
                        BankAccount operationAccount = new BankAccount(0, "", "", 0).FindAccount(operationAccountNumber);
                        if (operationAccount != null) {
                            Console.WriteLine("Choisissez une opération :");
                            Console.WriteLine("1) Dépôt");
                            Console.WriteLine("2) Retrait");
                            Console.WriteLine("3) Transfert");
                            Console.Write("Votre choix : ");
                            string operationChoice = Console.ReadLine();
                            switch (operationChoice) {
                                case "1":
                                    Console.Write("Entrez le montant à déposer : ");
                                    if (double.TryParse(Console.ReadLine(), out double depositAmount)) {
                                        operationAccount.Deposit(depositAmount);
                                    } else {
                                        Console.WriteLine("Montant invalide. Veuillez entrer un nombre valide.");
                                    }
                                    break;
                                case "2":
                                    Console.Write("Entrez le montant à retirer : ");
                                    if (double.TryParse(Console.ReadLine(), out double withdrawAmount)) {
                                        operationAccount.Withdraw(withdrawAmount);
                                    } else {
                                        Console.WriteLine("Montant invalide. Veuillez entrer un nombre valide.");
                                    }
                                    break;
                                case "3":
                                    Console.Write("Entrez le numéro du compte destinataire : ");
                                    if (int.TryParse(Console.ReadLine(), out int targetAccountNumber)) {
                                        BankAccount targetAccount = new BankAccount(0, "", "", 0).FindAccount(targetAccountNumber);
                                        if (targetAccount != null) {
                                            Console.Write("Entrez le montant à transférer : ");
                                            if (double.TryParse(Console.ReadLine(), out double transferAmount)) {
                                                operationAccount.Transfer(targetAccount, transferAmount);
                                            } else {
                                                Console.WriteLine("Montant invalide. Veuillez entrer un nombre valide.");
                                            }
                                        } else {
                                            Console.WriteLine("Compte destinataire non trouvé.");
                                        }
                                    } else {
                                        Console.WriteLine("Numéro de compte invalide. Veuillez entrer un nombre valide.");
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Opération invalide.");
                                    break;
                            }
                        } else {
                            Console.WriteLine("Compte non trouvé.");
                        }
                    } else {
                        Console.WriteLine("Numéro de compte invalide. Veuillez entrer un nombre valide.");
                    }
                    WaitForUserInput();
                    break;

                case "5":
                    Console.WriteLine("Vous avez choisi d'afficher la liste de tous les comptes.");
                    if (BankAccount.BankAccounts.Count > 0) {
                        foreach (var account in BankAccount.BankAccounts) {
                            Console.WriteLine(
                                $"Numéro : {account.AccountNumber}, Nom : {account.AccountFirstName} {account.AccountLastName}, Solde : {account.AccountBalance}");
                        }
                    } else {
                        Console.WriteLine("Aucun compte trouvé.");
                    }
                    WaitForUserInput();
                    break;

                case "6":
                    Console.WriteLine("Vous avez choisi de quitter l'application.");
                    Console.WriteLine("Merci d'avoir utilisé notre système bancaire. À bientôt !");
                    return;

                default:
                    Console.WriteLine("Option invalide ! Veuillez choisir un nombre entre 1 et 6.");
                    WaitForUserInput();
                    break;
            }
        }
    }

    private static void WaitForUserInput() {
        Console.WriteLine("\nAppuyez sur une touche pour revenir au menu principal...");
        Console.ReadKey();
    }
}