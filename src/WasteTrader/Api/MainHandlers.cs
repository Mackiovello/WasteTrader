using Starcounter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WasteTrader.ViewModels;

namespace WasteTrader.Api
{
    class MainHandlers
    {
        public void Register()
        {
            Application.Current.Use(new HtmlFromJsonProvider());
            Application.Current.Use(new PartialToStandaloneHtmlProvider());

            Handle.GET("/WasteTrader", () =>
            {
                var master = GetMasterPage();

                master.CurrentPage = new HomePage();

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
                master = new MasterPage() { Session = Session.Current };
            }

            return master;
        }
    }
}
