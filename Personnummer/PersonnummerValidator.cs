using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personnummer
{
    public class PersonnummerValidator
    {
        public bool IsCorrectLength(string personnummer)
        {
            return personnummer != null && personnummer.Length == 10;
        }

        public bool IsDateValid(string pnr)
        {
            // PNR format: YYMMDD-XXXX
            // Index:      0123456789...

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
        public bool IsControlDigitValid(long pnr)
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

        public string HyphenRemover(string input)
        {
            return input.Replace("-", "").Replace(" ", "");
        }
    }
}
