using Starcounter;
using WasteTrader.Database;
using Simplified.Ring3;
using System.Linq;
using WasteTrader.Measurements;
using System;
using System.Collections.Generic;
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

        public bool ValidInput => 
            this.Waste.Description.IsValid &&
            this.Waste.Title.IsValid &&
            this.Waste.Price.IsValid;

        void Handle(Input.SubmitTrigger action)
        {
            if (ValidInput)
            {
                this.CreateWaste();
                this.ClearViewModel();
                this.SubmitMessage = "Annonsen är nu inlagd";
            }
            else
            {
                this.SubmitMessage = "Du har inte fyllt i alla fält riktigt";
            }
        }

        private void CreateWaste()
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
                    Unit = (UnitType)this.Waste.Quantity.Unit,
                    UnitMetricPrefixPower = (int)this.Waste.Quantity.PrefixPower,
                    User = SystemUser.GetCurrentSystemUser()
                };
            });
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
                this.IsValid = new StringValidation(action.Value)
                    .ValidateLength(MinLength, MaxLength)
                    .IsValid;

                this.Message = this.IsValid ? string.Empty : InvalidTitleWarning;
            }
        }

        [SellPage_json.Waste.Description]
        partial class WasteDescription : Json
        {
            private const int MinLength = 20;
            private const int MaxLength = 2000;
            private string InvalidDescriptionWarning = $"Beskrivningen måste vara mellan {MinLength} och {MaxLength} tecken långt";

            void Handle(Input.Value action)
            {
                this.IsValid = new StringValidation(action.Value)
                    .ValidateLength(MinLength, MaxLength)
                    .IsValid;

                this.Message = this.IsValid ? string.Empty : InvalidDescriptionWarning;
            }
        }

        [SellPage_json.Waste.Price]
        partial class WastePrice : Json
        {
            private string InvalidPriceWarning = "Priset måste vara högre än noll";

            void Handle(Input.Value action)
            {
                this.IsValid = new NumberValidation(action.Value)
                    .IsMoreThanZero()
                    .IsValid;

                this.Message = this.IsValid ? string.Empty : InvalidPriceWarning;
            }
        }
    }
}
