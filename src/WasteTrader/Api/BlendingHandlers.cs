using Starcounter;

namespace WasteTrader.Api
{
    class BlendingHandlers : IHandler
    {
        public void Register()
        {
            var mainHandlers = new MainHandlers();
            Blender.MapUri(mainHandlers.BuildPartialUri("header"), "user");
            Blender.MapUri(mainHandlers.BuildPartialUri("Registrera"), "userform");
        }
    }
}
