namespace ValidationService
{
    public abstract class Validator
    {
        bool IsPrime(int number)
        {
            if (number > 1)
            {
                for (int i = 2; i < number; i++)
                    if (number % i == 0)
                        return false;

                return true;
            }

            return false;
        }

        protected string Validate(long number, System.DateTime expiry)
        {
            byte firstDigit = (byte)(number / System.Math.Pow(10, System.Math.Floor(System.Math.Log10(number))));
            byte digits = (byte)System.Math.Floor(System.Math.Log10(number) + 1);

            if (digits == 15 && firstDigit == 3)
                return "Amex";

            if (digits == 16)
            {
                if (firstDigit == 3)
                    return "JCB";

                if (firstDigit == 4 && System.DateTime.IsLeapYear(expiry.Year))
                    return "Visa";

                if (firstDigit == 5 && IsPrime(expiry.Year))
                    return "Master Card";
            }

            return "Unknown and/or invalid card";
        }
    }
}