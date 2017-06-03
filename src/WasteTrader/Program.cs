using WasteTrader.Api;

namespace WasteTrader
{
    class Program
    {
        static void Main()
        {
            var handlers = new IHandler[]
            {
                new MainHandlers(),
                new PartialHandlers(),
                new BlendingHandlers()
            };

            foreach (var handler in handlers)
            {
                handler.Register();
            }
        }
    }
}