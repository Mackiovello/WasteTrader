using System.Collections.Generic;
using Starcounter;
using Simplified.Ring3;

namespace WasteTrader.Database
{
    [Database]
    public class Client
    {
        public Client(SystemUser sysUser)
        {
            SystemUser = sysUser;
        }
        public SystemUser SystemUser { get; }
        public string Username => SystemUser.Username;
        public string Name => SystemUser.Name;
        public string Description => SystemUser.Description;
        public IEnumerable<SellWaste> SellWastes => Db.SQL<SellWaste>($"SELECT w FROM {typeof(SellWaste)} w WHERE w.{nameof(SellWaste.User)} = ?", this);
        public IEnumerable<BuyWaste> BuyWastes => Db.SQL<BuyWaste>($"SELECT w FROM {typeof(BuyWaste)} w WHERE w.{nameof(BuyWaste.User)} = ?", this);
        public IEnumerable<Waste> Wastes => Db.SQL<Waste>($"SELECT w FROM {typeof(Waste)} w WHERE w.{nameof(Waste.User)} = ?", this);
    }
}
