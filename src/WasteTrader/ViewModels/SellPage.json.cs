using Starcounter;
using WasteTrader.Database;
using Simplified.Ring3;
using System.Linq;
using WasteTrader.Helpers;
using WasteTrader.MathUtils;

namespace WasteTrader.ViewModels
{
    partial class SellPage : Json
    {
        static SellPage()
        {
            DefaultTemplate.Waste.LatitudeDD.Value.InstanceType = typeof(double);
            DefaultTemplate.Waste.LongitudeDD.Value.InstanceType = typeof(double);
        }

        void Handle(Input.SubmitTrigger action)
        {
            Db.Transact(() =>
            {
                var location = new NoDBLocation(this.Waste.LongitudeDD.Value, this.Waste.LatitudeDD.Value);
                SellWaste sellWaste = new SellWaste(location)
                {
                    Title = this.Waste.Title.Value,
                    Description = this.Waste.Description.Value,
                    Quantity = this.Waste.Quantity.Value,
                    Price = this.Waste.Price.Value,
                    Unit = (UnitType)this.Waste.Unit.Value,
                    User = SystemUser.GetCurrentSystemUser()
                };
            });

            this.ClearViewModel();
            this.ShowSuccessMessage = true;
        }

        private void ClearViewModel()
        {
            this.Waste.Description.Value = "";
            this.Waste.Quantity.Value = 0;
            this.Waste.Unit.Value = 0;
            this.Waste.Title.Value = "";
            this.Waste.Price.Value = 0;
        }

        [SellPage_json.Waste.Title]
        partial class WasteTitle : Json
        {
            private const int MinLength = 3;
            private const int MaxLength = 100;
            private string InvalidTitleWarning = $"Lösenordet måste vara mellan {MinLength} och {MaxLength} tecken långt";

            void Handle(Input.Value action)
            {
                this.IsValid = new InputValidation(action.Value)
                    .ValidateLength(MinLength, MaxLength)
                    .IsValid;

                this.Message = this.IsValid ? string.Empty : InvalidTitleWarning;
            }
        }
    }
}
