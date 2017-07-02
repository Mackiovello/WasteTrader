using Starcounter;
using System.Linq;
using WasteTrader.Helpers;
using System;

namespace WasteTrader.ViewModels
{
    partial class UserPage : Json, IBound<Database.Client>
    {
        public bool NoWaste => this.WasteToDisplay.Count() == 0;
        public string NoWasteMessage
        {
            get
            {
                if (this.WasteToDisplay == this.ActiveWaste)
                    return "Du har inga aktiva annonser just nu";
                else
                    return "Du har inga inaktiva annonser just nu";
            }
        }

        protected override void OnData()
        {
            this.WasteToDisplay = this.ActiveWaste;
        }

        static UserPage()
        {
            DefaultTemplate.WasteToDisplay.ElementType.InstanceType = typeof(WasteEntry);
            DefaultTemplate.ActiveWaste.ElementType.InstanceType = typeof(WasteEntry);
            DefaultTemplate.InactiveWaste.ElementType.InstanceType = typeof(WasteEntry);
        }

        void Handle(Input.OpenActiveTrigger action)
        {
            this.WasteToDisplay = this.ActiveWaste;
        }

        void Handle(Input.OpenInactiveTrigger action)
        {
            this.WasteToDisplay = this.InactiveWaste;
        }
    }
}
