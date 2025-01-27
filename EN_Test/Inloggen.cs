using System;

namespace ExotischNederland
{
    public class Gebruiker
    {
        public string Gebruikersnaam { get; set; }
        public string Wachtwoord { get; set; }
    }
    public static class GebruikersData
    {
        public static List<Gebruiker> Gebruikers = new List<Gebruiker> // Accountgegevens aanmaken voor de bestaande medewerkers
    {
        new Gebruiker { Gebruikersnaam = "Jayden", Wachtwoord = "1234" },
        new Gebruiker { Gebruikersnaam = "Yassir", Wachtwoord = "1234" },
        new Gebruiker { Gebruikersnaam = "Nathalie", Wachtwoord = "1234" },
        new Gebruiker { Gebruikersnaam = "Mandy", Wachtwoord = "1234" },
    };

    }
    public static class Inloggen
    {
        public static string Gebruikersnaam { get; private set; } = string.Empty;
        public static void Medewerker()
        {
            Console.Clear();
            do
            {             
                Console.Write("\nGebruikersnaam: ");
                string gebruikersnaamInput = Console.ReadLine();
                Console.Write("Wachtwoord: ");
                string wachtwoordInput = Console.ReadLine();

                // Zoek de gebruiker in de lijst
                var gebruiker = GebruikersData.Gebruikers
                    .FirstOrDefault(g =>
                        g.Gebruikersnaam == gebruikersnaamInput && g.Wachtwoord == wachtwoordInput); // Vergelijkt de gegeven input met de accountgegevens

                if (gebruiker != null)
                {
                    Gebruikersnaam = gebruiker.Gebruikersnaam;
                    Hoofdmenu.medewerker = true;
                    Console.WriteLine($"\nIngelogd als {Gebruikersnaam}");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\nOngeldige gebruikersnaam of wachtwoord. Probeer opnieuw.");
                    Hoofdmenu.medewerker = false;
                }
            } while (Hoofdmenu.medewerker != true);
        }

        public static void Begroeting()
        {
            if (Hoofdmenu.medewerker)
            {
                Console.WriteLine("- Ingelogd als medewerker -");
                Console.WriteLine($"     Hallo {Gebruikersnaam}!");
            }
        }
    }
}