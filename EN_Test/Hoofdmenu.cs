using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
            Console.WriteLine("1. Inloggen als medewerker\n2. Waarneming registreren\n3. Lijst van registraties\n4. Statestieken\n5. Filteren\n\nX. Afsluiten");


            Organise.Line4();

            List<Organisme> organismen = OrganismeData.Lijst();



            string userInputMenu = Console.ReadLine();

            if (userInputMenu.ToUpper() == "X")
            {
                Console.WriteLine("Programma afgesloten..");
                Environment.Exit(0);

            }

            if (userInputMenu == "1")
            {
                Inloggen.Medewerker();
                Medewerker();
            }

            if (userInputMenu == "2")
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

            if (userInputMenu == "3")
            {
                Registraties.Tonen();

            }

            if (userInputMenu == "4")
            {
                Statestieken.Tonen();
            }

            if (userInputMenu == "5")
            {
                Menu.Filteren();
            }

            else
            {
                Console.Clear();
            }
        }

        public static void Medewerker()
        {
            Console.Clear();
            Inloggen.Begroeting();

            medewerker = true;
            do
            {
                Console.WriteLine("\nHoofdmenu");
                Organise.Line4();
                Console.WriteLine("1. Waarneming registreren\n2. Lijst van registraties\n3. Registraties wijzigen\n4. Statestieken\n5. Database bekijken\n6. Filteren\n\nX. Afsluiten");
                Organise.Line4();

                List<Organisme> organismen = OrganismeData.Lijst();



                string userInputMenu = Console.ReadLine();

                if (userInputMenu.ToUpper() == "X")
                {
                    Console.WriteLine("Programma afgesloten..");
                    Environment.Exit(0);
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
                    Registraties.IDLijst();
                    RegistratiesWijzigen.WijzigRegistratie(OrganismeData.Lijst());
                }

                if (userInputMenu == "4")
                {
                    Statestieken.Tonen();
                }

                if (userInputMenu == "5")
                {
                    // Database toevoegen
                }

                if (userInputMenu == "6")
                {
                    Menu.Filteren();
                }

                else
                {
                    Console.Clear();  
                }
            } while (afsluiten != true);
    } }
}
