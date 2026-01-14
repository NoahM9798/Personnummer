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
    }
}
