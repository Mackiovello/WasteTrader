using Starcounter;
using WasteTrader.Helpers;

namespace WasteTrader.Api
{
    class BlendingHandlers : IHandler
    {
        public void Register()
        {
            Blender.MapUri(UriHelper.BuildPartialUri("header"), "user");
            Blender.MapUri(UriHelper.BuildPartialUri("Registrera"), "userform");
        }
    }
}
