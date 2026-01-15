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


// --- FUNKTIONER / FUNCTIONS ---


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

