/*
 To do:
 Database toevoegen waar de registraties in komen te staan en om accountgegevens op te slaan zodat gegevens gechecked worden (Medewerker menu heeft optie om database in te zien)
 Meer serious games (Fun facts/Educatieve sectie, Raad het dier, waar of onwaar etc)
 Automatische Locatiebepaling?
 Bij statistieken een top 5/top 10 meest geregistreerde dieren maken, in plaats van maar 1
 Medewerkers moeten een optie in hun hoofdmenu hebben om de nieuwe registraties goed te keuren en aanpassen/verwijderen indien nodig
 ^ Voeg een extra waarde toe bij de registraties; 'Verified' en 'pending' voor de registraties die gechecked moeten worden door medewerkers
*/

using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using ExotischNederland;

class Program
{

    static void Main()
    {

        Startscherm.Inloggen(); // Methode aanroepen om bij het inlogscherm te komen

        // Tijdelijke handmatige registraties binnen de code om de functies van het programma te testen
        // Dit soort registraties komen later binnen de database te staan
        OrganismeData.Toevoegen(new Dier
        {
            Naam = "Hond",
            Type = "Dier",
            Oorsprong = "Inheems",
            Leefgebied = "Bossen",
            Locatie = "Landgraaf",
            RegistratieDatum = DateTime.Now
        });

        OrganismeData.Toevoegen(new Dier
        {
            Naam = "Leeuw",
            Type = "Dier",
            Oorsprong = "Exoot",
            Leefgebied = "Savanne",
            Locatie = "Landgraaf",
            RegistratieDatum = DateTime.Now
        });

        OrganismeData.Toevoegen(new Dier
        {
            Naam = "Beer",
            Type = "Dier",
            Oorsprong = "Inheems",
            Leefgebied = "Bergen",
            Locatie = "Kerkrade",
            RegistratieDatum = DateTime.Now
        });

        OrganismeData.Toevoegen(new Dier
        {
            Naam = "Kameel",
            Type = "Dier",
            Oorsprong = "Exoot",
            Leefgebied = "Woestijn",
            Locatie = "Heerlen",
            RegistratieDatum = DateTime.Now
        });

        OrganismeData.Toevoegen(new Plant
        {
            Naam = "Eik",
            Type = "Plant",
            Oorsprong = "Inheems",
            HoogteInMeters = "25",
            Locatie = "Kerkrade",
            RegistratieDatum = DateTime.Now
        });

        OrganismeData.Toevoegen(new Plant
        {
            Naam = "Rode Klaver",
            Type = "Plant",
            Oorsprong = "Exoot",
            HoogteInMeters = "0.3",
            Locatie = "Heerlen",
            RegistratieDatum = DateTime.Now
        });

        OrganismeData.Toevoegen(new Plant
        {
            Naam = "Tulp",
            Type = "Plant",
            Oorsprong = "Inheems",
            HoogteInMeters = "0.6",
            Locatie = "Kerkrade",
            RegistratieDatum = DateTime.Now
        });

        OrganismeData.Toevoegen(new Plant
        {
            Naam = "Bamboe",
            Type = "Plant",
            Oorsprong = "Exoot",
            HoogteInMeters = "5",
            Locatie = "Landgraaf",
            RegistratieDatum = DateTime.Now
        });

        OrganismeData.Toevoegen(new Plant
        {
            Naam = "Lavendel",
            Type = "Plant",
            Oorsprong = "Inheems",
            HoogteInMeters = "0.8",
            Locatie = "Landgraaf",
            RegistratieDatum = DateTime.Now
        });

        OrganismeData.Toevoegen(new Dier
        {
            Naam = "Olifant",
            Type = "Dier",
            Oorsprong = "Exoot",
            Leefgebied = "Savanne",
            Locatie = "Landgraaf",
            RegistratieDatum = DateTime.Now
        });

        OrganismeData.Toevoegen(new Dier
        {
            Naam = "Vos",
            Type = "Dier",
            Oorsprong = "Inheems",
            Leefgebied = "Bossen",
            Locatie = "Kerkrade",
            RegistratieDatum = DateTime.Now
        });

        OrganismeData.Toevoegen(new Dier
        {
            Naam = "Vos",
            Type = "Dier",
            Oorsprong = "Inheems",
            Leefgebied = "Bossen",
            Locatie = "Landgraaf",
            RegistratieDatum = DateTime.Now
        });

        OrganismeData.Toevoegen(new Dier
        {
            Naam = "Witstaart hert",
            Type = "Dier",
            Oorsprong = "Exoot",
            Leefgebied = "Bosrand",
            Locatie = "Heerlen",
            RegistratieDatum = DateTime.Now
        });

        // Planten
        OrganismeData.Toevoegen(new Plant
        {
            Naam = "Rode Roos",
            Type = "Plant",
            Oorsprong = "Exoot",
            HoogteInMeters = "1",
            Locatie = "Landgraaf",
            RegistratieDatum = DateTime.Now
        });

        OrganismeData.Toevoegen(new Plant
        {
            Naam = "Tulp",
            Type = "Plant",
            Oorsprong = "Inheems",
            HoogteInMeters = "0.5",
            Locatie = "Kerkrade",
            RegistratieDatum = DateTime.Now
        });

        OrganismeData.Toevoegen(new Plant
        {
            Naam = "Iris",
            Type = "Plant",
            Oorsprong = "Inheems",
            HoogteInMeters = "0.7",
            Locatie = "Landgraaf",
            RegistratieDatum = DateTime.Now
        });

        OrganismeData.Toevoegen(new Plant
        {
            Naam = "Cactus",
            Type = "Plant",
            Oorsprong = "Exoot",
            HoogteInMeters = "2",
            Locatie = "Heerlen",
            RegistratieDatum = DateTime.Now
        });



        bool running = true; // Een boolean waarde waardoor er na elke actie terug wordt gekeerd naar het hoofdmenu, totdat user "X" invoert

        do
        {         
            if (Hoofdmenu.medewerker) // Bepaal welk hoofdmenu (en welke access) de gebruiker krijgt
            {
                Hoofdmenu.Medewerker();
            }
            else
            {
                Hoofdmenu.Gast(); 

            }
            

        } while (running = true); // Gebruiker kan door de applicatie navigeren totdat de gebruiker het programma afsluit (running = false)





    }

}



