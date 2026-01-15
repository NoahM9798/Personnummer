Console.Write("Skriv in personnummer (10 siffror, t.ex. 811218-9876): ");
string input = Console.ReadLine() ?? ""; // Läs in som TEXT (String)

// 1. Städa bort bindestreck om användaren skrev det
string pnr = input.Replace("-", "").Replace(" ", "");

// 2. Kontroll att det bara är siffror.
if (!long.TryParse(pnr, out _))
{
    Console.WriteLine("Personnumret får bara innehålla siffror.");
    return;
}

// 3. Enkel kontroll att vi har 10 tecken
if (pnr.Length != 10)
{
    Console.WriteLine("Du måste skriva 10 siffror.");
    return;
}

// 4. Kolla datum och kontrollsiffra
//if (!IsDateValid(pnr))
//{
//    // Om datumet inte är korrekt
//    Console.WriteLine("[Fel] Felaktigt datum (t.ex. månad 13 eller dag 32).");
//}
//else
//{
//    // Om datumet är korrekt, kolla kontrollsiffran
//    long pnrNum = long.Parse(pnr); // konvertera till long för IsControlDigitValid

//    if (IsControlDigitValid(pnrNum))
//    {
//        Console.WriteLine("[OK] Personnumret är korrekt!");
//    }
//    else
//    {
//        Console.WriteLine("[Fel] Felaktig kontrollsiffra!");
//    }
//}


