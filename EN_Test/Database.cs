using System;
using System.Data.SQLite;
using MySql.Data.MySqlClient;
public class Database
{
    public static void Connect()  // Methode om de database te linken met het programma
    {
        string connectionString = "Server=20.82.112.106;Database=brogrammeurs;User Id=root;Password=Yassirmerini1!;SslMode=None;";
        using MySqlConnection connection = new MySqlConnection(connectionString);
        {
            connection.Open();
        }
    }
}
