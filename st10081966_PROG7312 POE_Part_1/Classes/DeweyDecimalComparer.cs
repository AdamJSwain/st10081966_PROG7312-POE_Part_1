using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace st10081966_PROG7312_POE_Part_1.Classes
{
    public class DeweyDecimalComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            var xParts = x.Split('.');
            var yParts = y.Split('.');

            for (int i = 0; i < Math.Min(xParts.Length, yParts.Length); i++)
            {
                if (xParts[i] != yParts[i])
                {
                    if (int.TryParse(xParts[i], out int xNum) && int.TryParse(yParts[i], out int yNum))
                    {
                        return xNum.CompareTo(yNum); // Compare as numbers
                    }
                    else
                    {
                        return xParts[i].CompareTo(yParts[i]); // Compare as strings
                    }
                }
            }

            return x.Length.CompareTo(y.Length); // Fallback comparison
        }
    }
}
