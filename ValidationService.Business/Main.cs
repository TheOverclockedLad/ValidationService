namespace ValidationService.Business
{
    public class Main
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

        public string CardType(long number)
        {
            byte firstDigit = (byte)(number / System.Math.Pow(10, System.Math.Floor(System.Math.Log10(number))));
            byte digits = (byte)System.Math.Floor(System.Math.Log10(number) + 1);

            switch (firstDigit)
            {
                case 3:
                    if (digits == 15)
                        return "Amex";
                    else if (digits == 16)
                        return "JCB";
                    else
                        return "Unknown and/or invalid card";

                case 4:
                    if (digits == 16)
                        return "Visa";
                    else
                        return "Unknown and/or invalid card";

                case 5:
                    if (digits == 16)
                        return "Master Card";
                    else
                        return "Unknown and/or invalid card";

                default:
                    return "Unknown and/or invalid card";
            }
        }

        public bool IsValid(long number, System.DateTime? expiry = null)
        {
            string cardType = CardType(number);

            switch(cardType)
            {
                case "Amex":
                    return true;

                case "JCB":
                    return true;

                case "Visa":
                    if (expiry != null && System.DateTime.IsLeapYear(((System.DateTime)expiry).Year))
                        return true;
                    else
                        return false;

                case "Master Card":
                    if (expiry != null && IsPrime(((System.DateTime)expiry).Year))
                        return true;
                    else
                        return false;

                default:
                    return false;
            }
        }
    }
}