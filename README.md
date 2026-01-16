#Personnummer Validator
Denna applikation är en .NET 10-baserad lösning för att validera svenska personnummer. Projektet innehåller ett konsolprogram för interaktion, ett bibliotek för valideringslogik samt enhetstester för att säkerställa kvaliteten.

Svenska regler för personnummer
Ett svenskt personnummer för fysiska personer består av 10 eller 12 siffror. Denna applikation är utformad för att hantera 10-siffriga nummer i formatet ÅÅMMDDXXXX.

Födelsedatum (ÅÅMMDD): De sex första siffrorna anger födelseår, månad och dag.

Födelsenummer (siffra 7–9): Tre siffror som är ett löpnummer för personer födda samma dag.

Kontrollsiffra (siffra 10): Den sista siffran används för att verifiera att numret är korrekt enligt Luhn-algoritmen.

Hur applikationen genomför kontrollen
Valideringen sker i klassen PersonnummerValidator.cs genom följande steg:

Längdkontroll (IsCorrectLength): Verifierar att inmatningen består av exakt 10 tecken.

Datumvalidering (IsDateValid): Kontrollerar att månaden är mellan 01 och 12, samt att dagen är mellan 01 och 31.

Luhn-algoritmen (IsControlDigitValid): * Siffrorna på udda positioner multipliceras med 2, och siffrorna på jämna positioner med 1.

Om produkten blir tvåsiffrig adderas siffrorna (t.ex. 12 blir 1 + 2 = 3).

Alla resulterande siffror summeras, och kontrollsiffran beräknas som det tal som krävs för att summan ska bli jämnt delbar med 10.

Dokumentation för lokal körning
Förutsättningar
.NET 10.0 SDK installerat på din dator.

Kör applikationen
Öppna en terminal i projektets rotmapp.

Navigera till projektmappen: cd Personnummer.

Kör programmet:

Bash

dotnet run
Ange ett personnummer (t.ex. 811218-9876) när programmet ber om det.

Kör tester
Applikationen använder xUnit för enhetstester.

Navigera till testmappen: cd Enhetstest.

Kör testerna:

Bash

dotnet test
Detta testar bland annat längd, datumformat och kontrollsiffran.

Körning med Docker
Applikationen finns tillgänglig som en Docker-container för enkel körning utan lokal .NET-installation.

1. Dra ner (pull) containern
Ersätt [ANVÄNDARNAMN] med ditt DockerHub-användarnamn:

Bash

docker pull [ANVÄNDARNAMN]/personnummer-app:latest
2. Kör containern
Eftersom programmet kräver inmatning från användaren måste det köras i interaktivt läge (-it):

Bash

docker run -it [ANVÄNDARNAMN]/personnummer-app
Projektstruktur
Personnummer/: Huvudprojektet med logik och konsolgränssnitt.

Enhetstest/: Testprojekt som validerar algoritmerna.

.github/workflows/: CI/CD-konfiguration för automatiserade tester och publicering. Personnummer
