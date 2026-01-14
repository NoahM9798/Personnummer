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
        Console.WriteLine("✅ Månad och dag är korrekta!");
    }
    else
    {
        Console.WriteLine("❌ Felaktigt datum (t.ex. månad 13 eller dag 32).");
    }
}
else
{
    Console.WriteLine("Du måste skriva 10 siffror.");
}

// --- FUNKTIONER / FUNCTIONS ---

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