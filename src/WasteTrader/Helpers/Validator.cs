using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WasteTrader.Helpers
{
    public abstract class Validator<T>
    {
        public Validator(T toValidate)
        {
            this.ToValidate = toValidate;
        }

        protected T ToValidate { get; set; }

        protected List<bool> ValidationResult = new List<bool>();

        public bool IsValid => !ValidationResult.Any(v => v == false);
    }
}
