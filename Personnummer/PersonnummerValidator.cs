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
    }
}
