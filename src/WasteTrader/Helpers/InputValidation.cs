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
        public bool IsValid => !ValidationResult.Any(v => v == false);

        private List<bool> ValidationResult = new List<bool>();


        public InputValidation(string toValidate)
        {
            this.ToValidate = toValidate;
        }

        public InputValidation ValidateLength(int minLength, int maxLength)
        {
            if (ToValidate.Length < minLength || ToValidate.Length > maxLength)
                ValidationResult.Add(false);
            else
                ValidationResult.Add(true);

            return this;
        }

        public InputValidation IsOnlyDigits()
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

        public InputValidation OnlyLetters()
        {
            bool allLetters = ToValidate.All(Char.IsLetter);
            ValidationResult.Add(allLetters);
            return this;
        }
    }
}
