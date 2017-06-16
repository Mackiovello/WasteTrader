using System.Collections.Generic;
using Starcounter;
using Simplified.Ring3;
using System.Linq;

namespace WasteTrader.Database
{
    [Database]
    public class Client
    {
        public Client(SystemUser sysUser)
        {
            User = sysUser;
        }

        public static Client GetClient(SystemUser systemUser)
        {
            if (systemUser == null) return null;
            Client client = Db.SQL<Client>($"SELECT c FROM {typeof(Client)} c WHERE c.{nameof(User)} = ?", systemUser).FirstOrDefault();
            if (client == null)
            {
                Db.Transact(() => client = new Client(systemUser));
            }
            return client;
        }

        public static Client GetClientFromUsername(string username)
        {
            Client user = Db.SQL<SystemUser>($"SELECT u FROM {typeof(SystemUser)} u WHERE u.{nameof(SystemUser.Username)} = ?", username).FirstOrDefault();
            return user;
        }

        public static implicit operator Client(SystemUser systemUser)
        {
            return GetClient(systemUser);
        }

        public SystemUser User { get; }
        public string EmailAddress
        {
            get
            {
                EmailAddressRelation relation = Db.SQL<EmailAddressRelation>($"SELECT r FROM {typeof(EmailAddressRelation)} r WHERE r.{nameof(EmailAddressRelation.Somebody)} = ?", User).First;
                return relation.EmailAddress.EMail;
            }
        }
        public string Username { get => User.Username; }
        public string Name { get => User.Name; }
        public string Description { get => User.Description; }
        public IEnumerable<SellWaste> SellWastes => Db.SQL<SellWaste>($"SELECT w FROM {typeof(SellWaste)} w WHERE w.{nameof(SellWaste.User)} = ?", this);
        public IEnumerable<BuyWaste> BuyWastes => Db.SQL<BuyWaste>($"SELECT w FROM {typeof(BuyWaste)} w WHERE w.{nameof(BuyWaste.User)} = ?", this);
        public IEnumerable<Waste> Wastes => Db.SQL<Waste>($"SELECT w FROM {typeof(Waste)} w WHERE w.{nameof(Waste.User)} = ?", this);
    }
}
