using Starcounter;
using WasteTrader.ViewModels;
using Simplified.Ring3;
using System.Text;
using WasteTrader.Helpers;
using System;
using System.Linq;

namespace WasteTrader.Api
{
    public class MainHandlers : IHandler
    {
        public void Register()
        {
            var html = @"<!DOCTYPE html>
<html>
<head>
    <meta charset=""utf-8"">
    <title>{0}</title>
    <script src=""/sys/webcomponentsjs/webcomponents.min.js""></script>
    <link rel=""import"" href=""/sys/polymer/polymer.html"">
    <link rel=""import"" href=""/sys/starcounter.html"">
    <link rel=""import"" href=""/sys/starcounter-include/starcounter-include.html"">
    <link rel=""import"" href=""/sys/starcounter-debug-aid/src/starcounter-debug-aid.html"">
</head>
<body>
    <template is=""dom-bind"" id=""puppet-root"">
        <template is=""imported-template"" content$=""{{{{model.Html}}}}"" model=""{{{{model}}}}""></template>
    </template>
    <puppet-client ref=""puppet-root"" remote-url=""{1}""></puppet-client>
    <starcounter-debug-aid></starcounter-debug-aid>
    <script src=""/sys/material-components-web.min.js""></script>
 </body>
</html>";

            Application.Current.Use(new HtmlFromJsonProvider());
            Application.Current.Use(new PartialToStandaloneHtmlProvider(html));

            Handle.GET("/WasteTrader", () =>
            {
                return Self.GET("/Waste2Value");
            });

            Handle.GET("/Waste2Value", () =>
            {
                var master = GetMasterPage();
                master.CurrentPage = Self.GET(BuildPartialUri("Hitta"));
                return master;
            });

            Handle.GET("/Waste2Value/empty", () =>
            {
                var master = GetMasterPage();
                master.CurrentPage = new EmptyPage();
                return master;
            });

            AuthorizedHandle.GET("/Waste2Value/Salj", () =>
            {
                var master = GetMasterPage();
                master.CurrentPage = Self.GET(BuildPartialUri("sell"));
                return master;
            });

            Handle.GET("/Waste2Value/Hitta", () =>
            {
                var master = GetMasterPage();
                master.CurrentPage = Self.GET(BuildPartialUri("Hitta"));
                return master;
            });

            AuthorizedHandle.GET("/Waste2Value/user/{?}", (string username) =>
            {
                var master = GetMasterPage();
                master.CurrentPage = Self.GET(BuildPartialUri("user", new[] { username }));
                return master;
            });

            AuthorizedHandle.GET("/Waste2Value/minsida", () =>
            {
                var master = GetMasterPage();
                string username = SystemUser.GetCurrentSystemUser().Username;
                master.CurrentPage = Self.GET(BuildPartialUri("user", new[] { username }));
                return master;
            });

            Handle.GET("/Waste2Value/Registrera", () =>
            {
                var master = GetMasterPage();
                master.CurrentPage = Self.GET(BuildPartialUri("Registrera"));
                return master;
            });

            Handle.GET("/Waste2Value/avfall/{?}", (string objectId) =>
            {
                var master = GetMasterPage();
                master.CurrentPage = Self.GET(BuildPartialUri("WastePage", new string[] { objectId }));
                return master;
            });
        }

        public string BuildPartialUri(string partialName, string[] parameters = null)
        {
            ValidatePartialName(partialName);

            var uriBuilder = new StringBuilder();
            uriBuilder.Append(PartialHandlers.PartialPrefix);
            uriBuilder.Append(partialName);
            uriBuilder.Append(BuildParameterString(parameters));

            return uriBuilder.ToString();
        }

        private string BuildParameterString(string[] parameters)
        {
            if (parameters == null)
                return "";

            var uriBuilder = new StringBuilder();

            ValidateParameters(parameters);
            foreach (var parameter in parameters)
                uriBuilder.Append("/").Append(parameter);

            return uriBuilder.ToString();
        }

        private void ValidateParameters(string[] parameters)
        {
            foreach (var parameter in parameters)
            {
                if (parameter.Any(Char.IsWhiteSpace))
                    throw new ArgumentException("URI parameters cannot contain spaces");
            }
        }

        private void ValidatePartialName(string partialName)
        {
            if (partialName == null)
                throw new ArgumentNullException(nameof(partialName));

            if (partialName.Any(Char.IsWhiteSpace))
                throw new ArgumentException($"{nameof(partialName)} cannot contain spaces");
        }

        private MasterPage GetMasterPage()
        {
            Session.Current = Session.Current ?? new Session(SessionOptions.PatchVersioning);

            MasterPage master = Session.Current.Data as MasterPage;

            if (master == null)
            {
                master = new MasterPage()
                {
                    Session = Session.Current,
                    Drawer = Self.GET(BuildPartialUri("drawer")),
                    Header = Self.GET(BuildPartialUri("header"))
                };
            }

            return master;
        }
    }
}
