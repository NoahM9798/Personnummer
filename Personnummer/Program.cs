Console.Write("Skriv in ett personnummer (10 siffror): ");
long personnummer = long.Parse(Console.ReadLine()!);


bool MonthIsValid(long personnummer)
{
    long month = (personnummer / 1000000) % 100;
    return month >= 1 && month <= 12;
}