/*
 To do:
 Database toevoegen waar de registraties in komen te staan en om accountgegevens op te slaan zodat gegevens gechecked worden (Medewerker menu heeft optie om database in te zien)
 Meer serious games (Fun facts/Educatieve sectie, Raad het dier, waar of onwaar etc)
 Automatische Locatiebepaling?
 Bij statestieken een top 5/top 10 meest geregistreerde dieren maken, in plaats van maar 1
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
        // Laad organismen vanuit de database in de lijst
        Database.LaadOrganismen();

        // Toont het hoofdmenu of verder werk
        bool running = true;
        do
        {
            Hoofdmenu.Gast();

            if (Hoofdmenu.medewerker)
            {
                Hoofdmenu.Medewerker();
            }
        } while (running);
    }

}



