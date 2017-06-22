using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WasteTrader.Helpers
{
    public class InputValidation
    {
        private string ToValidate { get; set; }
        public bool IsValid { get; private set; }


        public InputValidation(string toValidate)
        {
            this.ToValidate = toValidate;
        }

        public InputValidation ValidateLength(int minLength, int maxLength)
        {
            if (ToValidate.Length < minLength || ToValidate.Length > maxLength)
            {
                IsValid = false;
            }

            return this;
        }

        public InputValidation OnlyDigits()
        {
            foreach (char c in ToValidate)
            {
                if (c < '0' || c > '9')
                {
                    IsValid = false;
                    break;
                }
                
            }

            return this;
        }

        public InputValidation OnlyLetters()
        {
            bool allLetters = ToValidate.All(Char.IsLetter);
            if (!allLetters)
            {
                IsValid = false;
            }

            return this;
        }
    }
}
