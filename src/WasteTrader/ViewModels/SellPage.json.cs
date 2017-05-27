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
                new Waste
                {
                    Description = this.Waste.Description,
                    Quantity = (double) this.Waste.Quantity,
                    Unit = this.Waste.Unit
                };
            });
        }
    }
}
