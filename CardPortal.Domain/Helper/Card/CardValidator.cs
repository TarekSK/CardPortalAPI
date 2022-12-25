namespace CardPortal.Domain.Helper.Card
{
    public static  class CardValidator
    {
        // Check Card Number Lenght
        // And Validate Using Luhn Algorithm
        // Reference: https://www.geeksforgeeks.org/luhn-algorithm/
        public static bool CardNumberValidator(string cardNumber)
        {
            // Check if card number is 16 digits
            if(cardNumber.Length != 16) { return false; }

            // Get number of digits
            int digitCount = cardNumber.Length;

            // Sum - Init
            int sum = 0;

            // IsSecond - Init
            bool isSecondNumber = false;

            // Loop through card number with count [From Right To Left]
            for (int i = digitCount - 1; i >= 0; i--)
            {
                int d = cardNumber[i] - '0';

                if(isSecondNumber)
                {
                    d = d * 2;
                }

                // Add two digits to handle cases
                // that make to digits after doubling
                sum += d / 10;
                sum += d % 10;

                // Revert
                isSecondNumber = !isSecondNumber;
            }

            return (sum % 10 == 0);
        }
    }
}
