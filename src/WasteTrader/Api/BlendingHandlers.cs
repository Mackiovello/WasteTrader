using Starcounter;

namespace WasteTrader.Api
{
    class BlendingHandlers : IHandler
    {
        public void Register()
        {
            Blender.MapUri("/Waste2Value/partial/navigationbar", "user");
            Blender.MapUri("/Waste2Value/partial/home?{?}", "userform-return");
        }
    }
}
