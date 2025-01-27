using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ExotischNederland;
// Gebruik moet een input error bericht krijgen als iets anders dan A,B,C,D,X wordt ingevoerd
namespace EN_Test
{
    public static class Quiz
    {
        public static bool doorgaan; // Boolean om te bepalen wanneer de gebruiker terug naar het hoofdmenu gaat
        public static int fouteAntwoorden; // Houd de foute antwoorden bij zodat het aan het einde van de quiz laten zien kan worden

        public static void Beginnen()
        {
            doorgaan = true;
            fouteAntwoorden = 0;

            do
            {
                Console.Clear();
                Organise.Line5();
                Console.WriteLine("Welkom bij de Interactieve Natuur Quiz!");
                Organise.Line5();
                Console.WriteLine();
                Console.WriteLine("Test je kennis over inheemse en exotische soorten in Nederland!\nJe krijgt een reeks meerkeuzevragen (A, B, C of D).\n" +
                    "Elk correct antwoord is 1 punt waard.\nProbeer zoveel mogelijk goede antwoorden te geven.\n\nTyp je antwoord en druk op Enter om verder te gaan.\n" +
                    "Als je de Quiz wil beëindigen, typ 'X' en druk op Enter.\n");
 
                Organise.Line5();
                Console.WriteLine("Druk op Enter om te beginnen...");

                Console.ReadLine(); // Het spel begint wanneer de gebruiker een key invoert
                Console.Clear();

                int score = 0; // Score begint bij 0
                int fouteAntwoorden = 0;

                score += Vraag1();
                Vraag1Uitleg();
                if (!doorgaan) return; // Zorgt ervoor dat de gebruiker terug naar het hoofdmenu kan gaan wanneer X wordt ingevoerd
                VerderGaan();

                score += Vraag2();
                Vraag2Uitleg();
                if (!doorgaan) return;
                VerderGaan();

                score += Vraag3();
                Vraag3Uitleg();
                if (!doorgaan) return;
                VerderGaan();

                score += Vraag4();
                Vraag4Uitleg();
                if (!doorgaan) return;
                VerderGaan();

                score += Vraag5();
                Vraag5Uitleg();
                if (!doorgaan) return;
                VerderGaan();

                score += Vraag6();
                Vraag6Uitleg();
                if (!doorgaan) return;
                VerderGaan();

                score += Vraag7();
                Vraag7Uitleg();
                if (!doorgaan) return;
                VerderGaan();

                score += Vraag8();
                Vraag8Uitleg();
                if (!doorgaan) return;
                VerderGaan();

                score += Vraag9();
                Vraag9Uitleg();
                if (!doorgaan) return;
                VerderGaan();


                score += Vraag10();
                Vraag10Uitleg();
                if (!doorgaan) return;
                VerderGaan();

                score += Vraag11();
                Vraag11Uitleg();
                if (!doorgaan) return;
                VerderGaan();

                score += Vraag12();
                Vraag12Uitleg();
                if (!doorgaan) return;
                VerderGaan();

                score += Vraag13();
                Vraag13Uitleg();
                if (!doorgaan) return;
                VerderGaan();

                score += Vraag14();
                Vraag14Uitleg();
                if (!doorgaan) return;
                VerderGaan();

                ScoreBepalen(score);
                // Score bepalen

            } while (doorgaan == true); // De quiz zal door blijven gaan totdat de gebruiker besluit terug naar het menu te gaan
           
        }

        public static void VerderGaan()
        {
            if (!doorgaan) return;  // Na elke vraag wordt er gechecked of de gebruiker X heeft ingevoerd (doorgaan = false). Als dat het geval is verlaat gebruiker de quiz
            Console.WriteLine("Druk op Enter om verder te gaan");
            Console.ReadLine();  // Systeem wacht op input om naar de volgende vraag te gaan
            Console.Clear(); // Laat elke vraag op een nieuwe pagina zien voor overzichtelijkheid
        }

        public static void ScoreBepalen(int score)
        {
            int percentage = (int)((double)score / 14 * 100); // Bepaal het percentage dat goed beantwoord is

            Organise.Line4();
            Console.WriteLine("       Einde van de quiz!");
            Organise.Line4();
            Console.WriteLine("\nBedankt voor je deelname!\nHieronder vind je je resultaten:\n\n");
            Console.WriteLine($"Aantal juiste antwoorden: {score}\nAantal foute antwoorden: {fouteAntwoorden}\n\nJe behaalde score: {percentage}%\n");
            Organise.Line4();

            Menu.Return();
            Console.Clear();
            doorgaan = false; // Zorgt ervoor dat het spel daadwerkelijk stopt
            
        }

        public static int CheckAntwoord(string correcteAntwoord) // Methode om het gegeven antwoord met het correcte antwoorden te vergelijken
        {

            string gegevenAntwoord = Console.ReadLine();

            if (gegevenAntwoord.ToLower() == "x")
            {
                Console.Clear();
                doorgaan = false;
               
                return 0;
            }
            if (gegevenAntwoord.ToLower() != correcteAntwoord)
            {                
                Console.WriteLine("\nHelaas, je hebt het niet goed.\n");
                fouteAntwoorden += 1;
                
                return 0;
            }
            else
            {
                Console.WriteLine("\nCorrect!\n");

                return 1;
            }
        }

        public static int Vraag1() // int i.p.v void omdat het een score terug moet geven
        {
            Console.WriteLine("Vraag 1");
            Organise.Line1();
            Console.WriteLine("Wat betekent de term 'exoten' in de natuur?\n\n" +
                "  A) Bedreigde plant- en diersoorten\n" +
                "  B) Planten en dieren uit een ander land die zich in Nederland hebben gevestigd\n" +
                "  C) Planten en dieren waar er slechts een klein aantal van zijn in Nederland\n" +
                "  D) Soorten die vrijwel niet meer in hun oorspronkelijke leefgebied bestaan\n\n" +
                "  X) Terug naar menu");

            Organise.Line1();
            Console.Write("Voer je antwoord in: ");


            return CheckAntwoord("b"); // Bepaal of de gebruiker correct beantwoord heeft en geef de bijbehorende score terug van de methode          

            
           
        }

        public static void Vraag1Uitleg()
        {
            Console.WriteLine("Exoten zijn organismen die oorspronkelijk niet in Nederland voorkomen, maar zich wel in ons land hebben gevestigd.\n" +
                "Deze soorten kunnen zowel nuttige als schadelijke gevolgen hebben voor het ecosysteem. Ze vergroten de biodiversiteit,\nmaar verdringen daarmee soms ook" +
                "de inheemse soorten doordat het lokale ecosysteem daar niet op is voorbereid.\n");
            
        }
        
     
        public static int Vraag2()
        {
            Console.WriteLine("Vraag 2");
            Organise.Line1();
            Console.WriteLine("Wat betekent de term 'Inheemse soorten' in de natuur?\n\n" +
                "  A) Dieren en planten die oorspronkelijk in Nederland voorkomen\n" +
                "  B) Soorten die oorspronkelijk uit Nederland en andere delen van Europa komen\n" +
                "  C) Soorten die uit een ander land met een vergelijkbaar klimaat komen\n" +
                "  D) Soorten die zich goed kunnen aanpassen aan lokale leefomstandigheden\n\n" +
                "  X) Terug naar menu");

            Organise.Line1();
            Console.Write("Voer je antwoord in: ");

            return CheckAntwoord("a");
          
           
        }

        public static void Vraag2Uitleg()
        {
            Console.WriteLine("Inheemse soorten zijn planten en dieren die van nature in Nederland voorkomen.\n" +
                "Ze hebben zich aangepast aan de lokale omgevingsomstandigheden en vormen een belangrijk onderdeel van het ecosysteem.\n");
            
        }   

        public static int Vraag3()
        {

            Console.WriteLine("Vraag 3");
            Organise.Line1();
            Console.WriteLine("Wat wordt bedoelt met de term 'invasieve soort'?\n\n" +
                "  A) Een exotische soort die opzettelijk wordt geïntroduceerd om het ecosysteem te verbeteren\n" +
                "  B) Een inheemse soort die groeit op plekken waar het normaal niet voorkomt\n" +
                "  C) Een soort die zich snel verspreidt en de lokale biodiversiteit bedreigt\n" +
                "  D) Een soort die zich snel kan aanpassen aan veranderende omgevingen\n\n" +
                "  X) Terug naar menu");

            Organise.Line1();
            Console.Write("Voer je antwoord in: ");

            return CheckAntwoord("c");
           
        }

        public static void Vraag3Uitleg()
        {
            Console.WriteLine("Invasieve soorten zijn organismen die zich snel verspreiden in nieuwe gebieden, vaak ten koste van inheemse soorten.\n" +
                "Dit kan de lokale biodiversiteit bedreigen en ecologische en economische schade veroorzaken.\n");
        }

        public static int Vraag4()
        {
            Console.WriteLine("Vraag 4");
            Organise.Line1();
            Console.WriteLine("Welke van de volgende kruiden is een inheemse plant in Nederland?\n\n" +
                "  A) Rozemarijn\n" +
                "  B) Kamille\n" +
                "  C) Basilicum\n" +
                "  D) Tijm\n\n" +
                "  X) Terug naar menu");

            Organise.Line1();
            Console.Write("Voer je antwoord in: ");

            return CheckAntwoord("b");

        }

        public static void Vraag4Uitleg()
        {
            Console.WriteLine("Kamille is een inheemse plant in Nederland, die in tuinen en natuurgebieden voorkomt.\n" +
                "Het wordt veel gebruikt voor de medicinale eigenschappen, zoals het bevorderen van rust\nen het verlichten van maagklachten.\n");
        }

        public static int Vraag5()
        {

            Console.WriteLine("Vraag 5");
            Organise.Line1();
            Console.WriteLine("Welke inheemse Nederlandse plant staat bekend om zijn medicinale eigenschappen?\n\n" +
                "  A) Lavendel\n" +
                "  B) Kamille\n" +
                "  C) Aloë vera\n" +
                "  D) Brandnetel\n\n" +
                "  X) Terug naar menu");

            Organise.Line1();
            Console.Write("Voer je antwoord in: ");

            return CheckAntwoord("d");
        }

        public static void Vraag5Uitleg()
        {
            Console.WriteLine("Brandnetel is een inheemse plant die vaak wordt gebruikt in de natuurgeneeskunde voor zijn ontstekingsremmende\n" +
                "en pijnverlichtende eigenschappen. De bladeren en stelen worden vaak gebruikt voor kruidenremedies en infusies.\n");
        }
        public static int Vraag6()
        {

            Console.WriteLine("Vraag 6");
            Organise.Line1();
            Console.WriteLine("Welk roofdier is sinds een paar jaar weer gesignaleerd in Nederland?\n\n" +
                "  A) Wolf\n" +
                "  B) Lynx\n" +
                "  C) Das\n" +
                "  D) Vos\n\n" +
                "  X) Terug naar menu");

            Organise.Line1();
            Console.Write("Voer je antwoord in: ");

            return CheckAntwoord("a");
        }

        public static void Vraag6Uitleg()
        {
            Console.WriteLine("De wolf, die ooit uit Nederland verdween, is opnieuw gesignaleerd de afgelopen jaren.\n" +
                "Dit is een teken van het herstel van wilde natuurgebieden, en de wolf speelt een belangrijke rol\n" +
                "in het reguleren van prooidieren.\n");
        }

        public static int Vraag7()
        {

            Console.WriteLine("Vraag 7");
            Organise.Line1();
            Console.WriteLine("Welke provincie heeft de meeste natuurgebieden in Nederland?\n\n" +
                "  A) Gelderland\n" +
                "  B) Noord-Holland\n" +
                "  C) Limburg\n" +
                "  D) Friesland\n\n" +
                "  X) Terug naar menu");

            Organise.Line1();
            Console.Write("Voer je antwoord in: ");

            return CheckAntwoord("a");
        }

        public static void Vraag7Uitleg()
        {
            Console.WriteLine("Gelderland is de provincie met de meeste natuurgebieden, waaronder de Veluwe, de Hoge Veluwe, en de Gelderse Poort.\n" +
                "Deze regio's zijn van groot belang voor het behoud van de biodiversiteit in Nederland.\n");
        }

        public static int Vraag8()
        {
            Console.WriteLine("Vraag 8");
            Organise.Line1();
            Console.WriteLine("Welk dier mag niet in een dierentuin in Nederland gehouden worden?\n\n" +
                "  A) Rode panda\n" +
                "  B) Capybara\n" +
                "  C) Pinguïn\n" +
                "  D) Koala\n\n" +
                "  X) Terug naar menu");

            Organise.Line1();
            Console.Write("Voer je antwoord in: ");

            return CheckAntwoord("d");  
        }

        public static void Vraag8Uitleg()
        {
            Console.WriteLine("Koala's mogen niet in Nederland gehouden worden vanwege specifieke eisen die ze stellen aan hun leefomgeving en dieet.\n" +
                "Deze dieren zijn sterk afhankelijk van hun natuurlijke habitat, wat het moeilijk maakt om ze buiten Australië op de juiste manier te verzorgen.\n" +
                "Om hun welzijn te waarborgen, is het verboden om koala's in Nederland te houden.\n");
        }

        public static int Vraag9()
        {
            Console.WriteLine("Vraag 9");
            Organise.Line1();
            Console.WriteLine("Hoe kunnen inheemse soorten in hun natuurlijke omgeving beschermd worden?\n\n" +
                "  A) Door invasieve soorten actief te monitoren en te verwijderen\n" +
                "  B) Door het introduceren van meer exotische diersoorten\n" +
                "  C) Door de aanwezigheid van alle soorten in natuurgebieden te stimuleren\n" +
                "  D) Door nieuwe wetten in te voeren die het legaal maken invasieve soorten te planten\n\n" +
                "  X) Terug naar menu");

            Organise.Line1();
            Console.Write("Voer je antwoord in: ");

            return CheckAntwoord("a");

        }

        public static void Vraag9Uitleg()
        {
            Console.WriteLine("De meest effectieve manier om inheemse soorten te beschermen is doorinvasieve soorten\nvoortdurend te monitoren en te verwijderen." +
                "\nInvasieve soorten kunnen schade veroorzaken aan inheemse planten en dieren omdat ze\nconcurreren om ruimte en voedselbronnen." +
                " Door invasieve soorten onder controle te houden,\nkrijgt de inheemse flora en fauna de kans om zich beter te ontwikkelen.\n");
        }

        public static int Vraag10()
        {
            Console.WriteLine("Vraag 10");
            Organise.Line1();
            Console.WriteLine("Wat is de grootste bedreiging voor de biodiversiteit in Nederland?\n\n" +
                "  A) Klimaatverandering\n" +
                "  B) Stedelijke ontwikkeling\n" +
                "  C) Overbevissing\n" +
                "  D) Jacht\n\n" +
                "  X) Terug naar menu");

            Organise.Line1();
            Console.Write("Voer je antwoord in: ");

            return CheckAntwoord("a");
        }

        public static void Vraag10Uitleg()
        {
            Console.WriteLine("Klimaatverandering heeft wereldwijd een grote impact op biodiversiteit, door de verandering\nvan leefomstandigheden van vele soorten.\n" +
                "Het beïnvloedt migratiepatronen, overleving, en het seizoen van groei van veel soorten.\nEen andere grote bedreiging op het ecosysteem is vervuiling.\n");
        }

        public static int Vraag11()
        {
            Console.WriteLine("Vraag 11");
            Organise.Line1();
            Console.WriteLine("Welke van de volgende dieren is in Nederland beschermd?\n\n" +
                "  A) Eekhoorn\n" +
                "  B) Vos\n" +
                "  C) Vleermuis\n" +
                "  D) Zeehond\n\n" +
                "  X) Terug naar menu");

            Organise.Line1();
            Console.Write("Voer je antwoord in: ");

            return CheckAntwoord("c");
        }

        public static void Vraag11Uitleg()
        {
            Console.WriteLine("Vleermuizen zijn beschermd in Nederland onder de Wet natuurbescherming.\n" +
                "Deze diersoorten spelen een cruciale rol in het ecosysteem door het eten van insecten.\n");
        }

        public static int Vraag12()
        {
            Console.WriteLine("Vraag 12");
            Organise.Line1();
            Console.WriteLine("Wat zou er gebeuren als roofdieren uit een ecosysteem verdwijnen?\n\n" +
                "  A) Prooisoorten nemen af doordat ze te veel concurrentie ervaren\n" +
                "  B) Het ontbreken van roofdieren veroorzaakt overpopulatie van prooisoorten, wat schade aan het ecosysteem veroorzaakt.\n" +
                "  C) Ecosystemen worden productiever zonder natuurlijke vijanden\n" +
                "  D) De biodiversiteit neemt toe doordat alle dieren meer overlevingskansen hebben\n\n" +
                "  X) Terug naar menu");

            Organise.Line1();
            Console.Write("Voer je antwoord in: ");

            return CheckAntwoord("b");
        }

        public static void Vraag12Uitleg()
        {
            Console.WriteLine("Als roofdieren verdwijnen, kunnen prooisoorten zich zonder controle snel verspreiden.\n" +
                "Dit leidt vaak tot een te grote populatie, wat resulteert in overbegrazing of het uitputten van voedselbronnen.\n" +
                "Deze verstoring kan de balans in het ecosysteem ernstig aantasten en andere soorten in gevaar brengen.\n");
        }

        public static int Vraag13()
        {
            Console.WriteLine("Vraag 13");
            Organise.Line1();
            Console.WriteLine("Welke term past het beste bij een wasbeer (in Nederland)?\n\n" +
                "  A) Inheemse soort\n" +
                "  B) Exotische soort\n" +
                "  C) Invasieve soort\n" +
                "  D) Bedreigde soort\n\n" +
                "  X) Terug naar menu");

            Organise.Line1();
            Console.Write("Voer je antwoord in: ");

            return CheckAntwoord("c");
        }

        public static void Vraag13Uitleg() 
        {
            Console.WriteLine("Hoewel de wasbeer ook een exoot is, beschrijft de term 'invasieve soort' hun beter.\n" +
                "Dit komt doordat wasberen zich snel hebben verspreid, zich goed hebben aangepast aan hun nieuwe omgeving,\n" +
                "en ze ook een negatieve impact kunnen hebben op lokale ecosystemen, een typerend kenmerk van een invasieve soort.\n");
        }
        
        public static int Vraag14()
        {
            Console.WriteLine("Vraag 14");
            Organise.Line1();
            Console.WriteLine("Wat is een van de meest bedreigde dieren in Nederland?\n\n" +
                "  A) Hamster\n" +
                "  B) Egel\n" +
                "  C) Grijze Zeehond\n" +
                "  D) IJsvogel\n\n" +
                "  X) Terug naar menu");

            Organise.Line1();
            Console.Write("Voer je antwoord in: ");

            return CheckAntwoord("a"); 
        }

        public static void Vraag14Uitleg()
        {
            Console.WriteLine("De Europese hamster wordt in de Rode Lijst (een publicatie van de rijksoverheid over bedreigde diersoorten)\nvan 2020 als 'ernstig bedreigd' geclassificeerd.\n" +
                "De belangrijkste reden hiervoor is habitatverlies door intensivering van de landbouw,\nwaardoor geschikte leefomgevingen steeds zeldzamer worden.\n" +
                "Dit heeft geleid tot een drastische afname van hun populatie in Nederland.\n" +
                "Zonder bescherming is het voortbestaan van de soort in gevaar.\n");
        }

    }
}
