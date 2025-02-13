using System;
using System.Collections.Generic;

namespace TP5 {
    public class BankAccount {
        public int AccountNumber { get; set; }
        public string AccountFirstName { get; set; }
        public string AccountLastName { get; set; }
        public double AccountBalance { get; set; }

        public static List<BankAccount> BankAccounts = new List<BankAccount>();

        public BankAccount(int accountNumber, string accountFirstName, string accountLastName, double accountBalance) {
            AccountNumber = accountNumber;
            AccountFirstName = accountFirstName;
            AccountLastName = accountLastName;
            AccountBalance = accountBalance;
        }
        
        public BankAccount FindAccount(int accountNumber) {
            foreach (var account in BankAccounts) {
                if (account.AccountNumber == accountNumber) {
                    return account;
                }
            }
            return null;
        }

        public static void CreateAccount() {
            Console.WriteLine("Entrez le numero du compte :");
            int accountNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Entrez le Nom du compte :");
            string firstName = Console.ReadLine();

            Console.WriteLine("Entrez le Prenom du compte :");
            string lastName = Console.ReadLine();


            BankAccount newAccount = new BankAccount(accountNumber, firstName, lastName, 0);

            BankAccounts.Add(newAccount);

            Console.WriteLine("Account created successfully!");
        }

        public void Deposit(double amount) {
            if (amount > 0) {
                AccountBalance += amount;
                Console.WriteLine($"Deposited {amount}. New balance: {AccountBalance}");
            }
            else {
                Console.WriteLine("Invalid deposit amount.");
            }
        }

        public void Withdraw(double amount) {
            if (amount > 0 && amount <= AccountBalance) {
                AccountBalance -= amount;
                Console.WriteLine($"Withdrew {amount}. New balance: {AccountBalance}");
            }
            else {
                Console.WriteLine("Invalid withdrawal amount or insufficient balance.");
            }
        }

        public void CheckHistory() {
            Console.WriteLine("Transaction history not implemented yet.");
        }

        public void Transfer(BankAccount targetAccount, double amount) {
            if (FindAccount(targetAccount.AccountNumber) != null) {
                return;
            }
            
            if (amount > 0 && amount <= AccountBalance) {
                AccountBalance -= amount;
                targetAccount.AccountBalance += amount;
                Console.WriteLine(
                    $"Transferred {amount} to account {targetAccount.AccountNumber}. New balance: {AccountBalance}");
            }
            else {
                Console.WriteLine("Invalid transfer amount or insufficient balance.");
            }
        }
    }
}