using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ExotischNederland
{
    public static class Registraties
    {
          
        public static void Tonen() // Methode voor alle bestaande registraties
        {
            Console.Clear();
            List<Organisme> organismen = OrganismeData.Lijst();
            Console.WriteLine($"{"Naam",-15} │ {"Type",-16} │ {"Soort",-16} │ {"Locatie",-12} │ {"Registratie datum",-20}");
            Console.WriteLine(new string('─', 91));

            foreach (var organisme in organismen)
            {
                Console.WriteLine($"{organisme.Naam,-15} │ {organisme.Type,-16} │ {organisme.Oorsprong,-16} │ {organisme.Locatie,-12} │ {organisme.RegistratieDatum:dd/MM/yyyy HH:mm:ss}");
            }
            Console.WriteLine(new string('─', 91));

            Menu.Return(); // Een methode om terug te keren naar het hoofdmenu na bepaalde acties
            Console.Clear();

        }

        public static void Dieren() // Methode voor specifiek dieren te tonen
        {
            List<Organisme> organismen = OrganismeData.Lijst();
            Console.WriteLine($"{"Naam",-15} │ {"Type",-16} │ {"Soort",-16} │ {"Leefgebied",-16} │ {"Locatie",-12} │ {"Registratie datum",-20}");
            Console.WriteLine(new string('─', 110));

            foreach (var organisme in organismen)
            {
                if (organisme is Dier dier)
                {
                    Console.WriteLine($"{dier.Naam,-15} │ {dier.Type,-16} │ {dier.Oorsprong,-16} │ {dier.Leefgebied,-16} │ {dier.Locatie,-12} │ {dier.RegistratieDatum:dd/MM/yyyy HH:mm:ss}");
                }
               
            }
            Console.WriteLine(new string('─', 110));

        }

        public static void Planten() // Methode voor specifiek dieren te tonen
        {
            List<Organisme> organismen = OrganismeData.Lijst();
            Console.WriteLine($"{"Naam",-15} │ {"Type",-16} │ {"Soort",-16} │ {"Hoogte (meter)",-16}  │ {"Locatie",-12} │ {"Registratie datum",-20}");
            Console.WriteLine(new string('─', 111));

            foreach (var organisme in organismen)
            {
                if (organisme is Plant plant)
                {
                    Console.WriteLine($"{plant.Naam,-15} │ {plant.Type,-16} │ {plant.Oorsprong,-16} │ {plant.HoogteInMeters,-16}  │ {plant.Locatie,-12} │ {plant.RegistratieDatum:dd/MM/yyyy HH:mm:ss}");
                }

            }
            Console.WriteLine(new string('─', 111));
            
        }

        public static void Inheems() // Methode voor wanneer gebruiker filtert op Inheems
        {
            List<Organisme> organismen = OrganismeData.Lijst();
            Console.WriteLine($"{"Naam",-15} │ {"Type",-16} │ {"Soort",-16} │ {"Locatie",-12} │ {"Registratie datum",-20}");
            Console.WriteLine(new string('─', 91));

            foreach (var organisme in organismen)
            {
                if (organisme.Oorsprong == "Inheems")
                {
                    Console.WriteLine($"{organisme.Naam,-15} │ {organisme.Type,-16} │ {organisme.Oorsprong,-16} │ {organisme.Locatie,-12} │ {organisme.RegistratieDatum:dd/MM/yyyy HH:mm:ss}");

                }
            }
            Console.WriteLine(new string('─', 91));

        }

        public static void Exoten() // Methode voor wanneer gebruiker filtert op Inheems
        {
            List<Organisme> organismen = OrganismeData.Lijst();
            Console.WriteLine($"{"Naam",-15} │ {"Type",-16} │ {"Soort",-16} │ {"Locatie",-12} │ {"Registratie datum",-20}");
            Console.WriteLine(new string('─', 91));

            foreach (var organisme in organismen)
            {
                if (organisme.Oorsprong == "Exoot")
                {
                    Console.WriteLine($"{organisme.Naam,-15} │ {organisme.Type,-16} │ {organisme.Oorsprong,-16} │ {organisme.Locatie,-12} │ {organisme.RegistratieDatum:dd/MM/yyyy HH:mm:ss}");

                }
            }
            Console.WriteLine(new string('─', 91));

        }

        public static void Locatie() // Methode voor wanneer gebruiker filtert op locatie
        {
            List<Organisme> organismen = OrganismeData.Lijst(); // Haal alle organismen op

            // Sorteer de organismen op locatie
            var organismenGesorteerd = organismen.OrderBy(o => o.Locatie).ToList();

            // Toon de kolomkoppen
            Console.WriteLine($"{"Naam",-15} │ {"Type",-16} │ {"Soort",-16} │ {"Locatie",-12} │ {"Registratie datum",-20}");
            Console.WriteLine(new string('─', 91));

            string vorigeLocatie = ""; // Houd de vorige locatie bij zodat we weten wanneer een nieuwe locatie begint

            // Itereer door de gesorteerde lijst van organismen
            foreach (var organisme in organismenGesorteerd)
            {
                // Als de locatie van dit organisme verschilt van de vorige, voeg een scheidingslijn toe
                if (organisme.Locatie != vorigeLocatie)
                {
                    if (vorigeLocatie != "") // Voeg een lijn toe als dit niet de eerste locatie is
                    {
                        Console.WriteLine(new string('─', 91));
                    }

                    // Update vorigeLocatie naar de huidige locatie
                    vorigeLocatie = organisme.Locatie;
                }

                // Toon de gegevens van het organisme
                Console.WriteLine($"{organisme.Naam,-15} │ {organisme.Type,-16} │ {organisme.Oorsprong,-16} │ {organisme.Locatie,-12} │ {organisme.RegistratieDatum:dd/MM/yyyy HH:mm:ss}");
            }

            Console.WriteLine(new string('─', 91));
        }

    }
    
}
