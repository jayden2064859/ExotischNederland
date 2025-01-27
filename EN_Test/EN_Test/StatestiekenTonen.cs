using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExotischNederland;

namespace EN_Test
{
    public static class Statestieken
    {
        public static void MeestVoorkomende()
        {
            string meestVoorkomendeDier = "";
            string meestVoorkomendePlant = "";
            int hoogsteDierAantal = 0;
            int hoogstePlantAantal = 0;

            // Haal lijst van alle organismen op
            var organismen = OrganismeData.Lijst();

            // Loop door organismen om meest voorkomende dier en plant te vinden
            foreach (var organisme in organismen)
            {
                // Controleren of het organisme een Dier is
                if (organisme is Dier dier)
                {
                    int teller = 0;

                    // Itereer over de lijst om te tellen hoe vaak dit dier voorkomt
                    foreach (var andereOrganisme in organismen)
                    {
                        if (andereOrganisme is Dier andereDier && andereDier.Naam == dier.Naam) // Vergelijk de namen van elk dier
                        {
                            teller++;
                        }
                    }

                    // Vergelijk en werk de meest voorkomende dier bij
                    if (teller > hoogsteDierAantal)
                    {
                        hoogsteDierAantal = teller;
                        meestVoorkomendeDier = dier.Naam;
                    }
                }

                // Controleren of het organisme een Plant is
                if (organisme is Plant plant)
                {
                    int teller = 0;

                    // Itereer over de lijst om te tellen hoe vaak deze plant voorkomt
                    foreach (var andereOrganisme in organismen)
                    {
                        if (andereOrganisme is Plant anderePlant && anderePlant.Naam == plant.Naam) // Vergelijk de namen van elke plant
                        {
                            teller++;
                        }
                    }

                    // Vergelijk en werk de meest voorkomende plant bij
                    if (teller > hoogstePlantAantal)
                    {
                        hoogstePlantAantal = teller;
                        meestVoorkomendePlant = plant.Naam;
                    }
                }
            }
            // Resultaten tonen                       
            Console.WriteLine($"{"Meest geregistreerde dier",-40} │ {meestVoorkomendeDier} ({hoogsteDierAantal})");
            Console.WriteLine($"{"Meest geregistreerde plant",-40} │ {meestVoorkomendePlant} ({hoogstePlantAantal})");
        }

        public static void Tonen()
        {
            int totaalOrganismen = OrganismeData.Lijst().Count; // Tel alle organismen binnen de lijst op 
            int inheemseOrganismen = 0;
            int exotischeOrganismen = 0;

            foreach (var organism in OrganismeData.Lijst()) 
            {
                if (organism.Oorsprong == "Inheems") // Elk organisme dat geregistreerd staat als inheems wordt hier opgetelt
                    inheemseOrganismen++;
                else if (organism.Oorsprong == "Exoot") // Elk organisme dat geregistreerd staat als exoot wordt hier opgetelt
                    exotischeOrganismen++;
            }

            // Variabelen om locatie met de meeste exoten te vinden
            string meestExotenLocatie = null;
            int hoogsteAantal = 0;

            List<string> uniekeLocaties = new List<string>();

            // Zorg dat elk geregistreerde locatie binnen de lijst toegevoegd wordt
            foreach (var organism in OrganismeData.Lijst())
            {
                if (!uniekeLocaties.Contains(organism.Locatie)) // Als een nieuwe locatie nog niet in de lijst staat, wordt het hier toegevoegt
                {
                    uniekeLocaties.Add(organism.Locatie);
                }
            }

            // Lijst met unieke locaties
            foreach (var locatie in uniekeLocaties)
            {
                // Tel exoten op deze locatie
                int aantalExoten = 0;

                foreach (var organisme in OrganismeData.Lijst())
                {
                    if (organisme.Oorsprong == "Exoot" && organisme.Locatie == locatie)
                    {
                        aantalExoten++;
                    }
                }

                // Als het aantal exoten op deze locatie groter is dan het vorige hoogste, werk dan bij
                if (aantalExoten > hoogsteAantal)
                {
                    hoogsteAantal = aantalExoten;
                    meestExotenLocatie = locatie;
                }
            }

            // Aantal geregistreerde dieren tellen
            int dierenCount = 0;
            foreach(var organisme in OrganismeData.Lijst())
            {
                if (organisme is Dier)
                {
                    dierenCount++; // Voor elk organisme dat geregistreerd is als 'Dier' wordt er 1 bij de count opgeteld
                }
            }

            // Aantal geregistreerde planten tellen
            int plantenCount = 0;
            foreach(var organisme in OrganismeData.Lijst())
            {
                if (organisme is Plant)
                {
                    plantenCount++;  // Voor elk organisme dat geregistreerd is als 'Plant' wordt er 1 bij de count opgeteld
                }
            }

            int inheemseDierenCount = 0;
            int exotischeDierenCount = 0;
            foreach (var dier in OrganismeData.Lijst())
            {
                if (dier is Dier)
                {
                    if (dier.Oorsprong == "Inheems")
                    {
                        inheemseDierenCount++;
                    }
                    else
                    {
                        exotischeDierenCount++;
                    }
                }
            }

            int inheemsePlantenCount = 0;
            int exotischePlantenCount = 0;
            foreach (var plant in OrganismeData.Lijst())
            {
                if (plant is Plant)
                {
                    if (plant.Oorsprong == "Inheems")
                    {
                        inheemsePlantenCount++;
                    }
                    else
                    {
                        exotischePlantenCount++;
                    }
                }
            }


            // Laat statestieken zien aan gebruiker
            Console.Clear();
            Console.WriteLine($"{"Beschrijving",-40} │ {"Waarde",-16}");
            Organise.Line5();

            Console.WriteLine($"{"Totaal aantal organismen",-40} │ {totaalOrganismen}");
            Console.WriteLine($"{"Aantal inheemse organismen",-40} │ {inheemseOrganismen}");
            Console.WriteLine($"{"Aantal exotische organismen",-40} │ {exotischeOrganismen}");
            Console.WriteLine(new string('─', 63));

            Console.WriteLine($"{"Totaal aantal dieren",-40} │ {dierenCount}");
            Console.WriteLine($"{"Aantal inheemse dieren",-40} │ {inheemseDierenCount}");
            Console.WriteLine($"{"Aantal exotische dieren",-40} │ {exotischeDierenCount}");
            Console.WriteLine(new string('─', 63));

            Console.WriteLine($"{"Totaal aantal planten",-40} │ {plantenCount}");
            Console.WriteLine($"{"Aantal inheemse planten",-40} │ {inheemsePlantenCount}");
            Console.WriteLine($"{"Aantal exotische planten",-40} │ {exotischePlantenCount}");
            Console.WriteLine(new string('─', 63));
            
            MeestVoorkomende(); // Laat de meest voorkomende dier en plant zien
            Console.WriteLine(new string('─', 63));
            Console.WriteLine($"{"Locatie met de meeste exoten",-40} │ {meestExotenLocatie} ({hoogsteAantal})");

            Organise.Line5();

            // Optie om terug te gaan naar het menu
            Menu.Return();
        }
       
    }
}
