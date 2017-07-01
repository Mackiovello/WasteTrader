using Simplified.Ring3;
using Starcounter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WasteTrader.ViewModels;

namespace WasteTrader.Helpers
{
    public class AuthorizedHandle
    {
        private static bool NoUser => SystemUser.GetCurrentSystemUser() == null;

        public static void GET(string uriTemplate, Func<Response> code)
        {
            Handle.GET(uriTemplate, () =>
            {
                if (NoUser)
                    return Self.GET("/Waste2Value/Empty");
                else
                    return code();
            });
        }

        public static void GET<T>(string uriTemplate, Func<T, Response> code)
        {
            Handle.GET<T>(uriTemplate, (parameters) =>
            {
                if (NoUser)
                    return Self.GET("/Waste2Value/Empty");
                else
                    return code(parameters);
            });
        }
    }
}
