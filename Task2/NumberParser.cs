using System;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {
            IsCorrectInput(stringValue);
            stringValue = stringValue.Trim();

            int result = 0;
            bool isSigned = stringValue[0] == '-' || stringValue[0] == '+';
            long thNumber = 1;

            for (int i = stringValue.Length - 1; i >= 0; i--)
            {
                if (!isSigned)
                {
                    long checking = result + (stringValue[i] - 48L) * thNumber > Int32.MaxValue ? throw new OverflowException()
                        : result + (stringValue[i] - 48L) * thNumber;
                    result = (int)checking;
                    thNumber *= 10;
                }
                else
                {
                    if (i == 0)
                    {
                        if (stringValue[i] == '-')
                            result *= -1;
                    }
                    else
                    {
                        long checking = -1 * (result + (stringValue[i] - 48L) * thNumber) < Int32.MinValue
                            ? throw new OverflowException()
                            : result + (stringValue[i] - 48L) * thNumber;
                        result = (int)checking;
                        thNumber *= 10;
                    }
                }
            }

            return result;
        }

        private void IsCorrectInput(string stringValue)
        {
            if (stringValue is null)
            {
                throw new ArgumentNullException(nameof(stringValue), "String is null.");
            }

            stringValue = stringValue.Trim();
            if (string.IsNullOrEmpty(stringValue) || string.IsNullOrWhiteSpace(stringValue))
            {
                throw new FormatException("String is empty or whiteSpaces.");
            }

            for (int i = 0; i < stringValue.Length; i++)
            {
                if (i == 0)
                {
                    if ((stringValue[0] != '-' && stringValue[0] != '+') && !char.IsDigit(stringValue[i]))
                    {
                        throw new FormatException("Incorrect Input.");
                    }
                }
                else
                {
                    if (!char.IsDigit(stringValue[i]))
                    {
                        throw new FormatException("Incorrect input.");
                    }
                }
            }
        }
    }
}