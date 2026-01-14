Console.Write("Skriv in personnummer (10 siffror, t.ex. 811218-9876): ");
string input = Console.ReadLine() ?? ""; // Läs in som TEXT (String)

// 1. Städa bort bindestreck om användaren skrev det
string pnr = input.Replace("-", "").Replace(" ", "");

// 2. Enkel kontroll att vi har 10 tecken
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
    // PNR format: YYMMDD-XXXX
    // Index:      012345...

    // Hämta MÅNAD (Tecken på plats 2 och 3)
    string monthString = pnr.Substring(2, 2);
    int month = int.Parse(monthString);

    // Hämta DAG (Tecken på plats 4 och 5)
    string dayString = pnr.Substring(4, 2);
    int day = int.Parse(dayString);

    // Kolla Månad (1 - 12)
    bool monthOk = (month >= 1 && month <= 12);

    // Kolla Dag (1 - 31)
    bool dayOk = (day >= 1 && day <= 31);

    return monthOk && dayOk;
}
static bool HarTioSiffror(string personnummer)
{
    if (string.IsNullOrWhiteSpace(personnummer))
        return false;

    // Ta bort bindestreck och plus
    string pnr = personnummer.Replace("-", "").Replace("+", "");

    // Om 12 siffror (inkl sekel), ta bort de två första
    if (pnr.Length == 12)
        pnr = pnr.Substring(2);

    // Kontrollera exakt 10 siffror
    return pnr.Length == 10 && pnr.All(char.IsDigit);
}