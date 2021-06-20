using System;

Console.WriteLine("*** C# 9 Features ***\n");

//----------------------------------------------------------------------------------
// CEREMONY
//namespace ConsoleAppProject
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Hello World");
//        }
//    }
//}
//--------------------------------------------------------------------------------

//--------------------------------------------------------------------------------
// TOP LEVEL CALLS
//---
// Opstarten vanuit .cmd:
// C:\Blog\CSharp9\CSharp9Solution\ConsoleAppProject\bin\Debug\net5.0\ConsoleAppProject.cmd
//---
// Inhoud .cmd:
// @echo off
// "C:\Blog\CSharp9\CSharp9Solution\ConsoleAppProject\bin\Debug\net5.0\ConsoleAppProject.exe" 1 2
// pause
//---
// Console.WriteLine($"de eerste inkomende argument is {args[0]}.");
// Console.WriteLine($"de tweede inkomende argument is {args[1]}.");
// Console.WriteLine($"en bij elkaar opgeteld, {args[0]} + {args[1]} = " +
//                   $"{ optellen(int.Parse(args[0]), int.Parse(args[1])) }.\n");

// static double optellen(int x, int y)
// {
//     return x + y;
// }
//--------------------------------------------------------------------------------

//--------------------------------------------------------------------------------
// INIT ONLY SETTERS
// Instantiëren - object initializer
EIGENAAR eigenaar1 = new EIGENAAR { ID = 1, Omschrijving = "Sandra's auto", Regio = "Noord" };
// Het object
Console.WriteLine($"ID: { eigenaar1.ID} Omschrijving: { eigenaar1.Omschrijving}");
// Dit mag niet want het is geïnstantieerd
// eigenaar1.ID = 2;
//--------------------------------------------------------------------------------

//--------------------------------------------------------------------------------
//FIT AND FINISH
// Object initializer
// Niks mis mee, maar we moeten wel twee keer opgeven dat het gaat om klasse EIGENAAR
EIGENAAR eigenaar2 = new EIGENAAR { ID = 2, Omschrijving = "Petra's auto", Regio = "Midden" };
Console.WriteLine($"ID: { eigenaar2.ID} Omschrijving: { eigenaar2.Omschrijving}");
//--------------------------------------------------------------------------------

//--------------------------------------------------------------------------------
// VAR
// Met de var lukt het ook, je hoeft maar één keer op te geven dat het gaat om klasse EIGENAAR
// maar de var wordt beschouwd als less 'readable'
var eigenaar3 = new EIGENAAR { ID = 3, Omschrijving = "Olga's auto", Regio = "Zuid" };
Console.WriteLine($"ID: { eigenaar3.ID} Omschrijving: { eigenaar3.Omschrijving}");
//--------------------------------------------------------------------------------

//--------------------------------------------------------------------------------
// FIT AND FINISH
// Nieuw in C# 9 je hoeft maar één keer op te geven dat het gaat om klasse EIGENAAR
EIGENAAR eigenaar4 = new() { ID = 4, Omschrijving = "Henk's auto", Regio = "Midden" };
Console.WriteLine($"ID: { eigenaar4.ID} Omschrijving: { eigenaar4.Omschrijving}");
//--------------------------------------------------------------------------------

//--------------------------------------------------------------------------------
// Target typing: 
// aanleveren van waarden in de volgorde
// zoals gedefinieerd in de constructor
EIGENAAR eigenaar5 = new EIGENAAR(5, "Henk's auto", "Noord");
Console.WriteLine($"ID: { eigenaar5.ID} Omschrijving: { eigenaar5.Omschrijving}");
// Nieuw in C# 9  je hoeft maar één keer op te geven dat het gaat om klasse EIGENAAR
EIGENAAR eigenaar6 = new(6, "Jan's auto", "Noord");
Console.WriteLine($"ID: { eigenaar6.ID} Omschrijving: { eigenaar6.Omschrijving}\n");
//--------------------------------------------------------------------------------

//--------------------------------------------------------------------------------
// RELATIONAL PATTERN
// Relational patterns in methode GetRentePercentage
Console.WriteLine($"Bij een geleend bedrag van Eur 1000 is het rentepercentage { GetRentePercentage(1000) }%.");
Console.WriteLine($"Bij een geleend bedrag van Eur 3000 is het rentepercentage { GetRentePercentage(3000) }%.");
Console.WriteLine($"Bij een geleend bedrag van Eur 8000 is het rentepercentage { GetRentePercentage(8000) }%.");
Console.WriteLine($"Bij een geleend bedrag van Eur 12000 is het rentepercentage { GetRentePercentage(12000) }%.\n");

static double GetRentePercentage(double BedragLening)
{
    return BedragLening switch
    {
        > 0 and < 2500 => 13,
        >= 2500 and < 5000 => 15,
        >= 5000 and < 10000 => 18,
        _ => 25
    };
}
//--------------------------------------------------------------------------------

//--------------------------------------------------------------------------------
// LOGICAL PATTERN
Console.WriteLine($"Bij een geleend bedrag van Eur 200 is het rentepercentage { GetRentePercentage(200) }%.");
double rentePercentage = GetRentePercentage(200);

// De 'oude' manier
if (rentePercentage <= 13 || rentePercentage >= 25)
    Console.WriteLine($"Rentepercentage {rentePercentage} is niet de middenmoot want het percentage is <= 13% of groter dan 25%");

// Dit is mogelijk met C# 9:
if (rentePercentage is <= 13 or >= 25)
    Console.WriteLine($"Rentepercentage {rentePercentage} is niet de middenmoot want het percentage is <= 13% of groter dan 25%\n");
//--------------------------------------------------------------------------------

//--------------------------------------------------------------------------------
// CLASS TYPES
EIGENAAR eigenaar7 = new(7, "Jan's auto", "Noord");
EIGENAAR eigenaar8 = new(7, "Jan's auto", "Noord");
Console.WriteLine($"ToString implementation class: { eigenaar7 }");
Console.WriteLine($"Zijn de class objecten gelijk aan elkaar: { eigenaar7 == eigenaar8 }");

// RECORD TYPES
EIGENAARREC eigenaarrec1 = new(1, "Sandra's auto", "Noord");
EIGENAARREC eigenaarrec2 = new(1, "Sandra's auto", "Noord");
// eigenaarrec1.Omschrijving = "Petra's auto";

Console.WriteLine($"ToString implementation record:\n{ eigenaarrec1 }\n");

Console.WriteLine($"Zijn de record objecten gelijk aan elkaar value equals: { Equals(eigenaarrec1, eigenaarrec2) }");
Console.WriteLine($"Zijn de record objecten gelijk aan elkaar reference equals: { ReferenceEquals(eigenaarrec1, eigenaarrec2) }\n");

// Hashcode CLASS TYPES
Console.WriteLine($"GetHashCode object eigennaar7: { eigenaar7.GetHashCode() } ");
Console.WriteLine($"GetHashCode object eigennaar8: { eigenaar8.GetHashCode() }");

// Hashcode RECORD TYPES
Console.WriteLine($"GetHashCode object eigennaarrec1: { eigenaarrec1.GetHashCode() } ");
Console.WriteLine($"GetHashCode object eigennaarrec2: { eigenaarrec2.GetHashCode() }\n");

// Deconstructor RECORD TYPES
var (ID, Omschrijving, Regio) = eigenaarrec2;
Console.WriteLine($"Deconstructing uit object eigenaarrec2:\nID->{ID} Omschrijving->{Omschrijving} Regio->{Regio}\n");

// De With keyword RECORD TYPES
EIGENAARREC eigenaarrec3 = eigenaarrec2 with
{
    Omschrijving = "Petra's auto"
};
Console.WriteLine($"Overgenomen van Sandra:\n{ eigenaarrec3 }\n");

Console.WriteLine($"Aanroep methode .Over():\n{ eigenaarrec3.Over() }\n");

// Methodes RECORD TYPES
EIGENAARREC2 eigenaarrec4 = new(4, 1, "Marisca's auto", "Zuid");
Console.WriteLine($"Geërfd uit EIGENAARREC:\n{ eigenaarrec4 }");
//--------------------------------------------------------------------------------

// CLASS Class definitie
public class EIGENAAR
{
    // Constructor
    public EIGENAAR() { }

    // Constructor
    public EIGENAAR(int id, string omschrijving, string regio)
    {
        ID = id;
        Omschrijving = omschrijving;
        Regio = regio;
    }

    public int ID { get; init; }
    public string Omschrijving { get; set; }
    public string Regio { get; set; }
}
//--------------------------------------------------------------------------------

// RECORD TYPE definitie
public record EIGENAARREC(int ID, string Omschrijving, string Regio)
{
  public string VolledigeOmschrijving { get => $"In regio { Regio } bevindt zich { Omschrijving }";}

    public string Over()
    {
      return $"De Id van {Omschrijving} is { ID }.";
    }
};
//--------------------------------------------------------------------------------

// RECORD TYPE definitie - overerving uit EIGENAARREC
public record EIGENAARREC2(int milieusticker, int ID, string Omschrijving, string Regio) : EIGENAARREC(ID, Omschrijving, Regio); 