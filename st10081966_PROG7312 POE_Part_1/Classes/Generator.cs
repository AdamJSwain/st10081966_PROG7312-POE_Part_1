using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace st10081966_PROG7312_POE_Part_1.Classes
{
    internal class Generator
    {
        private Random random;

        public Generator()
        {
            random = new Random();
        }

        public string GenerateRandomDeweyDecimal()
        {
            int x = random.Next(100, 1000);  // Generate a random 3-digit number
            int y = random.Next(10, 100);    // Generate a random 2-digit number
            string z = GenerateRandomLetters(3); // Generate a random 3-letter string

            // Format the Dewey Decimal number
            string deweyDecimal = $"{x}.{y:D2}{z}";

            return deweyDecimal;
        }

        private string GenerateRandomLetters(int length)
        {
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] randomLetters = new char[length];
            for (int i = 0; i < length; i++)
            {
                randomLetters[i] = letters[random.Next(letters.Length)];
            }
            return new string(randomLetters);
        }
    }
}
