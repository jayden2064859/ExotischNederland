using MySql.Data.MySqlClient;
using System;

public class Database
{
    public static void LaadOrganismen()
    {
        string connectionString = "Server=20.82.112.106;Port=3306;Database=brogrammeurs;Uid=root;Pwd=Yassirmerini1!;";

        // Maak de database connectie
        using MySqlConnection connection = new MySqlConnection(connectionString);
        {
            connection.Open();

            // Query voor het ophalen van dieren
            string queryDieren = "SELECT naam, type, oorsprong, leefgebied, locatie, registratie_datum FROM DIER";
            using MySqlCommand commandDieren = new MySqlCommand(queryDieren, connection);

            using MySqlDataReader reader = commandDieren.ExecuteReader();
            while (reader.Read())
            {
                // Dieren toevoegen aan de lijst
                OrganismeData.Toevoegen(new Dier
                {
                    Naam = reader.GetString("naam"),
                    Type = reader.GetString("type"),
                    Oorsprong = reader.GetString("oorsprong"),
                    Leefgebied = reader.GetString("leefgebied"),
                    Locatie = reader.GetString("locatie"),
                    RegistratieDatum = reader.GetDateTime("registratie_datum")
                });
            }

            reader.Close();

            // Query voor het ophalen van planten
            string queryPlanten = "SELECT naam, type, oorsprong, hoogte_in_meters, locatie, registratie_datum FROM PLANT";
            using MySqlCommand commandPlanten = new MySqlCommand(queryPlanten, connection);

            using MySqlDataReader readerPlant = commandPlanten.ExecuteReader();
            while (readerPlant.Read())
            {
                // Planten toevoegen aan de lijst
                OrganismeData.Toevoegen(new Plant
                {
                    Naam = readerPlant.GetString("naam"),
                    Type = readerPlant.GetString("type"),
                    Oorsprong = readerPlant.GetString("oorsprong"),
                    HoogteInMeters = readerPlant.GetFloat("hoogte_in_meters").ToString(),
                    Locatie = readerPlant.GetString("locatie"),
                    RegistratieDatum = readerPlant.GetDateTime("registratie_datum")
                });
            }
        }
    }

    public static void ToevoegenNaarDatabase(Organisme organisme)
    {
        string connectionStr = "Server=20.82.112.106;Port=3306;Database=brogrammeurs;Uid=root;Pwd=Yassirmerini1!;";
        using MySqlConnection connection = new MySqlConnection(connectionStr);
        connection.Open();

        if (organisme is Dier dier)
        {
            // Query om Dier toe te voegen aan de database
            string query = "INSERT INTO DIER (naam, type, oorsprong, leefgebied, locatie, registratie_datum) " +
                           "VALUES (@Naam, @Type, @Oorsprong, @Leefgebied, @Locatie, @RegistratieDatum)";

            using MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Naam", dier.Naam);
            command.Parameters.AddWithValue("@Type", dier.Type);
            command.Parameters.AddWithValue("@Oorsprong", dier.Oorsprong);
            command.Parameters.AddWithValue("@Leefgebied", dier.Leefgebied);
            command.Parameters.AddWithValue("@Locatie", dier.Locatie);
            command.Parameters.AddWithValue("@RegistratieDatum", dier.RegistratieDatum);

            command.ExecuteNonQuery();
        }
        else if (organisme is Plant plant)
        {
            // Query om Plant toe te voegen aan de database
            string query = "INSERT INTO PLANT (naam, type, oorsprong, hoogte_in_meters, locatie, registratie_datum) " +
                           "VALUES (@Naam, @Type, @Oorsprong, @HoogteInMeters, @Locatie, @RegistratieDatum)";

            using MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Naam", plant.Naam);
            command.Parameters.AddWithValue("@Type", plant.Type);
            command.Parameters.AddWithValue("@Oorsprong", plant.Oorsprong);
            command.Parameters.AddWithValue("@HoogteInMeters", plant.HoogteInMeters);
            command.Parameters.AddWithValue("@Locatie", plant.Locatie);
            command.Parameters.AddWithValue("@RegistratieDatum", plant.RegistratieDatum);

            command.ExecuteNonQuery();
        }
    }

    public static void VerwijderUitDatabase(string naam, string type, string locatie)
    {
        string connString = "Server=20.82.112.106;Port=3306;Database=brogrammeurs;Uid=root;Pwd=Yassirmerini1!;";

        using (MySqlConnection connection = new MySqlConnection(connString))
        {
            connection.Open();

            // Bouw de query afhankelijk van het type (Dier of Plant)
            string query = type == "Dier" ?
                "DELETE FROM DIER WHERE naam = @naam AND locatie = @locatie" :
                "DELETE FROM PLANT WHERE naam = @naam AND locatie = @locatie";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                // Parameters toevoegen aan de query
                command.Parameters.AddWithValue("@naam", naam);
                command.Parameters.AddWithValue("@locatie", locatie);

                // Als je wilt, kun je nog extra parameters toevoegen zoals 'type', als dat ook nodig is

                try
                {
                    // Voer de query uit
                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        Console.WriteLine("Registratie succesvol uit de database verwijderd.");
                    }
                    else
                    {
                        Console.WriteLine("Geen matching registratie gevonden. Mogelijk is het organismennaam of locatie niet correct.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Er is een fout opgetreden: " + ex.Message);
                }
            }
        }
    }
}

