using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WasteTrader.Helpers
{
    public class NumberValidation : Validator<double>
    {
        public NumberValidation(double toValidate) : base(toValidate){}

        public NumberValidation IsMoreThanZero()
        {
            bool isMoreThanZero = ToValidate > 0;
            ValidationResult.Add(isMoreThanZero);
            return this;
        }
    }
}
