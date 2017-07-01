using Starcounter;
using System.Linq;
using WasteTrader.Helpers;
using System;

namespace WasteTrader.ViewModels
{
    partial class UserPage : Json, IBound<Database.Client>
    {
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
