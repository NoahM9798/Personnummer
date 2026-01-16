using Personnummer;

Console.Write("Skriv in personnummer (10 siffror, t.ex. 811218-9876): ");
string input = Console.ReadLine() ?? ""; // Läs in som TEXT (String)
PersonnummerValidator validator = new PersonnummerValidator();

// 1. Städa bort bindestreck om användaren skrev det
string inputHyphenRemoved = validator.HyphenRemover(input);

// 2. Kontroll att datumet är giltligt.
if (validator.IsDateValid(inputHyphenRemoved))
{
    Console.WriteLine("[OK] Datumet är giltigt.");
}
else
{
    Console.WriteLine("[Fel] Felaktigt datum (t.ex. månad 13 eller dag 32).");
}


// 3. Kolla kontrollsiffra
if (validator.IsControlDigitValid(long.Parse(inputHyphenRemoved)))
{
    Console.WriteLine("[OK] Detta är ett giltligt personnummer!");
}
else
{
    Console.WriteLine("[Fel] Detta personnummer finns inte!");
}

