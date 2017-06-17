using Starcounter;
using WasteTrader.Database;
using Simplified.Ring3;
using System.Linq;

namespace WasteTrader.ViewModels
{
    partial class SellPage : Json
    {
        static SellPage()
        {
            DefaultTemplate.Waste.LatitudeDD.InstanceType = typeof(double);
            DefaultTemplate.Waste.LongitudeDD.InstanceType = typeof(double);
        }

        void Handle(Input.SubmitTrigger action)
        {
            Db.Transact(() =>
            {
                SellWaste sellWaste = new SellWaste(new MathUtils.NoDBLocation(this.Waste.LongitudeDD, this.Waste.LatitudeDD))
                {
                    Title = this.Waste.Title,
                    Description = this.Waste.Description,
                    Quantity = this.Waste.Quantity,
                    Price = this.Waste.Price,
                    Unit = (UnitType)this.Waste.Unit,
                    User = SystemUser.GetCurrentSystemUser()
                };
            });

            this.ClearViewModel();
            this.ShowSuccessMessage = true;
        }

        private void ClearViewModel()
        {
            this.Waste.Description = "";
            this.Waste.Quantity = 0;
            this.Waste.Unit = 0;
        }
    }
}
