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
        internal bool IfLegalSettings()
        {
            // Bounds
            if (WordForZero < 0 || // Zero
                WordForZero > 2)
                return false;
            if (WordForFour < 0 || // Four
                WordForFour > 1)
                return false;
            if (WordForSeven < 0 || // Seven
                WordForSeven > 1)
                return false;
            if (WordForNine < 0 || // Nine
                WordForNine > 1)
                return false;
            if (WordForThousand < 0 || // Thousand
                WordForThousand > 1)
                return false;
            if (WordForOneThousand < 0 || // One Thousand
                WordForOneThousand > 1)
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
