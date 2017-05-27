using Starcounter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WasteTrader.ViewModels;

namespace WasteTrader.Api
{
    class MainHandlers : IHandler
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
    <link rel=""import"" href=""/sys/bootstrap-material.html"">
</head>
<body>
    <template is=""dom-bind"" id=""puppet-root"">
        <template is=""imported-template"" content$=""{{{{model.Html}}}}"" model=""{{{{model}}}}""></template>
    </template>
    <puppet-client ref=""puppet-root"" remote-url=""{1}""></puppet-client>
    <starcounter-debug-aid></starcounter-debug-aid>
    <script src=""https://code.jquery.com/jquery-3.2.1.min.js"" integrity=""sha256-hwg4gsxgFZhOsEEamdOYGBf13FyQuiTwlAQgxVSNgt4="" crossorigin=""anonymous""></script>
    <script src=""/sys/bootstrap.min.js""></script>
    <script src=""/sys/material.min.js""></script>
    <script>$.material.init()</script>
 </body>
</html>";

            Application.Current.Use(new HtmlFromJsonProvider());
            Application.Current.Use(new PartialToStandaloneHtmlProvider(html));

            Handle.GET("/Waste2Value", () =>
            {
                var master = GetMasterPage();

                master.CurrentPage = Self.GET("/Waste2Value/partial/Home?waste2value/salj");

                return master;
            });

            Handle.GET("/Waste2Value/Salj", () =>
            {
                var master = GetMasterPage();

                master.CurrentPage = new SellPage();

                return master;
            });

            Handle.GET("/Waste2Value/Hitta", () =>
            {
                var master = GetMasterPage();

                master.CurrentPage = Self.GET("/Waste2Value/partial/Hitta");

                return master;
            });
        }

        private MasterPage GetMasterPage()
        {
            if (Session.Current == null)
            {
                Session.Current = new Session(SessionOptions.PatchVersioning);
            }

            MasterPage master = Session.Current.Data as MasterPage;

            if (master == null)
            {
                master = new MasterPage()
                {
                    Session = Session.Current,
                    NavigationBar = Self.GET("/Waste2Value/partial/navigationbar")
                };
            }

            return master;
        }
    }
}
