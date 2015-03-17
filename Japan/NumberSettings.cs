using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Japan
{
    public struct NumberSettings
    {
        // Words for Numbers (Index in Number Array)
        public int WordForZero; // 0
        public int WordForFour; // 4
        public int WordForSeven; // 7
        public int WordForNine; // 9
        public int WordForThousand; // 1'000
        public int WordForOneThousand; // 1'000

        public bool Space; // Seperate each "segment"

        // Constructor(s)
        public NumberSettings(int zero, int four, int seven, int nine, int thousand, int oneThousand, bool space)
        {
            WordForZero = zero;
            WordForFour = four;
            WordForSeven = seven;
            WordForNine = nine;
            WordForThousand = thousand;
            WordForOneThousand = oneThousand;
            Space = space;
        }

        // Checks if the settings are legit/legal/acceptable
        internal bool IfValidRoman()
        {
            // Bounds variables
            const int noZero = 3;
            const int noFour = 2;
            const int noSeven = 2;
            const int noNine = 2;
            const int noThousand = 2;
            const int noOneThousand = 2;

            // Bounds
            if (WordForZero < 0 || // Zero
                WordForZero >= noZero)
                return false;
            if (WordForFour < 0 || // Four
                WordForFour >= noFour)
                return false;
            if (WordForSeven < 0 || // Seven
                WordForSeven >= noSeven)
                return false;
            if (WordForNine < 0 || // Nine
                WordForNine >= noNine)
                return false;
            if (WordForThousand < 0 || // Thousand
                WordForThousand >= noThousand)
                return false;
            if (WordForOneThousand < 0 || // One Thousand
                WordForOneThousand >= noOneThousand)
                return false;

            // No exceptions found
            return true;
        }
        internal bool IfValidHiragana()
        {
            // Bounds variables
            const int noZero = 1;
            const int noFour = 2;
            const int noSeven = 2;
            const int noNine = 2;
            const int noThousand = 1;
            const int noOneThousand = 2;

            // Bounds
            if (WordForZero < 0 || // Zero
                WordForZero >= noZero)
                return false;
            if (WordForFour < 0 || // Four
                WordForFour >= noFour)
                return false;
            if (WordForSeven < 0 || // Seven
                WordForSeven >= noSeven)
                return false;
            if (WordForNine < 0 || // Nine
                WordForNine >= noNine)
                return false;
            if (WordForThousand < 0 || // Thousand
                WordForThousand >= noThousand)
                return false;
            if (WordForOneThousand < 0 || // One Thousand
                WordForOneThousand >= noOneThousand)
                return false;

            // No exceptions found
            return true;
        }

        // Default
        public static NumberSettings Default()
        {
            return new NumberSettings()
            {
                WordForZero = 2,
                WordForFour = 1,
                WordForThousand = 1
            };
        }
    }
}
