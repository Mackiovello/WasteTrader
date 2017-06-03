using Starcounter;
using Simplified.Ring3;

namespace SignIn
{
    partial class MasterPage : Json
    {
        public SignInPage SignInPage;

        protected string url;

        public void Open(string Url)
        {
            this.url = Url;
            this.RefreshSignInState();
        }

        public void RefreshSignInState()
        {
            SystemUser user = SystemUser.GetCurrentSystemUser();

            if (this.RequireSignIn && user != null)
            {
                this.Partial = Self.GET(this.url);
            }
            else if (this.RequireSignIn && user == null)
            {
                this.Partial = Self.GET("/signin/partial/accessdenied-form");
            }
            else if (user == null && !string.IsNullOrEmpty(this.url))
            {
                this.Partial = Self.GET(this.url);
            }
            else if (!string.IsNullOrEmpty(this.OriginalUrl))
            {
                this.Partial = null;
                this.RedirectUrl = this.OriginalUrl;
                this.OriginalUrl = null;
            }
            else if (user != null)
            {
                this.Partial = Self.GET("/signin/partial/alreadyin-form");
            }

            this.SignInPage?.RefreshSignInState();
        }
    }
}