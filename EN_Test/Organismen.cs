using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Organisme // een class voor de kenmerken van een organisme
{

    // Eigenschappen van de class
    public string Naam { get; set; }
    public string Type { get; set; } 
    public string Oorsprong { get; set; } // "Inheems" of "Exoot" wordt geaccepteerd als input
    public string Locatie { get; set; }
    public DateTime RegistratieDatum { get; set; } // Bepaalt het tijdsstip en datum van de registratie

   
}

public class Dier : Organisme // Een subclass die bij Organisme hoort
{
    public string Leefgebied { get; set; } // Extra kenmerk specifiek voor dieren
}


public class Plant : Organisme // Een tweede subclass die bij Organisme hoort
{
    public string HoogteInMeters { get; set; } // Extra kenmerk specifiek voor planten

}

public static class OrganismeData // Een class voor het opslaan van de al geregistreerde organismen
{
    private static List<Organisme> organismen = new List<Organisme>();
    public static List<Organisme> Lijst()
    {
        return organismen;

    }

    public static void Toevoegen(Organisme organisme) // Een methode die gebruikt zal worden wanneer de gebruiker een organisme wil registreren
    {
        organismen.Add(organisme);
    }


}


