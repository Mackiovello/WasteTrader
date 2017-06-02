using Starcounter;
using WasteTrader.MathUtils;
using System.Linq;

namespace WasteTrader.Database
{
    [Database]
    public class Location
    {
        public double LongitudeDD { get; set; }
        public double LatitudeDD { get; set; }
        public IWaste Waste
        {
            get
            {
                var buyWaste = Db.SQL<BuyWaste>("SELECT i FROM WasteTrader.BuyWaste i WHERE i.Location = ?", this).FirstOrDefault();
                if (buyWaste != null) return buyWaste;
                var sellWaste = Db.SQL<SellWaste>("SELECT i FROM WasteTrader.SellWaste i WHERE i.Location = ?", this).FirstOrDefault();
                if (sellWaste != null) return sellWaste;
                else throw new System.Exception("Location " + this.GetObjectNo() + " has no Waste bound to it.");
            }
        }
        public double LongitudeRadians => GeographyMath.DegreesToRadians(LongitudeDD);
        public double LatitudeRadians => GeographyMath.DegreesToRadians(LatitudeDD);
    }
}
