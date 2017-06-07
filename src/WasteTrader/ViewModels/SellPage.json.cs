using Starcounter;
using WasteTrader.Database;

namespace WasteTrader.ViewModels
{
    partial class SellPage : Json
    {
        void Handle(Input.SubmitTrigger action)
        {
            Db.Transact(() =>
            {
                new SellWaste
                {
                    Description = this.Waste.Description,
                    Quantity = (long)this.Waste.Quantity,
                    Unit = (UnitType)this.Waste.Unit
                };
            });

            this.ClearViewModel();
            this.ShowSuccessMessage = true;
        }

        private void ClearViewModel()
        {
            this.Person.Name = "";
            this.Person.Email = "";
            this.Waste.Description = "";
            this.Waste.Quantity = 0;
            this.Waste.Unit = 0;
        }
    }
}
