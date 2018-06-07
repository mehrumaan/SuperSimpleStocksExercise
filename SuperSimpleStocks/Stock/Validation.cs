using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSimpleStocks
{
    public class Validation
    {
        public static void GreaterThan(string argumentName, double value, double valid)
        {
            if(value <= valid)
                throw new ArgumentOutOfRangeException("The value should be greater than", argumentName);
        }

        public static void NotNullOrEmpty(string argumentName, string value)
        {
            if (value == null)
                throw new ArgumentNullException(argumentName);
            if (value.Length == 0)
                throw new ArgumentOutOfRangeException();
        }

        public static void NotNull<T>(string argument, T var)
        {
            if(var == null)
            {
                throw new ArgumentNullException(argument);
            }
        }
    }
}
