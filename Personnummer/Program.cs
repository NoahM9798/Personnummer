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
if (pnr.Length == 10)
{
    // Anropa vår funktion som kollar datumet
    if (IsDateValid(pnr))
    {
        Console.WriteLine("Månad och dag är korrekta!");
    }
    else
    {
        Console.WriteLine("Felaktigt datum (t.ex. månad 13 eller dag 32).");
    }
}
else
{
    Console.WriteLine("Du måste skriva 10 siffror.");
}

// --- FUNKTIONER / FUNCTIONS ---

//Giltiga datumkontroll
bool IsDateValid(string pnr)
{
    try
    {
        int yy = int.Parse(pnr.Substring(0, 2)); // År
        int month = int.Parse(pnr.Substring(2, 2)); // Månad
        int day = int.Parse(pnr.Substring(4, 2)); // Dag

        // Bestäm århundrade
        int currentYear = DateTime.Now.Year % 100; // ex: 26 för 2026
        int century;

        if (yy > currentYear)
            century = 1900;
        else
            century = 2000;

        int year = century + yy;

        // Skapa DateTime för att validera datum
        DateTime dt = new DateTime(year, month, day);
        return true;
    }
    catch
    {
        return false; // Ogiltigt datum
    }
}

// Luhn-kontroll sista siffran
bool IsLuhnValid(string pnr)
{
    int sum = 0;

    for (int i = 0; i < 9; i++) // De 9 första siffrorna används
    {
        int digit = int.Parse(pnr[i].ToString());

        // Dubbel varannan siffra (index 0,2,4,6,8)
        if (i % 2 == 0)
            digit *= 2;

        // Om produkten >9, summera siffrorna (t.ex. 12 → 1+2=3)
        if (digit > 9)
            digit -= 9;

        sum += digit;
    }

    // Beräkna kontrollsiffra
    int checkDigit = (10 - (sum % 10)) % 10;

    // Jämför med sista siffran
    return checkDigit == int.Parse(pnr[9].ToString());
}
if (IsDateValid(pnr))
{
    if (IsLuhnValid(pnr))
    {
        Console.WriteLine("Personnumret är korrekt!");
    }
    else
    {
        Console.WriteLine("Felaktig kontrollsiffra!");
    }
}
else
{
    Console.WriteLine("Felaktigt datum (t.ex. månad 13 eller dag 32).");
}
