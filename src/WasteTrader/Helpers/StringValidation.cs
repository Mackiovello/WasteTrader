using System;
using System.Linq;

namespace WasteTrader.Helpers
{
    public class StringValidation : Validator<string>
    {
        public StringValidation(string toValidate) : base(toValidate){}

        public StringValidation ValidateLength(int minLength, int maxLength)
        {
            if (ToValidate.Length < minLength || ToValidate.Length > maxLength)
                ValidationResult.Add(false);
            else
                ValidationResult.Add(true);

            return this;
        }

        public StringValidation IsOnlyDigits()
        {
            bool onlyDigits = true;
            foreach (char c in ToValidate)
            {
                if (c < '0' || c > '9')
                {
                    onlyDigits = false;
                    break;
                }
            }

            ValidationResult.Add(onlyDigits);

            return this;
        }

        public StringValidation OnlyLetters()
        {
            bool allLetters = ToValidate.All(Char.IsLetter);
            ValidationResult.Add(allLetters);
            return this;
        }
    }
}
