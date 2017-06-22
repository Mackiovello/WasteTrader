using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WasteTrader.Helpers
{
    public class NumberValidation
    {
        public bool IsValid => !ValidationResult.Any(v => v == false);

        private double ToValidate { get; set; }

        private List<bool> ValidationResult = new List<bool>();

        public NumberValidation(double toValidate)
        {
            this.ToValidate = toValidate;
        }

        public NumberValidation IsMoreThanZero()
        {
            bool isMoreThanZero = ToValidate > 0;
            ValidationResult.Add(isMoreThanZero);
            return this;
        }
    }
}
