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

bool IsDateValid(string pnr)
{
    try
    {
        int yy = int.Parse(pnr.Substring(0, 2));    // År
        int month = int.Parse(pnr.Substring(2, 2)); // Månad
        int day = int.Parse(pnr.Substring(4, 2));   // Dag

        // Bestäm århundrade: 1900- eller 2000-tal
        int currentYear = DateTime.Now.Year % 100; // t.ex. 26 för 2026
        int century = (yy > currentYear) ? 1900 : 2000;
        int year = century + yy;

        // Skapa DateTime för att kolla om datumet finns
        DateTime dt = new DateTime(year, month, day);

        return true; // Datumet är giltigt
    }
    catch
    {
        return false; // Ogiltigt datum (t.ex. 31 februari)
    }
}


bool IsControlDigitValid(long pnr)
{
    // Vi gör om talet till en sträng för att enkelt kunna loopa igenom siffrorna.
    // .PadLeft(10, '0') ser till att vi får 10 tecken även om personnumret börjar på 0.
    string s = pnr.ToString().PadLeft(10, '0');

    int sum = 0;

    // Vi loopar igenom de första 9 siffrorna
    for (int i = 0; i < 9; i++)
    {
        // Hämta siffran som ett heltal
        int digit = int.Parse(s[i].ToString());

        // Multiplicera varannan siffra med 2 och varannan med 1
        // (Index 0, 2, 4... gånger 2 | Index 1, 3, 5... gånger 1)
        int multiplier = (i % 2 == 0) ? 2 : 1;
        int product = digit * multiplier;

        // Om produkten blir 10 eller mer (t.ex. 6*2=12), 
        // ska vi addera siffersumman (1+2=3). 
        // Ett snabbt sätt att göra det är att ta produkten minus 9.
        if (product > 9)
        {
            sum += (product - 9);
        }
        else
        {
            sum += product;
        }
    }

    // Beräkna vad kontrollsiffran BORDE vara:
    // Ta summan, hitta närmsta högre tiotal och se mellanskillnaden.
    int calculatedControlDigit = (10 - (sum % 10)) % 10;

    // Hämta den faktiska sista siffran från personnumret
    int actualControlDigit = int.Parse(s[9].ToString());

    // Stämmer de överens?
    return calculatedControlDigit == actualControlDigit;
}
