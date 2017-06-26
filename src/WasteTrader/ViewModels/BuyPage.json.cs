using Starcounter;
using WasteTrader.Database;
using Simplified.Ring3;
using System.Linq;
using WasteTrader.Helpers;
using WasteTrader.MathUtils;

namespace WasteTrader.ViewModels
{
    partial class BuyPage : Json
    {
        static BuyPage()
        {
            DefaultTemplate.Waste.LatitudeDD.Value.InstanceType = typeof(double);
            DefaultTemplate.Waste.LongitudeDD.Value.InstanceType = typeof(double);
        }

        public bool ValidInput =>
            this.Waste.Description.IsValid &&
            this.Waste.Title.IsValid;

        void Handle(Input.SubmitTrigger action)
        {
            if (ValidInput)
            {
                this.CreateWaste();
                this.ClearViewModel();
                this.SubmitMessage = "Annonsen �r nu inlagd";
            }
            else
            {
                this.SubmitMessage = "Du har inte fyllt i alla f�lt riktigt";
            }
        }

        private void CreateWaste()
        {
            Db.Transact(() =>
            {
                var location = new NoDBLocation(this.Waste.LongitudeDD.Value, this.Waste.LatitudeDD.Value);
                BuyWaste buyWaste = new BuyWaste(location)
                {
                    Title = this.Waste.Title.Value,
                    Description = this.Waste.Description.Value,
                    User = SystemUser.GetCurrentSystemUser(),
                    Active = true 
                };
            });
        }

        private void ClearViewModel()
        {
            this.Waste.Description.Value = "";
            this.Waste.Title.Value = "";
        }

        [BuyPage_json.Waste.Title]
        partial class WasteTitle : Json
        {
            private const int MinLength = 3;
            private const int MaxLength = 100;
            private string InvalidTitleWarning = $"Titeln m�ste vara mellan {MinLength} och {MaxLength} tecken l�ngt";

            void Handle(Input.Value action)
            {
                this.IsValid = new StringValidation(action.Value)
                    .ValidateLength(MinLength, MaxLength)
                    .IsValid;

                this.Message = this.IsValid ? string.Empty : InvalidTitleWarning;
            }
        }

        [BuyPage_json.Waste.Description]
        partial class WasteDescription : Json
        {
            private const int MinLength = 20;
            private const int MaxLength = 2000;
            private string InvalidDescriptionWarning = $"Beskrivningen m�ste vara mellan {MinLength} och {MaxLength} tecken l�ngt";

            void Handle(Input.Value action)
            {
                this.IsValid = new StringValidation(action.Value)
                    .ValidateLength(MinLength, MaxLength)
                    .IsValid;

                this.Message = this.IsValid ? string.Empty : InvalidDescriptionWarning;
            }
        }
    }
}
