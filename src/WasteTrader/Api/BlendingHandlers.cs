using Starcounter;

namespace WasteTrader.Api
{
    class BlendingHandlers : IHandler
    {
        public void Register()
        {
            Blender.MapUri("/Waste2Value/partial/header", "user");
        }
    }
}
