using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExotischNederland
{
    internal class Registratie
    {
        public static void Dier()
        {


            List<Organisme> dieren = OrganismeData.Lijst();

            bool terug = false;

            Console.Clear();
            Console.WriteLine("Dier registreren");
            Organise.Line6();
            Console.Write("Voer naam van dier in: ");
            string naam = Console.ReadLine();
 
            string type = "Dier";

            string oorsprong; // Declareer de variabele buiten de do-while loop zodat ik het voor de do while als conditie kan gebruiken

            do // do-while loop om alleen correcte oorsprong input te accepteren
            {
                Console.Write("Voer oorsprong in (inheems/exoot): ");
                oorsprong = Console.ReadLine();

                if (oorsprong.ToLower() == "exoot")
                {
                    oorsprong = "Exoot"; // Standaardiseer de waarde

                }
                else if (oorsprong.ToLower() == "inheems")
                {
                    oorsprong = "Inheems"; // Standaardiseer de waarde

                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Je kan alleen kiezen uit inheems of exoot");
                }

            } while (oorsprong != "Exoot" && oorsprong != "Inheems"); // Er wordt een foutmelding gegeven totdat alleen 'inheems' of 'exoot' ingevuld wordt 

            Console.Write("Voer leefgebied in: ");
            string leefgebied = Console.ReadLine();

            Console.Write("Locatie van waarneming: ");
            string locatie = Console.ReadLine();


            Console.WriteLine();
            Console.WriteLine("Bevestig informatie");
            Organise.Line1();
            
            Console.WriteLine($" - Naam: {naam}\n - Soort: {oorsprong}\n - Leefgebied: {leefgebied}\n - Waargenomen in: {locatie}");                     
            Organise.Line1();

            // Geef gebruiker de optie om de registratie te bevestigen of om te annuleren en terug naar het menu te gaan
            Console.WriteLine("1. Registratie voltooien\n2. Annuleren");

            string input = Console.ReadLine();


            if (input == "1")
            {

                OrganismeData.Toevoegen(new Dier
                {
                    Naam = naam,
                    Type = "Dier",
                    Oorsprong = oorsprong,
                    Leefgebied = leefgebied,
                    Locatie = locatie,
                    RegistratieDatum = DateTime.Now
                });

                // Voeg dier toe aan de database
                Database.ToevoegenNaarDatabase(new Dier
                {
                    Naam = naam,
                    Type = "Dier",
                    Oorsprong = oorsprong,
                    Leefgebied = leefgebied,
                    Locatie = locatie,
                    RegistratieDatum = DateTime.Now
                });

                Console.Clear();
                Console.WriteLine("\nRegistratie voltooid");
                Organise.Line2();


            }

            else if (input == "2")
            {
                Console.Clear();
                Console.WriteLine("\nRegistratie geannuleerd");
                Organise.Line3();
                return;
            }
        }

        public static void Plant()
        {
            List<Organisme> planten = OrganismeData.Lijst();
            bool terug = false;

            Console.WriteLine("Plant registreren");
            Organise.Line5();
            Console.Write("Voer naam van plant in: ");

            string naam = Console.ReadLine();
           
           string type = "Plant";

            string oorsprong; // Declareer de variabele buiten de do-while loop zodat ik het voor de do while als conditie kan gebruiken

            do // do-while loop om alleen correcte oorsprong input te accepteren
            {
                Console.Write("Voer oorsprong in (inheems/exoot): ");
                oorsprong = Console.ReadLine();

                if (oorsprong.ToLower() == "exoot")
                {
                    oorsprong = "Exoot"; // Standaardiseer de waarde

                }
                else if (oorsprong.ToLower() == "inheems")
                {
                    oorsprong = "Inheems"; // Standaardiseer de waarde

                }
                else
                {
                    Console.WriteLine("\nJe kan alleen kiezen uit inheems of exoot");
                }

            } while (oorsprong != "Exoot" && oorsprong != "Inheems");


            Console.Write("Voer hoogte van plant in meters in: ");
            string hoogte = Console.ReadLine(); // converteer string naar int

            Console.Write("Locatie van waarneming: ");
            string locatie = Console.ReadLine();


            Console.WriteLine("\nBevestig informatie");
            Organise.Line1();

            Console.WriteLine($" - Naam: {naam}\n - Soort: {oorsprong}\n - Hoogte: {hoogte} meter\n - Waargenomen in: {locatie}");
            Organise.Line1();


            // Geef gebruiker de optie om de registratie te bevestigen of om te annuleren en terug naar het menu te gaan
            Console.WriteLine("1. Registratie voltooien\n2. Annuleren");

            string input = Console.ReadLine();

            if (input == "1")
            {

                OrganismeData.Toevoegen(new Plant
                {
                    Naam = naam,
                    Type = "Plant",
                    Oorsprong = oorsprong,
                    HoogteInMeters = hoogte,
                    Locatie = locatie,
                    RegistratieDatum = DateTime.Now
                });

                // Voeg plant toe aan de database
                Database.ToevoegenNaarDatabase(new Plant
                {
                    Naam = naam,
                    Type = "Plant",
                    Oorsprong = oorsprong,
                    HoogteInMeters = hoogte,
                    Locatie = locatie,
                    RegistratieDatum = DateTime.Now
                });

                Console.Clear();
                Console.WriteLine($"\nRegistratie voltooid");
                
                Organise.Line2();

            }

            else if (input == "2")
            {
                Console.Clear();
                Console.WriteLine("\nRegistratie geannuleerd");
                Organise.Line3();
                return;
            }
        }
    }
}
