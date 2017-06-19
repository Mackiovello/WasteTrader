using Starcounter;
using WasteTrader.Database;
using Simplified.Ring3;
using System.Linq;
using WasteTrader.Measurements;
using System;
using System.Collections.Generic;

namespace WasteTrader.ViewModels
{
    partial class SellPage : Json
    {
        static SellPage()
        {
            DefaultTemplate.Waste.LatitudeDD.InstanceType = typeof(double);
            DefaultTemplate.Waste.LongitudeDD.InstanceType = typeof(double);
        }

        protected bool isValidWaste()
        {
            return true;
        }

        void Handle(Input.SubmitTrigger action)
        {
            if (isValidWaste())
            {
                Db.Transact(() =>
                {
                    SellWaste sellWaste = new SellWaste(new MathUtils.NoDBLocation(this.Waste.LongitudeDD, this.Waste.LatitudeDD))
                    {
                        Title = this.Waste.Title,
                        Description = this.Waste.Description,
                        Quantity = this.Waste.Quantity,
                        Price = this.Waste.Price,
                        Unit = (UnitType)this.UnitSort,
                        UnitMetricPrefixPower = (int)this.Waste.Unit,
                        User = SystemUser.GetCurrentSystemUser()
                    };
                });

                this.ClearViewModel();
                this.ShowSuccessMessage = true;
            }
        }

        protected static Tuple<int, string>[] MassUnits = UnitsToTuples(Mass.Units);
        protected static Tuple<int, string>[] LengthUnits = UnitsToTuples(Length.Units);
        protected static Tuple<int, string>[] AreaUnits = UnitsToTuples(Area.Units);
        protected static Tuple<int, string>[] VolumeUnits = UnitsToTuples(Volume.Units);

        protected static Tuple<int, string>[] UnitsToTuples(IDictionary<int, Unit> dictionary)
        {
            return dictionary.Select(kvp => new Tuple<int, string>(kvp.Key + kvp.Value.Offset, kvp.Value.Text)).ToArray();
        }

        void Handle(Input.UnitSort action)
        {
            UnitSuffixes.Clear();
            switch ((UnitType)action.Value)
            {
                case UnitType.Mass:
                    AddUnitSuffixes(MassUnits);
                    break;
                case UnitType.Length:
                    AddUnitSuffixes(LengthUnits);
                    break;
                case UnitType.Area:
                    AddUnitSuffixes(AreaUnits);
                    break;
                case UnitType.Volume:
                    AddUnitSuffixes(VolumeUnits);
                    break;
            }
        }

        protected void AddUnitSuffixes(Tuple<int, string>[] options)
        {
            foreach (Tuple<int, string> unit in options)
            {
                var option = UnitSuffixes.Add();
                option.Label = unit.Item2;
                option.PrefixPower = unit.Item1;
            }
        }

        private void ClearViewModel()
        {
            this.Waste.Description = "";
            this.Waste.Quantity = 0;
            this.Waste.Unit = 0;
            this.Waste.Title = "";
            this.Waste.Price = 0;
        }
    }
}
