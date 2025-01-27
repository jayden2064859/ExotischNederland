using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ExotischNederland;

namespace EN_Test
{


    public class RegistratiesWijzigen
    {
        public static void IDLijst()
        {
            Console.Clear();
            foreach (var organisme in OrganismeData.Lijst())
            {
                Console.WriteLine($"{organisme.Naam} | {organisme.Type} | {organisme.Oorsprong} | {organisme.Locatie} | {organisme.ID}");
            }
        }

        public static void WijzigRegistratie(List<Organisme> organismen)
        {
            bool validID;
            Guid id = Guid.Empty;
            while (id == Guid.Empty)
            {
                Console.Write("Voer het ID van de registratie in die je wilt wijzigen: ");
                string idInput = Console.ReadLine();

                // Controleer of het ID geldig is.
                if (!Guid.TryParse(idInput, out id))
                {
                    Console.WriteLine("Ongeldig ID, probeer opnieuw.");
                }
            }

            var registratie = organismen.FirstOrDefault(o => o.ID == id);

            if (registratie != null)
            {
                validID = true;
                Console.Clear();

                if (registratie is Dier dier)
                {
                    Console.WriteLine($"{"Naam",-18} │ {"Type",-16} │ {"Soort",-16} │{"Leefgebied",-15} │ {"Locatie",-12} │ {"Registratie datum",-20}");
                    Console.WriteLine(new string('─', 115));
                    Console.WriteLine($"{dier.Naam,-18} │ {dier.Type,-16} │ {dier.Oorsprong,-16} │ {dier.Leefgebied,-14} │ {dier.Locatie,-12} │ {dier.RegistratieDatum:dd/MM/yyyy HH:mm:ss}");
                    Console.WriteLine(new string('─', 115));
                }

                else if (registratie is Plant plant)
                {
                    Console.WriteLine($"{"Naam",-18} │ {"Type",-16} │ {"Soort",-16} │{"Hoogte (meter)",-15} │ {"Locatie",-12} │ {"Registratie datum",-20}");
                    Console.WriteLine(new string('─', 115));
                    Console.WriteLine($"{plant.Naam,-18} │ {plant.Type,-16} │ {plant.Oorsprong,-16} │ {plant.HoogteInMeters,-14} │ {plant.Locatie,-12} │ {plant.RegistratieDatum:dd/MM/yyyy HH:mm:ss}");
                    Console.WriteLine(new string('─', 115));
                }

                Console.WriteLine("1. Informatie wijzigen\n2. Registratie verwijderen");
                Organise.Line4();

                string invoer = Console.ReadLine();
                if (invoer == "1")
                {
                    Organise.Line4();
                    Console.Write("Naam: ");
                    registratie.Naam = Console.ReadLine();

                    bool validType = false;
                    do
                    {
                        Console.Write("Type (plant/dier): ");
                        string type = Console.ReadLine();

                        if (type.ToLower() != "plant" && type.ToLower() != "dier")
                        {
                            Console.WriteLine("Ongeldige invoer");
                            validType = false;
                        }
                        else if (type.ToLower() == "plant")
                        {
                            validType = true;
                            registratie.Type = "Plant";
                        }
                        else if (type.ToLower() == "dier")
                        {
                            validType = true;
                            registratie.Type = "Dier";
                        }


                    } while (!validType); // lus om alleen juiste input te accepteren


                    bool validOorsprong = false;
                    do
                    {
                        Console.Write("Oorsprong (inheems/exoot): ");
                        string oorsprong = Console.ReadLine();

                        if (oorsprong.ToLower() != "inheems" && oorsprong.ToLower() != "exoot")
                        {
                            Console.WriteLine("Ongeldige invoer");
                            validOorsprong = false;
                        }
                        else if (oorsprong.ToLower() == "inheems")
                        {
                            validOorsprong = true;
                            registratie.Oorsprong = "Inheems";
                        }
                        else if (oorsprong.ToLower() == "exoot")
                        {
                            validOorsprong = true;
                            registratie.Oorsprong = "Exoot";
                        }

                    } while (!validOorsprong);

                    Console.Write("Locatie van waarneming: ");
                    string locatie = Console.ReadLine();

                    // Voor het geval dat de medewerker het Type veranderd, moet er een geheel nieuw instantie aangemaakt worden zodat de unieke 
                    // kenmerken van Dier en Plant gebruikt kunnen worden (Leefgebied/Hoogte)
                    if (registratie.Type == "Dier")
                    {
                        Dier nieuwDier = new Dier
                        {
                            Naam = registratie.Naam,
                            Type = "Dier",
                            Oorsprong = registratie.Oorsprong,
                            Locatie = locatie,
                            RegistratieDatum = DateTime.Now,

                        };

                        Console.Write("Leefgebied: ");
                        nieuwDier.Leefgebied = Console.ReadLine();
                        OrganismeData.Toevoegen(nieuwDier);
                        OrganismeData.Verwijderen(registratie.ID);

                    }


                    else if (registratie.Type == "Plant")
                    {
                        Plant nieuwePlant = new Plant
                        {
                            Naam = registratie.Naam,
                            Type = "Plant",
                            Oorsprong = registratie.Oorsprong,
                            Locatie = locatie,
                            RegistratieDatum = DateTime.Now
                        };

                        // Vraag unieke kenmerken op van de nieuwe Plant
                        Console.Write("Hoogte (in meters): ");
                        nieuwePlant.HoogteInMeters = Console.ReadLine();

                        OrganismeData.Toevoegen(nieuwePlant);
                        OrganismeData.Verwijderen(registratie.ID);
                    }

                    Console.Clear();
                    Console.WriteLine("Registratie gewijzigd");
                    Organise.Line3();
                    Menu.Return();

                }


                if (invoer == "2")
                {
                    
                    Console.WriteLine("\nWeet je zeker dat je deze registratie wil verwijderen?");
                    Organise.Line3();
                    Console.WriteLine("1. Definitief verwijderen\n2. Annuleren");
                    Organise.Line3();

                    string invoerVerwijderen = Console.ReadLine();
                    if (invoerVerwijderen == "1")
                    {
                        organismen.Remove(registratie);
                        Console.Clear();
                        Console.WriteLine("Registratie verwijderd");
                        Organise.Line3();
                        Menu.Return();
                    }

                    else if (invoerVerwijderen == "2")
                    {
                        Console.Clear();
                        Console.WriteLine("Verwijderen geannuleerd");
                        Organise.Line3();
                        Menu.Return();
                    }
                }
            }
        }
    }
}

                
        
    



                    
    

