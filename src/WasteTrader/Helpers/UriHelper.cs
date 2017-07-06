using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WasteTrader.Api;

namespace WasteTrader.Helpers
{
    public static class UriHelper
    {
        public static string BuildPartialUri(string partialName, string[] parameters = null)
        {
            ValidatePartialName(partialName);

            var uriBuilder = new StringBuilder();
            uriBuilder.Append(PartialHandlers.PartialPrefix);
            uriBuilder.Append(partialName);
            uriBuilder.Append(BuildParameterString(parameters));

            return uriBuilder.ToString();
        }

        private static string BuildParameterString(string[] parameters)
        {
            if (parameters == null)
                return string.Empty;

            var uriBuilder = new StringBuilder();

            ValidateParameters(parameters);
            foreach (var parameter in parameters)
                uriBuilder.Append("/").Append(parameter);

            return uriBuilder.ToString();
        }

        private static void ValidateParameters(string[] parameters)
        {
            foreach (var parameter in parameters)
            {
                if (parameter.Any(Char.IsWhiteSpace))
                    throw new ArgumentException("URI parameters cannot contain spaces");
            }
        }

        private static void ValidatePartialName(string partialName)
        {
            if (partialName == null)
                throw new ArgumentNullException(nameof(partialName));

            if (partialName.Any(Char.IsWhiteSpace))
                throw new ArgumentException($"{nameof(partialName)} cannot contain spaces");
        }
    }
}
