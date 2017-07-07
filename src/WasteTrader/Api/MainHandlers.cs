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

            Handle.GET("/WasteTrader", () => Self.GET("/Waste2Value"));

            Handle.GET("/Waste2Value", () =>
            {
                return GetMasterPageWithCurrentPage(Self.GET(UriHelper.BuildPartialUri("Hitta")));
            });

            Handle.GET("/Waste2Value/empty", () =>
            {
                return GetMasterPageWithCurrentPage(new EmptyPage());
            });

            Handle.GET("/Waste2Value/Hitta", () =>
            {
                return GetMasterPageWithCurrentPage(Self.GET(UriHelper.BuildPartialUri("Hitta")));
            });

            Handle.GET("/Waste2Value/Registrera", () =>
            {
                return GetMasterPageWithCurrentPage(Self.GET(UriHelper.BuildPartialUri("Registrera")));
            });

            Handle.GET("/Waste2Value/reset-password", () =>
            {
                return GetMasterPageWithCurrentPage(Self.GET(UriHelper.BuildPartialUri("reset-password")));
            });

            Handle.GET("/Waste2Value/avfall/{?}", (string objectId) =>
            {
                Json partial = Self.GET(UriHelper.BuildPartialUri("WastePage", new string[] { objectId }));
                return GetMasterPageWithCurrentPage(partial);
            });

            AuthorizedHandle.GET("/Waste2Value/Salj", () =>
            {
                return GetMasterPageWithCurrentPage(Self.GET(UriHelper.BuildPartialUri("sell")));
            });

            AuthorizedHandle.GET("/Waste2Value/user/{?}", (string username) =>
            {
                Json partial = Self.GET(UriHelper.BuildPartialUri("user", new[] { username }));
                return GetMasterPageWithCurrentPage(partial);
            });

            AuthorizedHandle.GET("/Waste2Value/minsida", () =>
            {
                string username = SystemUser.GetCurrentSystemUser().Username;
                Json partial = Self.GET(UriHelper.BuildPartialUri("user", new[] { username }));
                return GetMasterPageWithCurrentPage(partial);
            });
        }

        private MasterPage GetMasterPageWithCurrentPage(Json partial)
        {
            var master = GetMasterPage();
            master.CurrentPage = partial;
            return master;
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
                    Drawer = Self.GET(UriHelper.BuildPartialUri("drawer")),
                    Header = Self.GET(UriHelper.BuildPartialUri("header"))
                };
            }

            return master;
        }
    }
}
