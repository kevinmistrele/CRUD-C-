using System;
using System.Data;
using MySql.Data.MySqlClient;

class Database
{
    public void RunDatabaseOperations (string[] args) 
    {
        DatabaseManager dbManager = new DatabaseManager("Persist Security Info=False;server=sql.freedb.tech;database=freedb_umc_dp_kevin;uid=freedb_kevinmistrele;pwd=$QSNfS53YNrEUtw");
        dbManager.ConnectAndFetchData();
    }
}

class DatabaseManager
{
    private readonly string connectionString;

    public DatabaseManager(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public void ConnectAndFetchData()
    {
        using MySqlConnection con = new MySqlConnection(connectionString);
        try
        {
            con.Open();
            Console.WriteLine($"MySQL version : {con.ServerVersion}");

            if (con.State == ConnectionState.Open)
            {
                Console.WriteLine("Connection Open!");
                var sql = "SELECT * FROM ALUNO";
                using var cmd = new MySqlCommand(sql, con);
                using MySqlDataReader rdr = cmd.ExecuteReader();
            }
        }
        catch (MySqlException ex)
        { 
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}