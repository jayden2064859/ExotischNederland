using System;

namespace ExotischNederland
{
    public static class Startscherm
    {
       

        public static void Inloggen()
        {
            string invoer = "";

            do
            {
                Organise.Line3();
                Console.WriteLine("1. Log in als medewerker\n2. Doorgaan als gast\nX. Afsluiten");
                Organise.Line3();

                invoer = Console.ReadLine();

                if (invoer == "1")
                {
                    Console.Write("\nGebruikersnaam: ");
                    string gebruikersnaam = Console.ReadLine();
                    Console.Write("Wachtwoord: ");
                    string wachtwoord = Console.ReadLine();

                    Console.Clear();
                    Console.WriteLine("- Ingelogd als medewerker -");
                    Console.WriteLine($"Hallo {gebruikersnaam}!");
                    Hoofdmenu.medewerker = true;
                    break;
                }

                else if (invoer == "2")
                {
                    Console.Clear();
                    Console.WriteLine("- Ingelogd als gast -");
                    Hoofdmenu.medewerker = false;
                    break;
                }

                else if (invoer.ToLower() == "x")
                {
                    Hoofdmenu.afsluiten = true; // Als gebruiker op beginscherm X invoert wordt het programma afgesloten
                    break;
                }

                else
                {
                    Console.Clear();

                }

            } while (!Hoofdmenu.afsluiten); // Stop de loop als 'afsluiten' true

            if (Hoofdmenu.afsluiten)
            {
                Console.WriteLine("Programma afgesloten..");
                Environment.Exit(0); // Programma stopt als de boolean afsluiten true is (gebruiker voert X in op beginscherm)
            }

        }


    }
}