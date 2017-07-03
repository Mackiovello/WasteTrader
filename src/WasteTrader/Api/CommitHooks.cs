using Simplified.Ring3;
using Simplified.Ring5;
using Starcounter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WasteTrader.ViewModels;

namespace WasteTrader.Api
{
    internal class CommitHooks : IHandler
    {
        public void Register()
        {
            Hook<SystemUserSession>.CommitInsert += (s, a) => this.RefreshSignInState(a);
            Hook<SystemUserSession>.CommitDelete += (s, a) => this.RefreshSignInState(a);
            Hook<SystemUserSession>.CommitUpdate += (s, a) => this.RefreshSignInState(a);
            Hook<SystemUser>.CommitInsert += (s, a) => this.RefreshSignInState(a);
        }

        protected void RefreshSignInState<T>(T createdItem)
        {
            if (Session.Current != null)
            {
                var master = Session.Current.Data as MasterPage;
                master?.RefreshSignInState(createdItem);
            }
        }
    }
}
