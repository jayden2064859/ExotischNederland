using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExotischNederland
{
    public static class Menu // een class voor het terugkeren naar het hoofdmenu na elke actie binnen de applicatie
    {
        public static void Return()
        {
            
            Console.WriteLine("X. Terug naar menu");

            string terug = Console.ReadLine();
            if (terug.ToLower() == "x") return;
            
        }

        public static void Filteren()
        {
            Console.Clear();
            Console.WriteLine("\nFilteren op");
            Organise.Line2();
            Console.WriteLine("1. Type\n2. Oorsprong\n3. Locatie\nX. Terug naar menu");
            Organise.Line2();


            string userInputFilteren = Console.ReadLine();
            if (userInputFilteren == "1") // De gebruiker filtert op type
            {

                Console.WriteLine("\nFilteren op type");
                Organise.Line2();
                Console.WriteLine("1. Dier\n2. Plant\nX. Terug naar menu");
                Organise.Line2();

                string userInputType = Console.ReadLine();
                if (userInputType == "1") // De gebruiker filtert op dieren
                {
                    Console.Clear();
                    Registraties.Dieren();
                    Menu.Return();
                }

                else if (userInputType == "2") // De gebruiker filtert op planten
                {
                    Console.Clear();
                    Registraties.Planten();
                    Menu.Return();
                }
            }

            else if (userInputFilteren == "2") // De gebruiker filtert op oorsprong
            {
                Console.WriteLine("\nFilteren op oorsprong");
                Organise.Line2();
                Console.WriteLine("1. Inheems\n2. Exoot\nX. Terug naar menu");
                Organise.Line2();

                string userInputOorsprong = Console.ReadLine();
                if (userInputOorsprong == "1")
                {
                    Console.Clear();
                    Registraties.Inheems();
                    Menu.Return();

                }
                else if (userInputOorsprong == "2")
                {
                    Console.Clear();
                    Registraties.Exoten();
                    Menu.Return();
                }
            }
            else if (userInputFilteren == "3") // gebruiker filtert op locatie
            {
                Console.Clear();
                Registraties.Locatie();
                Menu.Return(); // Keer terug naar het hoofdmenu
            }
            Console.Clear();
        }


    }
}
