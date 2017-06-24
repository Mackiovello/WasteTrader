using System.Collections.Generic;
using Starcounter;
using Simplified.Ring3;
using System.Linq;
using System;

namespace WasteTrader.Database
{
    [Database]
    public class Client
    {
        private static readonly string SELECT_CLIENT_WHERE_USER = 
            $"SELECT c FROM {typeof(Client)} c WHERE c.{nameof(User)} = ?";

        private static readonly string SELECT_USER_WHERE_USERNAME = 
            $"SELECT u FROM {typeof(SystemUser)} u WHERE u.{nameof(SystemUser.Username)} = ?";

        private static readonly string SELECT_EMAILADDRESSRELATION_WHERE_SOMEBODY = 
            $"SELECT r FROM {typeof(EmailAddressRelation)} r WHERE r.{nameof(EmailAddressRelation.Somebody)} = ?";

        private static readonly string SELECT_SELLWASTE_WHERE_USER =
            $"SELECT w FROM {typeof(SellWaste)} w WHERE w.{nameof(SellWaste.User)} = ?";

        private static readonly string SELECT_BUYWASTE_WHERE_USER =
            $"SELECT w FROM {typeof(BuyWaste)} w WHERE w.{nameof(BuyWaste.User)} = ?";

        private static readonly string SELECT_WASTE_WHERE_USER =
            $"SELECT w FROM {typeof(Waste)} w WHERE w.{nameof(Waste.User)} = ?";

        public Client(SystemUser sysUser)
        {
            this.User = sysUser;
        }

        public static Client GetClient(SystemUser systemUser)
        {
            systemUser = systemUser ?? throw new ArgumentNullException();
            Client client = Db.SQL<Client>(SELECT_CLIENT_WHERE_USER, systemUser).FirstOrDefault();
            return client ?? Db.Transact(() => new Client(systemUser));
        }

        public static Client GetClientFromUsername(string username)
        {
            Client user = Db.SQL<SystemUser>(SELECT_USER_WHERE_USERNAME, username).FirstOrDefault();
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
                var relation = Db.SQL<EmailAddressRelation>(SELECT_EMAILADDRESSRELATION_WHERE_SOMEBODY, User).FirstOrDefault();
                return relation.EmailAddress.EMail;
            }
        }
        public string Username => User.Username;
        public string Name => User.Name;
        public string Description => User.Description;
        public IEnumerable<SellWaste> SellWastes => Db.SQL<SellWaste>(SELECT_SELLWASTE_WHERE_USER, this);
        public IEnumerable<BuyWaste> BuyWastes => Db.SQL<BuyWaste>(SELECT_BUYWASTE_WHERE_USER, this);
        public IEnumerable<Waste> WasteEntries => Db.SQL<Waste>(SELECT_WASTE_WHERE_USER, this);
    }
}
