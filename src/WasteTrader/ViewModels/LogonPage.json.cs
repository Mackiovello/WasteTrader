using Starcounter;
using Simplified.Ring3;
using Simplified.Ring2;

namespace WasteTrader.ViewModels
{
    partial class LogonPage : Json
    {
        public Database.Client Client;
        void Handle(Input.SubmitTrigger action)
        {
            if (Client == null)
            {
                Db.Transact(() =>
                {
                    Client = SystemUser.RegisterSystemUser(Username, Email, PasswordOne);
                    Client.User.WhoIs = new Person { Name = Name };
                    SystemUserGroup group = Db.SQL<SystemUserGroup>($"SELECT o FROM {typeof(SystemUserGroup)} o WHERE o.{nameof(SystemUserGroup.Name)} = ?", "Client").First;
                    if(group == null)
                    {
                        group = new SystemUserGroup
                        {
                            Name = "Client",
                            Description = "Service clients"
                        };
                    }
                    SystemUserGroupMember member = new SystemUserGroupMember();
                    member.WhatIs = Client.User;
                    member.ToWhat = group;
                });
            }
            else
            {
                Client.Username = Username;
                Client.Name = Name;
                Client.EmailAddress = Email;
                if (PasswordOne.Length != 0 && PasswordOne.Equals(PasswordTwo))
                {
                    Db.Transact(() => Client.User.Password = SystemUser.GeneratePasswordHash(Client.User.GetObjectID(), PasswordOne, Client.User.PasswordSalt));
                }
            }
        }

        protected bool AllowedInput()
        {
            return true;
        }

        protected void WrongInput(string message)
        {

        }
    }
}
