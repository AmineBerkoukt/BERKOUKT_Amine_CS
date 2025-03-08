using MySql.Data.MySqlClient;
using System;
namespace Serie4Console.Data;


public static class Database {
    private static string _connectionString;

    static Database() {
        LoadConfiguration();
    }

    private static void LoadConfiguration() {
        try {
            // Directly hardcoding the connection string here
            _connectionString = "server=localhost;database=ensat;user=root;password=;";
        }
        catch (Exception ex) {
            Console.WriteLine($"Error loading config: {ex.Message}");
            Environment.Exit(1);
        }
    }

    public static MySqlConnection GetConnection() {
        return new MySqlConnection(_connectionString);
    }
}