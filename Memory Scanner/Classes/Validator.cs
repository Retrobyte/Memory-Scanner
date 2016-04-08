using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory_Scanner.Classes
{
    public static class Validator
    {
        public static bool isIntDouble(string input)
        {
            if (input.Length - input.Replace(".", string.Empty).Length > 1)
                return false;

            foreach (char c in input)
                if (!char.IsDigit(c) && c != '.')
                    return false;

            return true;
        }
    }
}
