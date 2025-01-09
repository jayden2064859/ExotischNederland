using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EN_Test;

namespace ExotischNederland
{
    public static class Hoofdmenu
    {
        public static bool medewerker; // Boolean om te checken of gebruiker ingelogd is als medewerker
        public static bool afsluiten;  // Boolean om te bepalen of het programma moet afsluiten
        public static void Gast()
        {
            medewerker = false;

            Console.Clear();
            Console.WriteLine("\nHoofdmenu");
            Organise.Line4();
            Console.WriteLine("1. Waarneming registreren\n2. Lijst van registraties\n3. Statestieken\n4. Filteren\n5. Quiz spelen\n\nX. Terug naar inlogscherm");


            Organise.Line4();

            List<Organisme> organismen = OrganismeData.Lijst();



            string userInputMenu = Console.ReadLine();

            if (userInputMenu.ToUpper() == "X")
            {
                Console.Clear();
                Startscherm.Inloggen(); // Ga terug naar inlogscherm wanneer gebruiker X invoert in het menu
            }


            if (userInputMenu == "1")
            {
                bool terug = false; // boolean om terug te gaan naar hoofdmenu

                while (!terug)
                {
                    Console.Clear();
                    Console.WriteLine("\nRegistreren");
                    Organise.Line2();
                    Console.WriteLine("1. Dier\n2. Plant\nX. Terug naar menu");
                    Organise.Line2();


                    string userInputToevoegen = Console.ReadLine();
                    if (userInputToevoegen.ToLower() == "x")
                    {
                        Console.Clear();
                        terug = true; // Als gebruiker X invoert wordt er teruggekeerd naar hoofdmenu.
                        continue;
                    }

                    if (userInputToevoegen == "1") // Gebruiker wil een dier toevoegen aan lijst
                    {
                        Console.Clear();
                        Registratie.Dier();
                        terug = true;
                        Menu.Return();
                        Console.Clear();
                    }

                    else // Gebruiker wil een plant toevoegen aan lijst
                    {
                        Console.Clear();
                        Registratie.Plant();
                        terug = true;
                        Menu.Return();
                        Console.Clear();
                    }
                }

            }

            if (userInputMenu == "2")
            {              
                Registraties.Tonen();  
                
            }

            if (userInputMenu == "3")
            {
                Statestieken.Tonen();
            }
            
            if (userInputMenu == "4")
            {
                Menu.Filteren();
            }

            if (userInputMenu == "5")
            {
                Quiz.Beginnen();
            }

            else
            {
                Console.Clear();      
            }
        }

        public static void Medewerker() 
        {
            medewerker = true;

            Console.Clear();
            Console.WriteLine("\nHoofdmenu");
            Organise.Line4();
            Console.WriteLine("1. Waarneming registreren\n2. Lijst van registraties\n3. Statestieken\n4. Database bekijken\n5. Filteren\n6. Quiz spelen\n\nX. Terug naar inlogscherm");
            Organise.Line4();

            List<Organisme> organismen = OrganismeData.Lijst();



            string userInputMenu = Console.ReadLine();

            if (userInputMenu.ToUpper() == "X")
            {
                Console.Clear();
                Startscherm.Inloggen(); // Ga terug naar inlogscherm wanneer gebruiker X invoert in het menu
            }


            if (userInputMenu == "1")
            {
                bool terug = false; // boolean om terug te gaan naar hoofdmenu

                while (!terug)
                {

                    Console.Clear();
                    Console.WriteLine("\nRegistreren");
                    Organise.Line2();
                    Console.WriteLine("1. Dier\n2. Plant\nX. Terug naar menu");
                    Organise.Line2();


                    string userInputToevoegen = Console.ReadLine();
                    if (userInputToevoegen.ToLower() == "x")
                    {
                        Console.Clear();
                        terug = true; // Als gebruiker X invoert wordt er teruggekeerd naar hoofdmenu.
                        continue;
                    }

                    if (userInputToevoegen == "1") // Gebruiker wil een dier toevoegen aan lijst
                    {
                        Console.Clear();
                        Registratie.Dier();
                        terug = true;
                        Menu.Return();
                        Console.Clear();
                    }

                    else // Gebruiker wil een plant toevoegen aan lijst
                    {
                        Console.Clear();
                        Registratie.Plant();
                        terug = true;
                        Menu.Return();
                        Console.Clear();
                    }
                }

            }

            if (userInputMenu == "2")
            {            
                Registraties.Tonen(); // een methode die gebruikt wordt om alle bestaande registraties op het scherm te tonen
            }

            if (userInputMenu == "3")
            {
                Statestieken.Tonen();
            }

            if (userInputMenu == "4")
            {
                // Database toevoegen
            }

            if (userInputMenu == "5")
            {
                Menu.Filteren();
            }

            if (userInputMenu == "6")
            {
                Quiz.Beginnen();                
            }

            else
            {
                Console.Clear(); // Zorgt ervoor dat er 'niks' gebeurd wanneer gebruiker iets invoert dat geen valid input is. 
            }
        }
    }
}
