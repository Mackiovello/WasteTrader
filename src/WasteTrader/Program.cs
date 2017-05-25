using System;
using Starcounter;
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
                new PartialHandlers()
            };

            foreach (var handler in handlers)
            {
                handler.Register();
            }
        }
    }
}