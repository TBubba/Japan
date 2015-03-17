using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Japan
{
    /// <summary>
    /// Translates numbers (integers and longs) to japanese (string)
    /// </summary>
    public static class Numbers
    {
        // Numbers as strings
        private static readonly string[][] _numbers = new string[][]
        {
            // 0 -> 9 [0 -> 9]
            new string[] {"nuru", "rei", "zero"},
            new string[] {"ichi"},
            new string[] {"ni"},
            new string[] {"san"},
            new string[] {"shi", "yon"},
            new string[] {"go"},
            new string[] {"roku"},
            new string[] {"nana", "shichi"},
            new string[] {"hachi"},
            new string[] {"kyuu", "ku"},
            
            // 10 [10]
            new string[] {"juu"},

            // 100 [11 -> 14]

            new string[] {"hyaku"},
            new string[] {"sanbyaku"}, // 300
            new string[] {"roppyaku"}, // 600
            new string[] {"happyaku"}, // 800

            // 1'000 [15 -> 18]
            new string[] {"sen", "zen"},
            new string[] {"sen", "issen"}, // 1000
            new string[] {"sanzen"}, // 3000
            new string[] {"hassen"}, // 8000

            // 10'000 [19]
            new string[] {"man"},

            // 100'000'000 [20]
            new string[] {"oku"}
        };

        // 432[1] (The lowest/smallest digit (0 - 9))
        private static string GetDigit_One(int digit)
        {
            // Only between 0 and 9
            if (digit < 0 || digit > 9)
                throw new Exception("Out of range.");

            // Return digit
            return _numbers[digit][0];
        }
        private static string GetDigit_One(int digit, int zero, int four, int seven, int nine)
        {
            // Only between 0 and 9
            if (digit < 0 || digit > 9)
                throw new Exception("Out of range.");

            // Chosen words
            if (digit == 0)
            {
                if (zero >= _numbers[0].Length)
                    throw new Exception("Index for zero is out of range.");
                return _numbers[0][zero];
            }
            if (digit == 4)
            {
                if (four >= _numbers[4].Length)
                    throw new Exception("Index for four is out of range.");
                return _numbers[4][four];
            }
            if (digit == 7)
            {
                if (seven >= _numbers[7].Length)
                    throw new Exception("Index for seven is out of range.");
                return _numbers[7][seven];
            }
            if (digit == 9)
            {
                if (nine >= _numbers[9].Length)
                    throw new Exception("Index for nine is out of range.");
                return _numbers[9][nine];
            }

            // Return digit
            return _numbers[digit][0];
        }

        // 43[2]1 (Deka-digits [0]0 - [9]9)
        private static string GetDigit_Two(int digit)
        {
            // Only between 0 and 9
            if (digit < 0 || digit > 9)
                throw new Exception("Out of range.");

            // Return digit
            return GetDigit_One(digit) + _numbers[10][0];
        }
        private static string GetDigit_Two(int digit, int zero, int four, int seven, int nine)
        {
            // Only between 0 and 9
            if (digit < 0 || digit > 9)
                throw new Exception("Out of range.");

            // Return digit
            return GetDigit_One(digit, zero, four, seven, nine) + _numbers[10][0];
        }

        // 4[3]21 (Hekto-digits [0]00 - [9]99)
        private static string GetDigit_Three(int digit)
        {
            // Only between 0 and 9
            if (digit < 0 || digit > 9)
                throw new Exception("Out of range.");

            // Exceptions
            if (digit == 3)
                return _numbers[12][0];
            if (digit == 6)
                return _numbers[13][0];
            if (digit == 8)
                return _numbers[14][0];

            // Return digit
            return GetDigit_One(digit) + _numbers[11][0];
        }
        private static string GetDigit_Three(int digit, int zero, int four, int seven, int nine)
        {
            // Only between 0 and 9
            if (digit < 0 || digit > 9)
                throw new Exception("Out of range.");

            // Exceptions
            if (digit == 3)
                return _numbers[12][0];
            if (digit == 6)
                return _numbers[13][0];
            if (digit == 8)
                return _numbers[14][0];

            // Return digit
            return GetDigit_One(digit, zero, four, seven, nine) + _numbers[11][0];
        }

        // [4]321 (Kilo-digits [0]000 - [9]999)
        private static string GetDigit_Four(int digit)
        {
            // Only between 0 and 9
            if (digit < 0 || digit > 9)
                throw new Exception("Out of range.");

            // Exceptions
            if (digit == 1)
                return _numbers[16][0];
            if (digit == 3)
                return _numbers[17][0];
            if (digit == 8)
                return _numbers[18][0];

            // Return digit
            return GetDigit_One(digit) + _numbers[15][0];
        }
        private static string GetDigit_Four(int digit, int zero, int four, int seven, int nine, int thousand, int oneThousand)
        {
            // Only between 0 and 9
            if (digit < 0 || digit > 9)
                throw new Exception("Out of range.");

            // Exceptions
            if (digit == 1)
                return _numbers[16][oneThousand];
            if (digit == 3)
                return _numbers[17][0];
            if (digit == 8)
                return _numbers[18][0];

            // Return digit
            return GetDigit_One(digit, zero, four, seven, nine) + _numbers[15][thousand];
        }

        // [4321] ("Kilo and lower"-digits [0000] - [9999])
        private static string GetDigits(int number)
        {
            //
            string numberString = number.ToString();
            int length = numberString.Length;
            string word = "";

            // Don't even bother with zero
            if (number == 0)
                return GetDigit_One(0);

            // Only between 0 and 9999
            if (number < 0 || number > 9999)
                throw new Exception("Out of range.");

            // Last four digits 9999[9999]
            for (int i = 0; i < Math.Min(4, length); i++)
            {
                switch ((length - 1) - i)
                {
                    case 0: // (0-9)
                        if (int.Parse(numberString[i].ToString()) == '0' && length > 1) // (Dont type "zero" at the end)
                            break;
                        word += GetDigit_One(int.Parse(numberString[i].ToString()));
                        break;
                    case 1: // (10-99)
                        if (int.Parse(numberString[i].ToString()) != '0')
                            word += GetDigit_Two(int.Parse(numberString[i].ToString()));
                        break;
                    case 2: // (100-999)
                        if (int.Parse(numberString[i].ToString()) != '0')
                            word += GetDigit_Three(int.Parse(numberString[i].ToString()));
                        break;
                    case 3: // (1000-9999)
                        if (int.Parse(numberString[i].ToString()) != '0')
                            word += GetDigit_Four(int.Parse(numberString[i].ToString()));
                        break;
                }
            }

            //
            return word;
        }
        private static string GetDigits(int number, int zero, int four, int seven, int nine, int thousand, int oneThousand)
        {
            //
            string numberString = number.ToString();
            int length = numberString.Length;
            string word = "";

            // Don't even bother with zero
            if (number == 0)
                return GetDigit_One(0, zero, four, seven, nine);

            // Only between 0 and 9999
            if (number < 0 || number > 9999)
                throw new Exception("Out of range.");

            // Last four digits 9999[9999]
            for (int i = 0; i < Math.Min(4, length); i++)
            {
                switch ((length - 1) - i)
                {
                    case 0: // (0-9)
                        if (numberString[i].ToString() == "0" && length > 1) // (Dont type "zero" at the end)
                            break;
                        word += GetDigit_One(int.Parse(numberString[i].ToString()), zero, four, seven, nine);
                        break;
                    case 1: // (10-99)
                        //if (numberString[i].ToString() != "0")
                        word += GetDigit_Two(int.Parse(numberString[i].ToString()), zero, four, seven, nine);
                        break;
                    case 2: // (100-999)
                        //if (numberString[i].ToString() != "0")
                        word += GetDigit_Three(int.Parse(numberString[i].ToString()), zero, four, seven, nine);
                        break;
                    case 3: // (1000-9999)
                        //if (numberString[i].ToString() != "0")
                        word += GetDigit_Four(int.Parse(numberString[i].ToString()), zero, four, seven, nine, thousand, oneThousand);
                        break;
                }
            }

            //
            return word;
        }

        // [98765]4321 ("Mega to Exa"-digits [00000]0000 - [99999]9999)
        private static string GetDigits_TenThousand(int digit)
        {
            // Only between 10'000 and 99'999'999
            if (digit < 0 || digit > 9999)
                throw new Exception("Out of range.");

            // Return digit
            return GetDigits(digit) + _numbers[19][0];
        }
        private static string GetDigits_TenThousand(int digit, int zero, int four, int seven, int nine, int thousand, int oneThousand)
        {
            // Only between 10'000 and 99'999'999
            if (digit < 0 || digit > 9999)
                throw new Exception("Out of range.");

            // Return digit
            return GetDigits(digit, zero, four, seven, nine, thousand, oneThousand) + _numbers[19][0];
        }

        // [000000]987654321 ("Zetta and larger"-digits [000000]000000000 - [999999]999999999)
        private static string GetDigits_HoundredMillion(int digit)
        {
            // Only between 100'000'000 and 999'999'999'999
            if (digit < 0 || digit > 9999)
                throw new Exception("Out of range.");

            // Return digit
            return GetDigits(digit) + _numbers[20][0];
        }
        private static string GetDigits_HoundredMillion(int digit, int zero, int four, int seven, int nine, int thousand, int oneThousand)
        {
            // Only between 100'000'000 and 999'999'999'999
            if (digit < 0 || digit > 9999)
                throw new Exception("Out of range.");

            // Return digit
            return GetDigits(digit, zero, four, seven, nine, thousand, oneThousand) + _numbers[20][0];
        }

        // GetNumber (Numerical number -> Japanese words)
        /// <summary>
        /// Coverts an integer to japanese (in the roman alphabet)
        /// </summary>
        /// <param name="number">Number to convert to japanese</param>
        /// <returns>The number (in japanese using the roman alphabet)</returns>
        public static string GetNumber(int number)
        {
            string numberString = number.ToString();
            int length = numberString.Length;
            string word = "";

            // [9]999999999
            if (length >= 10)
                GetDigits_HoundredMillion(number / 100000000);

            // [99999]9999
            if (length >= 5)
                word += GetDigits_TenThousand(number / 10000);

            // Last four digits 9999[9999]
            word += GetDigits(number % 10000);

            //
            return word;
        }
        // GetNumber (Numerical number -> Japanese words)
        /// <summary>
        /// Coverts a long integer to japanese (in the roman alphabet)
        /// </summary>
        /// <param name="number">Number to convert to japanese</param>
        /// <returns>The number (in japanese using the roman alphabet)</returns>
        public static string GetNumber(long number)
        {
            string numberString = number.ToString();
            int length = numberString.Length;
            string word = "";

            // Only between 0 and 999'999'999'999
            if (number < 0 || number > 999999999999)
                throw new Exception("Out of range.");

            // [9]999999999
            if (length >= 10)
                GetDigits_HoundredMillion((int)(number / 100000000L));

            // [99999]9999
            if (length >= 5)
                word += GetDigits_TenThousand((int)(number / 10000L));

            // Last four digits 9999[9999]
            word += GetDigits((int)number);

            //
            return word;
        }
        /// <summary>
        /// Coverts an integer to japanese (in the roman alphabet) with additional settings
        /// </summary>
        /// <param name="number">Number to convert to japanese</param>
        /// <param name="settings">The settings (more information can be found in the actual struct)</param>
        /// <returns>The number (in japanese using the roman alphabet)</returns>
        public static string GetNumber(int number, NumberSettings settings)
        {
            // Throw exception if settings are not valid
            if (!settings.IfLegalSettings())
                throw new Exception("Settings are not valid");

            // Set variables
            string numberString = number.ToString();
            int length = numberString.Length;
            string word = "";

            // Only between 0 and 999'999'999'999
            if (number < 0)
                throw new Exception("Out of range.");

            // [9]999999999
            if (length >= 10)
                GetDigits_HoundredMillion(number / 100000000,
                    settings.WordForZero, settings.WordForFour, settings.WordForSeven,
                    settings.WordForNine, settings.WordForThousand, settings.WordForOneThousand);

            // [99999]9999
            if (length >= 5)
                word += GetDigits_TenThousand(number / 10000,
                    settings.WordForZero, settings.WordForFour, settings.WordForSeven,
                    settings.WordForNine, settings.WordForThousand, settings.WordForOneThousand);

            // Last four digits 9999[9999]
            word += GetDigits(number % 10000,
                    settings.WordForZero, settings.WordForFour, settings.WordForSeven,
                    settings.WordForNine, settings.WordForThousand, settings.WordForOneThousand);

            //
            return word;
        }
        /// <summary>
        /// Coverts a long integer to japanese (in the roman alphabet) with additional settings
        /// </summary>
        /// <param name="number">Number to convert to japanese</param>
        /// <param name="settings">The settings (more information can be found in the actual struct)</param>
        /// <returns>The number (in japanese using the roman alphabet)</returns>
        public static string GetNumber(long number, NumberSettings settings)
        {
            // Throw exception if settings are not valid
            if (!settings.IfLegalSettings())
                throw new Exception("Settings are not valid");

            // Set variables
            string numberString = number.ToString();
            int length = numberString.Length;
            string word = "";

            // Only between 0 and 999'999'999'999
            if (number < 0 || number > 999999999999)
                throw new Exception("Out of range.");

            // [9]999999999
            if (length >= 10)
                GetDigits_HoundredMillion((int)(number / 100000000L),
                    settings.WordForZero, settings.WordForFour, settings.WordForSeven,
                    settings.WordForNine, settings.WordForThousand, settings.WordForOneThousand);

            // [99999]9999
            if (length >= 5)
                word += GetDigits_TenThousand((int)(number / 10000L),
                    settings.WordForZero, settings.WordForFour, settings.WordForSeven,
                    settings.WordForNine, settings.WordForThousand, settings.WordForOneThousand);

            // Last four digits 9999[9999]
            word += GetDigits((int)number,
                    settings.WordForZero, settings.WordForFour, settings.WordForSeven,
                    settings.WordForNine, settings.WordForThousand, settings.WordForOneThousand);

            //
            return word;
        }
    }
}
